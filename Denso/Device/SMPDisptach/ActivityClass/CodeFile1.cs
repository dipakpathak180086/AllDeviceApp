using Android.Views;
using SMPDisptach;
using System;
using System.Globalization;
using System.Linq;

private void TxtCustKanbanBarcode_KeyPress(object sender, View.KeyEventArgs e)
{
    try
    {
        if (e.Event.Action == KeyEventActions.Down)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                //DismissKeyboard();
                txtCustKanbanBarcode.SelectAll();
                if (ValidateCustomerControls())
                {
                    //[] mfg = "12 D2009AAA4279 49400-76TM0-00 00001/00004,D2009,9,,2024100301,L211,5,AA,01,,LOC  -   3,D200,49400M76T00".Split(','); //06 index qty for tata


                    string partNo = string.Empty;
                    string qty = "0";
                    string seqNo = "0";
                    int counter = 0;
                    bool isMatchPart = false;
                    bool isMatchQty = false;
                    bool isMatchSeqNo = false;
                    string dnhaPartNo = string.Empty;
                    string dnhaPartQty = string.Empty;

                    var mlistCustomerPatternFinal = clsGlobal.mlistCustomerPattern.Where(x => x.ThreePointCheckDigit == clsGlobal.m3CheckPointsDigit).Select(x => x).ToList();
                    if (mlistCustomerPatternFinal.Count == 0)
                    {
                        clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} 3CheckDigitNot Matched!!", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    // Loop through the list of patterns
                    //foreach (var entry in clsGlobal.mlistCustomerPattern)
                    foreach (var entry in mlistCustomerPatternFinal)
                    {
                        counter = 0;
                        if (isMatchPart && isMatchQty)
                        {
                            break;
                        }
                        // Step 4: Iterate through the hashtable inside the dictionary
                        for (int i = 0; i < entry.keyValueData.Count; i++)
                        {
                            // Get the start and end indexes from the keyValueData entry
                            int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                            int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "CUSTOMERPARTNO")
                            {
                                try
                                {
                                    if (txtCustKanbanBarcode.Text.TrimEnd().Contains(",") && clsGlobal.m3CheckPointsDigit == "Y")
                                    {
                                        try
                                        {
                                            string[] sArr = txtCustKanbanBarcode.Text.TrimEnd().Split(",");
                                            partNo = sArr[12];
                                        }
                                        catch
                                        {
                                            partNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();
                                        }


                                    }
                                    else
                                    {
                                        partNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();

                                    }
                                    qty = _DnhaSupQty.ToString();
                                }
                                catch
                                {

                                    partNo = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                            {
                                try
                                {
                                    int number = 0;
                                    if (txtCustKanbanBarcode.Text.TrimEnd().Contains(","))
                                    {
                                        string[] sArr = txtCustKanbanBarcode.Text.TrimEnd().Split(",");
                                        string strPartNoExtract = "";
                                        int iQtyExtract = 0;
                                        if (sArr.Length > 5)
                                        {
                                            int.TryParse(txtCustKanbanBarcode.Text.TrimEnd().Split(",")[6].TrimEnd(), out number);
                                            if (number == 0)
                                            {
                                                if (!clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                                                {
                                                    clsGlobal.ParseBarcode(txtCustKanbanBarcode.Text.Trim(), out strPartNoExtract, out iQtyExtract);
                                                    partNo = strPartNoExtract;
                                                    number = iQtyExtract;
                                                }
                                            }
                                            //else
                                            //{
                                            //    int.TryParse(txtCustKanbanBarcode.Text.TrimEnd().Split(",")[6].TrimEnd(), out number);
                                            //}
                                        }
                                        else
                                        {
                                            int.TryParse(txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                        }

                                    }
                                    else
                                    {
                                        int.TryParse(txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                    }


                                    qty = number.ToString().Trim();
                                }
                                catch
                                {
                                    qty = "0";


                                }


                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SEQNO")
                            {
                                try
                                {
                                    string strSEQNo = "";

                                    strSEQNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length);

                                    seqNo = clsGlobal.mCustSeqNo = strSEQNo.ToString().Trim();
                                    isMatchSeqNo = true;
                                }
                                catch
                                {
                                    seqNo = "0";


                                }


                            }
                            // Check if the part number exists in the DNHA list
                            if (clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                            {
                                //Now part is matched then need to check this partno into Main Master table any Expiry or specific validation is there then match the data
                                //If not matched it will go for next pattern if any
                                //
                                dnhaPartNo = clsGlobal.mlistCustomer.Where(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo).Select(x => x.DNHAPartNo).First();
                                dnhaPartQty = qty;
                                strCustomerPattern = entry.Patterns;
                                iQrCode2Qty = Convert.ToInt32(qty);
                                isMatchPart = true;
                                if (iQrCode2Qty > 0)
                                {
                                    isMatchQty = true;
                                }



                            }
                            counter++;
                        }


                    }

                    if (!isMatchPart)
                    {
                        clsGLB.showToastNGMessage("Invalid Customer Kanban Barcode.", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!_ListItem.Exists(p => p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"Part No. {dnhaPartNo} isn't available in SIL List! ", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (!clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Part. {partNo} isn't available in main master list! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (string.IsNullOrEmpty(qty))
                    {
                        clsGLB.showToastNGMessage($"Qty is not available! ", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"This Part No {dnhaPartNo} Scanning Completed! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isMatchSeqNo)
                    {
                        if (clsGlobal.mSILType == "2POINTS")
                        {
                            if (_dicBarcode1.ContainsKey(seqNo.Trim()))
                            {

                                clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                        }
                        else
                        {
                            if (_dicBarcode2.ContainsKey(seqNo.Trim()))
                            {

                                clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                        }
                    }

                    if (clsGlobal.mSILType == "2POINTS")
                    {
                        WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}");
                        if (isMatchSeqNo)
                        {
                            //_dicBarcode1.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                            _dicBarcode1.Add(seqNo, seqNo);
                        }
                        txtCustKanbanBarcode.SelectAll();
                        txtCustKanbanBarcode.RequestFocus();
                    }
                    else
                    {
                        if (iQrCode1Qty != iQrCode2Qty)
                        {
                            clsGLB.showToastNGMessage($"QR Code1 Qty {iQrCode1Qty} should be equal to QR Code2 Qty {iQrCode2Qty} ! ", this);
                            txtCustKanbanBarcode.Text = "";
                            txtCustKanbanBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;

                        }
                        string strBarcode1 = string.Empty;
                        if (txtDNHASUPKanbanBarcode.Text.Length > 0)
                        {
                            strBarcode1 = txtDNHASUPKanbanBarcode.Text.Trim();
                        }
                        else
                        {
                            strBarcode1 = txtDNHASUPKanbanBarcode.Text.Trim();
                        }
                        CustScannedOn = DateTime.Now.ToString();
                        //WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{strBarcode1}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}")
                        WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}" +
                        $"~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                        $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                        $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strCustomerPattern}");
                        if (isMatchSeqNo)
                        {
                            //_dicBarcode2.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                            _dicBarcode2.Add(seqNo, seqNo);
                        }
                    }
                    //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty

                    //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                    //UpdateFinalListScanQty(partNo, qty);
                    UpdateFinalListScanQty(dnhaPartNo, dnhaPartQty);
                    txtDNHASUPKanbanBarcode.Text = txtCustKanbanBarcode.Text = txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.Enabled = true;
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    if (_TotalQty == _ScanQty)
                    {
                        WriteSILCompltedFile(TruckNo);
                        clsGLB.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        clear();
                        BindSpinnerRegisteredSIL();
                    }
                    SoundForOK();
                }

            }
            else
                e.Handled = false;
        }
    }
    catch (Exception ex)
    {
        clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

    }
    finally
    { }
}

private void ScanningDNHAKanbanBarcode()
{
    try
    {
        if (ValidateDNHAControls())
        {
            //if (_dicBarcode1.ContainsKey(txtDNHASUPKanbanBarcode.Text.Trim()))
            //{
            //    clsGLB.showToastNGMessage($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
            //    txtDNHASUPKanbanBarcode.Text = "";
            //    txtDNHASUPKanbanBarcode.RequestFocus();
            //    SoundForNG();
            //    ShowAlertPopUp();
            //    return;
            //}
            strDNHAPartNo = "";
            string partNo = string.Empty;
            string qty = "0";
            string mfg = "";
            string exp = "";
            string lot = "";
            int counter = 0;
            string seqNo = "";
            bool isMatchSeqNo = false;
            bool isMatchPart = false;
            bool isMatchMFGDate = false;
            bool isMatchExpiryDate = false;
            bool isMatchQty = false;
            bool isMatchSuspectedLot = false;
            bool isProductExpired = false;
            bool isProductMFGShippedDateCross = false;
            bool isProductEXPShippedDateCross = false;
            bool isNGSuspectedLot = false;
            var maxEntry = clsGlobal.mlistDNHAPattern
               .OrderByDescending(entry => entry.keyValueData.Count);
            // Loop through the list of patterns
            foreach (var entry in maxEntry)
            {
                counter = 0;
                // Permutations of the flags
                if ((isMatchPart && isMatchQty) && isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                {
                    // All remaining flags are true
                    break;
                }
                else if ((isMatchPart && isMatchQty) && isMatchMFGDate && isMatchExpiryDate && !isMatchSuspectedLot)
                {
                    // MFG Date and Expiry Date are true, Suspected Lot is false
                    break;
                }
                else if ((isMatchPart && isMatchQty) && isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                {
                    // Only MFG Date is true
                    break;
                }
                else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                {
                    // Expiry Date and Suspected Lot are true, MFG Date is false
                    break;
                }
                else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && isMatchExpiryDate && !isMatchSuspectedLot)
                {
                    // Only Expiry Date is true
                    break;
                }
                else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && isMatchSuspectedLot)
                {
                    // Only Suspected Lot is true
                    break;
                }
                else if ((isMatchPart && isMatchQty) && isMatchMFGDate && !isMatchExpiryDate && isMatchSuspectedLot)
                {
                    // MFG Date and Suspected Lot are true, Expiry Date is false
                    break;
                }

                //if (isMatchPart)
                //{
                //    break;
                //}
                // Step 4: Iterate through the hashtable inside the dictionary
                for (int i = 0; i < entry.keyValueData.Count; i++)
                {

                    // Get the start and end indexes from the keyValueData entry
                    int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                    int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                    // Extract the part number or quantity based on the current counter
                    int length = endIndex - startIndex;
                    if (entry.keyValueData[i].Item1.Trim().ToUpper() == "DNHAPARTNO")
                    {
                        try
                        {
                            partNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();

                        }
                        catch
                        {
                            partNo = "";
                        }

                    }
                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                    {
                        try
                        {
                            int number;
                            int.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                            qty = number.ToString().Trim();
                            iQrCode1Qty = _DnhaSupQty = number;
                        }
                        catch
                        {
                            qty = "";
                        }

                    }
                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "MFG")
                    {
                        try
                        {

                            //string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };  // Add all possible formats
                            DateTime? date;
                            //DateTime.TryParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                            date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length));
                            if (date == null || date == DateTime.MinValue)
                            {
                                mfg = "";
                            }
                            else
                            {
                                mfg = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                            }

                        }
                        catch
                        {
                            mfg = "";
                        }

                    }
                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "EXP")
                    {
                        try
                        {
                            DateTime? date;
                            //DateTime.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out date);
                            //date = DateTime.ParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                            date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length));
                            if (date == null || date == DateTime.MinValue)
                            {
                                exp = "";
                            }
                            else
                            {

                                exp = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                            }
                        }
                        catch
                        {
                            exp = "";
                        }

                    }
                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LOT")
                    {
                        try
                        {

                            lot = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();


                        }
                        catch
                        {
                            lot = "";
                        }

                    }
                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SEQNO")
                    {
                        try
                        {
                            string strSEQNo = "";

                            strSEQNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);

                            seqNo = clsGlobal.mDNHASupSeqNo = strSEQNo.ToString().Trim();
                            isMatchSeqNo = true;
                        }
                        catch
                        {
                            seqNo = "0";


                        }


                    }
                    //CheckNGSuspectedLot

                    if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == partNo && x.LotNo == lot))
                    {
                        isMatchSuspectedLot = true;
                        isNGSuspectedLot = true;
                    }
                    // Check if the part number exists in the DNHA list
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsMfgDate == true))
                    {
                        isMatchPart = true;
                        isMatchQty = true;
                        if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsMfgDate == true && mfg != ""))
                        {
                            isMatchMFGDate = true;
                            string strExpDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.ExpDays).FirstOrDefault();
                            string strShipDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.MFGShipDays).FirstOrDefault();
                            if (strExpDays != null && strShipDays == null)
                            {
                                //DateTime dateTime = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strExpDays));
                                string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };   // Add all possible formats
                                DateTime dateTime;
                                DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime);

                                dateTime = dateTime.AddDays(Convert.ToInt32(strExpDays));
                                DateTime todayDateTime;
                                DateTime.TryParseExact(DateTime.Today.ToString("yyyy-MM-dd"), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out todayDateTime);


                                if (todayDateTime.Date > dateTime.Date)
                                {
                                    isProductExpired = true;
                                    break;
                                }
                            }
                            else if (strShipDays != null && strExpDays != null)
                            {
                                string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };   // Add all possible formats
                                DateTime todayDateTime;
                                DateTime.TryParseExact(DateTime.Now.ToString("yyyy-MM-dd"), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out todayDateTime);



                                DateTime dateExp;
                                DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateExp);
                                dateExp = dateExp.AddDays(Convert.ToInt32(strExpDays));

                                DateTime dateShip;
                                DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateShip);
                                dateShip = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strShipDays));
                                if (todayDateTime.Date > dateExp.Date)
                                {
                                    isProductExpired = true;
                                    break;
                                }


                                else if (todayDateTime.Date >= dateShip.Date && todayDateTime.Date <= dateExp.Date)
                                {
                                    isProductMFGShippedDateCross = true;
                                    break;
                                }
                            }
                            //if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo
                            //    && x.IsMfgExp == true
                            //    && Convert.ToDateTime(mfg) >= x.MFGDate
                            //    && Convert.ToDateTime(mfg) <= x.EXPDate))
                            //{
                            //    isMatchKanbanMFGAndExp = true;
                            //    isMatchPart = true;
                            //    break;
                            //}

                        }
                    }

                    else if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsExpDate == true && exp != ""))
                    {
                        isMatchPart = true;
                        isMatchQty = true;
                        isMatchExpiryDate = true;
                        bool atucalExp = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.IsExpDate).FirstOrDefault();
                        string strExpShipDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.EXPShipDays).FirstOrDefault();
                        int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32(strExpShipDays);
                        if (atucalExp == true && (iExpShipDays == 0 || iExpShipDays == null))
                        {
                            if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                            {
                                if (DateTime.Today > expDate)
                                {
                                    isProductExpired = true;
                                    break;
                                }
                            }
                        }
                        else if (atucalExp == true && (iExpShipDays != 0 || iExpShipDays != null))
                        {

                            if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                            {
                                if (DateTime.Today > expDate)
                                {
                                    isProductExpired = true;
                                    break;
                                }
                                else if (DateTime.Today > expDate.AddDays(-iExpShipDays))
                                {
                                    isProductEXPShippedDateCross = true;
                                    break;
                                }

                            }
                        }

                        //if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                        //{
                        //    isProductExpired = true;
                        //    break;
                        //}
                    }
                    else
                    {
                        if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo))
                        {
                            strDNHAPattern = entry.Patterns;
                        }
                        isMatchPart = true;
                        isMatchQty = true;
                    }
                    counter++;
                }


            }
            if (!isMatchPart)
            {
                clsGLB.showToastNGMessage("Invalid DNHA Kanban Barcode.", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (!_ListItem.Exists(p => p.PartNo == partNo))
            {
                clsGLB.showToastNGMessage($"Part No. {partNo} isn't available in SIL List! ", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;

            }
            if (isNGSuspectedLot)
            {
                clsGLB.showToastNGMessage($"This product Lot {lot} is suspected {partNo},Scanned valid product", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsExpDate == true) && isMatchExpiryDate == false))
            {
                clsGLB.showToastNGMessage($"This product is registered with expiary check {partNo},Scanned valid product or check pattern", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsMfgDate == true) && isMatchMFGDate == false))
            {
                clsGLB.showToastNGMessage($"This product is registered with manufacturing check {partNo},Scanned valid product or check pattern", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (isProductMFGShippedDateCross)
            {
                clsGLB.showToastNGMessage($"This product is MFG Shipping date over {partNo},Scanned valid product", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (isProductEXPShippedDateCross)
            {
                clsGLB.showToastNGMessage($"This product is EXP Shipping date over {partNo},Scanned valid product", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }
            if (isProductExpired)
            {
                clsGLB.showToastNGMessage($"This product is Expired {partNo},Scanned valid product", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;
            }


            if (!clsGlobal.mlistDNHA.Exists(p => p.DNHAPartNo == partNo))
            {
                clsGLB.showToastNGMessage($"Scanned Part {partNo} isn't available in main master list! ", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;

            }
            if (string.IsNullOrEmpty(qty))
            {
                clsGLB.showToastNGMessage($"Qty is not available! ", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;

            }
            if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == partNo))
            {
                clsGLB.showToastNGMessage($"This Part No {partNo} Scanning Completed! ", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;

            }
            if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == partNo))
            {
                clsGLB.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                txtDNHASUPKanbanBarcode.Text = "";
                txtDNHASUPKanbanBarcode.RequestFocus();
                SoundForNG();
                ShowAlertPopUp();
                return;

            }
            if (isMatchSeqNo)
            {
                if (_dicBarcode1.ContainsKey(seqNo.Trim()))
                {
                    clsGLB.showToastNGMessage($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    SoundForNG();
                    ShowAlertPopUp();
                    return;
                }
            }
            try
            {
                CustPart = txtDNHASUPKanbanBarcode.Text.Substring(66, 25).Trim();
                PartNo = txtDNHASUPKanbanBarcode.Text.Substring(91, 15).Trim();
                Qty = txtDNHASUPKanbanBarcode.Text.Substring(106, 7).Trim();
                ProcessCode = txtDNHASUPKanbanBarcode.Text.Substring(113, 5).Trim();
                SequenceNo = txtDNHASUPKanbanBarcode.Text.Substring(118, 7).Trim();
                DensoBarcode = txtDNHASUPKanbanBarcode.Text.Substring(0, 150).Trim();
                DNHAScannedOn = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (clsGlobal.mSILType == "2POINTS")
            {
                strDNHAPartNo = partNo;
                //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                UpdateFinalListScanQty(partNo, qty);
                WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                    $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                    $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strDNHAPattern}");
                if (isMatchSeqNo)
                {
                    _dicBarcode1.Add(seqNo, seqNo);
                }
                if (_TotalQty == _ScanQty)
                {
                    WriteSILCompltedFile(TruckNo);
                    clsGLB.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    clear();
                    BindSpinnerRegisteredSIL();
                }
            }
            else
            {
                strDNHAPartNo = partNo;
                if (isMatchSeqNo)
                {
                    _dicBarcode1.Add(seqNo.Trim(), seqNo.Trim());
                }
                txtDNHASUPKanbanBarcode.Enabled = false;
                txtCustKanbanBarcode.RequestFocus();
            }
            SoundForOK();

        }
    }
    catch (Exception ex)
    {

        throw ex;
    }

}