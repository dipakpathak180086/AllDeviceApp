; ModuleID = 'obj\Release\81\android\typemaps.x86_64.ll'
source_filename = "obj\Release\81\android\typemaps.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.TypeMapJava = type {
	i32,; uint32_t module_index
	i32,; uint32_t type_token_id
	i32; uint32_t java_name_index
}

%struct.TypeMapModule = type {
	[16 x i8],; uint8_t module_uuid[16]
	i32,; uint32_t entry_count
	i32,; uint32_t duplicate_count
	%struct.TypeMapModuleEntry*,; TypeMapModuleEntry* map
	%struct.TypeMapModuleEntry*,; TypeMapModuleEntry* duplicate_map
	i8*,; char* assembly_name
	%struct.MonoImage*,; MonoImage* image
	i32,; uint32_t java_name_width
	i8*; uint8_t* java_map
}

%struct.TypeMapModuleEntry = type {
	i32,; uint32_t type_token_id
	i32; uint32_t java_map_index
}

@map_module_count = local_unnamed_addr constant i32 12, align 4

@java_type_count = local_unnamed_addr constant i32 624, align 4

; Map modules data

; module0_managed_to_java
@module0_managed_to_java = internal constant [117 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 605; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554453, ; type_token_id
		i32 259; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 118; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 478; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 507; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554461, ; type_token_id
		i32 298; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 171; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 77; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 85; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554479, ; type_token_id
		i32 300; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 67; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554482, ; type_token_id
		i32 135; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554486, ; type_token_id
		i32 3; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554495, ; type_token_id
		i32 284; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554496, ; type_token_id
		i32 80; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554498, ; type_token_id
		i32 285; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554499, ; type_token_id
		i32 138; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554500, ; type_token_id
		i32 30; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554502, ; type_token_id
		i32 592; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554504, ; type_token_id
		i32 29; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554505, ; type_token_id
		i32 452; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554508, ; type_token_id
		i32 176; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554509, ; type_token_id
		i32 484; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554510, ; type_token_id
		i32 185; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554511, ; type_token_id
		i32 210; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554518, ; type_token_id
		i32 40; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554519, ; type_token_id
		i32 154; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554521, ; type_token_id
		i32 552; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554522, ; type_token_id
		i32 520; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554524, ; type_token_id
		i32 54; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554525, ; type_token_id
		i32 360; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554533, ; type_token_id
		i32 100; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554536, ; type_token_id
		i32 616; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554537, ; type_token_id
		i32 288; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554539, ; type_token_id
		i32 448; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554541, ; type_token_id
		i32 103; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554542, ; type_token_id
		i32 46; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554543, ; type_token_id
		i32 250; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554544, ; type_token_id
		i32 246; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554545, ; type_token_id
		i32 571; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554546, ; type_token_id
		i32 238; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554547, ; type_token_id
		i32 194; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554549, ; type_token_id
		i32 15; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554551, ; type_token_id
		i32 362; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554552, ; type_token_id
		i32 158; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554553, ; type_token_id
		i32 189; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554554, ; type_token_id
		i32 320; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554555, ; type_token_id
		i32 455; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554556, ; type_token_id
		i32 385; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554557, ; type_token_id
		i32 214; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554558, ; type_token_id
		i32 280; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554559, ; type_token_id
		i32 456; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554560, ; type_token_id
		i32 254; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554561, ; type_token_id
		i32 179; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554562, ; type_token_id
		i32 268; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554563, ; type_token_id
		i32 304; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554564, ; type_token_id
		i32 553; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554565, ; type_token_id
		i32 586; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554566, ; type_token_id
		i32 599; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554567, ; type_token_id
		i32 205; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554568, ; type_token_id
		i32 34; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554569, ; type_token_id
		i32 5; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554570, ; type_token_id
		i32 21; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554571, ; type_token_id
		i32 458; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554576, ; type_token_id
		i32 180; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554579, ; type_token_id
		i32 417; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554583, ; type_token_id
		i32 527; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554585, ; type_token_id
		i32 78; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554589, ; type_token_id
		i32 351; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554595, ; type_token_id
		i32 532; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554597, ; type_token_id
		i32 93; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554599, ; type_token_id
		i32 314; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554601, ; type_token_id
		i32 441; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554602, ; type_token_id
		i32 42; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554603, ; type_token_id
		i32 166; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554604, ; type_token_id
		i32 514; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554606, ; type_token_id
		i32 90; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554608, ; type_token_id
		i32 615; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554609, ; type_token_id
		i32 201; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554610, ; type_token_id
		i32 563; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554611, ; type_token_id
		i32 391; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554612, ; type_token_id
		i32 115; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554613, ; type_token_id
		i32 582; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554614, ; type_token_id
		i32 504; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554615, ; type_token_id
		i32 212; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554616, ; type_token_id
		i32 523; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554622, ; type_token_id
		i32 68; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554624, ; type_token_id
		i32 63; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554630, ; type_token_id
		i32 6; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554634, ; type_token_id
		i32 122; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554636, ; type_token_id
		i32 144; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554637, ; type_token_id
		i32 0; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554645, ; type_token_id
		i32 88; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554646, ; type_token_id
		i32 186; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554649, ; type_token_id
		i32 581; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554650, ; type_token_id
		i32 91; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554651, ; type_token_id
		i32 242; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554658, ; type_token_id
		i32 193; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554666, ; type_token_id
		i32 97; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554668, ; type_token_id
		i32 614; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554674, ; type_token_id
		i32 400; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554676, ; type_token_id
		i32 113; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554677, ; type_token_id
		i32 601; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554683, ; type_token_id
		i32 466; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554684, ; type_token_id
		i32 99; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554685, ; type_token_id
		i32 112; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554689, ; type_token_id
		i32 346; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554690, ; type_token_id
		i32 160; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554692, ; type_token_id
		i32 243; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554701, ; type_token_id
		i32 398; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554707, ; type_token_id
		i32 594; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554708, ; type_token_id
		i32 13; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554710, ; type_token_id
		i32 220; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554711, ; type_token_id
		i32 75; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554712, ; type_token_id
		i32 257; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554718, ; type_token_id
		i32 521; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554729, ; type_token_id
		i32 512; java_map_index
	}
], align 16; end of 'module0_managed_to_java' array


; module1_managed_to_java
@module1_managed_to_java = internal constant [25 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 178; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 557; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 66; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 273; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 309; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 508; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554445, ; type_token_id
		i32 197; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 525; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 473; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 372; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 331; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 380; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554462, ; type_token_id
		i32 109; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 24; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 290; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 119; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 334; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554469, ; type_token_id
		i32 111; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554470, ; type_token_id
		i32 434; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554471, ; type_token_id
		i32 204; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554473, ; type_token_id
		i32 41; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554475, ; type_token_id
		i32 498; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554477, ; type_token_id
		i32 414; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554478, ; type_token_id
		i32 16; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554480, ; type_token_id
		i32 451; java_map_index
	}
], align 16; end of 'module1_managed_to_java' array


; module1_managed_to_java_duplicates
@module1_managed_to_java_duplicates = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 273; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 16; java_map_index
	}
], align 16; end of 'module1_managed_to_java_duplicates' array


; module2_managed_to_java
@module2_managed_to_java = internal constant [4 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 465; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 8; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 575; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 429; java_map_index
	}
], align 16; end of 'module2_managed_to_java' array


; module2_managed_to_java_duplicates
@module2_managed_to_java_duplicates = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 465; java_map_index
	}
], align 4; end of 'module2_managed_to_java_duplicates' array


; module3_managed_to_java
@module3_managed_to_java = internal constant [16 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 577; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 608; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 367; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 487; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 428; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 453; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 395; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 1; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 200; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 199; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554462, ; type_token_id
		i32 125; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 329; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 559; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 114; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554473, ; type_token_id
		i32 208; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554474, ; type_token_id
		i32 542; java_map_index
	}
], align 16; end of 'module3_managed_to_java' array


; module3_managed_to_java_duplicates
@module3_managed_to_java_duplicates = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 608; java_map_index
	}
], align 4; end of 'module3_managed_to_java_duplicates' array


; module4_managed_to_java
@module4_managed_to_java = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 622; java_map_index
	}
], align 4; end of 'module4_managed_to_java' array


; module5_managed_to_java
@module5_managed_to_java = internal constant [34 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 308; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 374; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 295; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 574; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 121; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 20; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554445, ; type_token_id
		i32 142; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554446, ; type_token_id
		i32 480; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 124; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 497; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 287; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554451, ; type_token_id
		i32 524; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 302; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554455, ; type_token_id
		i32 335; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554457, ; type_token_id
		i32 278; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 130; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554461, ; type_token_id
		i32 221; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 393; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 312; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554465, ; type_token_id
		i32 155; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 396; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554467, ; type_token_id
		i32 126; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 379; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554470, ; type_token_id
		i32 350; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554472, ; type_token_id
		i32 10; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554474, ; type_token_id
		i32 172; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554475, ; type_token_id
		i32 313; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554478, ; type_token_id
		i32 253; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554482, ; type_token_id
		i32 223; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554484, ; type_token_id
		i32 58; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554486, ; type_token_id
		i32 409; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554487, ; type_token_id
		i32 195; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554488, ; type_token_id
		i32 47; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554491, ; type_token_id
		i32 488; java_map_index
	}
], align 16; end of 'module5_managed_to_java' array


; module5_managed_to_java_duplicates
@module5_managed_to_java_duplicates = internal constant [4 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 295; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554476, ; type_token_id
		i32 313; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 126; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554489, ; type_token_id
		i32 47; java_map_index
	}
], align 16; end of 'module5_managed_to_java_duplicates' array


; module6_managed_to_java
@module6_managed_to_java = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 501; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 503; java_map_index
	}
], align 16; end of 'module6_managed_to_java' array


; module7_managed_to_java
@module7_managed_to_java = internal constant [397 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554597, ; type_token_id
		i32 370; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554598, ; type_token_id
		i32 517; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554600, ; type_token_id
		i32 83; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554602, ; type_token_id
		i32 153; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554604, ; type_token_id
		i32 231; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554606, ; type_token_id
		i32 191; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554608, ; type_token_id
		i32 25; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554610, ; type_token_id
		i32 516; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554612, ; type_token_id
		i32 322; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554614, ; type_token_id
		i32 248; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554616, ; type_token_id
		i32 535; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554618, ; type_token_id
		i32 543; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554620, ; type_token_id
		i32 357; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554622, ; type_token_id
		i32 475; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554623, ; type_token_id
		i32 383; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554624, ; type_token_id
		i32 617; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554626, ; type_token_id
		i32 177; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554627, ; type_token_id
		i32 236; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554629, ; type_token_id
		i32 363; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554631, ; type_token_id
		i32 420; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554643, ; type_token_id
		i32 18; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554645, ; type_token_id
		i32 528; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554648, ; type_token_id
		i32 499; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554649, ; type_token_id
		i32 470; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554651, ; type_token_id
		i32 584; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554653, ; type_token_id
		i32 184; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554655, ; type_token_id
		i32 610; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554656, ; type_token_id
		i32 549; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554657, ; type_token_id
		i32 366; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554659, ; type_token_id
		i32 89; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554662, ; type_token_id
		i32 137; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554663, ; type_token_id
		i32 432; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554665, ; type_token_id
		i32 56; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554667, ; type_token_id
		i32 522; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554670, ; type_token_id
		i32 618; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554671, ; type_token_id
		i32 17; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554672, ; type_token_id
		i32 128; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554674, ; type_token_id
		i32 12; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554675, ; type_token_id
		i32 505; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554677, ; type_token_id
		i32 526; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554678, ; type_token_id
		i32 623; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554679, ; type_token_id
		i32 332; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554685, ; type_token_id
		i32 9; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554687, ; type_token_id
		i32 386; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554688, ; type_token_id
		i32 474; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554691, ; type_token_id
		i32 401; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554692, ; type_token_id
		i32 424; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554693, ; type_token_id
		i32 579; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554696, ; type_token_id
		i32 227; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554697, ; type_token_id
		i32 607; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554698, ; type_token_id
		i32 439; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554699, ; type_token_id
		i32 230; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554701, ; type_token_id
		i32 336; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554703, ; type_token_id
		i32 274; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554705, ; type_token_id
		i32 425; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554706, ; type_token_id
		i32 325; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554707, ; type_token_id
		i32 490; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554708, ; type_token_id
		i32 23; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554710, ; type_token_id
		i32 150; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554713, ; type_token_id
		i32 235; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554714, ; type_token_id
		i32 225; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554715, ; type_token_id
		i32 541; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554716, ; type_token_id
		i32 355; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554718, ; type_token_id
		i32 282; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554719, ; type_token_id
		i32 110; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554720, ; type_token_id
		i32 602; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554721, ; type_token_id
		i32 127; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554722, ; type_token_id
		i32 469; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554723, ; type_token_id
		i32 433; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554725, ; type_token_id
		i32 292; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554726, ; type_token_id
		i32 33; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554728, ; type_token_id
		i32 190; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554729, ; type_token_id
		i32 37; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554730, ; type_token_id
		i32 163; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554732, ; type_token_id
		i32 330; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554734, ; type_token_id
		i32 397; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554735, ; type_token_id
		i32 87; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554736, ; type_token_id
		i32 218; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554738, ; type_token_id
		i32 462; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554740, ; type_token_id
		i32 500; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554741, ; type_token_id
		i32 306; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554743, ; type_token_id
		i32 271; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554745, ; type_token_id
		i32 436; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554748, ; type_token_id
		i32 266; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554749, ; type_token_id
		i32 365; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554752, ; type_token_id
		i32 496; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554753, ; type_token_id
		i32 483; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554762, ; type_token_id
		i32 585; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554763, ; type_token_id
		i32 431; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554765, ; type_token_id
		i32 316; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554766, ; type_token_id
		i32 183; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554768, ; type_token_id
		i32 311; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554770, ; type_token_id
		i32 27; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554771, ; type_token_id
		i32 550; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554772, ; type_token_id
		i32 105; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554774, ; type_token_id
		i32 321; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554776, ; type_token_id
		i32 49; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554778, ; type_token_id
		i32 241; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554780, ; type_token_id
		i32 106; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554781, ; type_token_id
		i32 249; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554783, ; type_token_id
		i32 240; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554784, ; type_token_id
		i32 182; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554788, ; type_token_id
		i32 19; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554790, ; type_token_id
		i32 558; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554792, ; type_token_id
		i32 593; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554795, ; type_token_id
		i32 381; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554796, ; type_token_id
		i32 613; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554798, ; type_token_id
		i32 609; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554801, ; type_token_id
		i32 116; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554803, ; type_token_id
		i32 286; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554805, ; type_token_id
		i32 198; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554807, ; type_token_id
		i32 187; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554810, ; type_token_id
		i32 305; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554812, ; type_token_id
		i32 147; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554814, ; type_token_id
		i32 129; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554817, ; type_token_id
		i32 82; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554819, ; type_token_id
		i32 101; java_map_index
	}, 
	; 117
	%struct.TypeMapModuleEntry {
		i32 33554821, ; type_token_id
		i32 148; java_map_index
	}, 
	; 118
	%struct.TypeMapModuleEntry {
		i32 33554823, ; type_token_id
		i32 437; java_map_index
	}, 
	; 119
	%struct.TypeMapModuleEntry {
		i32 33554825, ; type_token_id
		i32 95; java_map_index
	}, 
	; 120
	%struct.TypeMapModuleEntry {
		i32 33554827, ; type_token_id
		i32 442; java_map_index
	}, 
	; 121
	%struct.TypeMapModuleEntry {
		i32 33554829, ; type_token_id
		i32 486; java_map_index
	}, 
	; 122
	%struct.TypeMapModuleEntry {
		i32 33554831, ; type_token_id
		i32 269; java_map_index
	}, 
	; 123
	%struct.TypeMapModuleEntry {
		i32 33554832, ; type_token_id
		i32 358; java_map_index
	}, 
	; 124
	%struct.TypeMapModuleEntry {
		i32 33554840, ; type_token_id
		i32 81; java_map_index
	}, 
	; 125
	%struct.TypeMapModuleEntry {
		i32 33554845, ; type_token_id
		i32 554; java_map_index
	}, 
	; 126
	%struct.TypeMapModuleEntry {
		i32 33554846, ; type_token_id
		i32 59; java_map_index
	}, 
	; 127
	%struct.TypeMapModuleEntry {
		i32 33554848, ; type_token_id
		i32 352; java_map_index
	}, 
	; 128
	%struct.TypeMapModuleEntry {
		i32 33554850, ; type_token_id
		i32 562; java_map_index
	}, 
	; 129
	%struct.TypeMapModuleEntry {
		i32 33554853, ; type_token_id
		i32 252; java_map_index
	}, 
	; 130
	%struct.TypeMapModuleEntry {
		i32 33554855, ; type_token_id
		i32 211; java_map_index
	}, 
	; 131
	%struct.TypeMapModuleEntry {
		i32 33554858, ; type_token_id
		i32 573; java_map_index
	}, 
	; 132
	%struct.TypeMapModuleEntry {
		i32 33554859, ; type_token_id
		i32 356; java_map_index
	}, 
	; 133
	%struct.TypeMapModuleEntry {
		i32 33554860, ; type_token_id
		i32 323; java_map_index
	}, 
	; 134
	%struct.TypeMapModuleEntry {
		i32 33554861, ; type_token_id
		i32 216; java_map_index
	}, 
	; 135
	%struct.TypeMapModuleEntry {
		i32 33554864, ; type_token_id
		i32 342; java_map_index
	}, 
	; 136
	%struct.TypeMapModuleEntry {
		i32 33554869, ; type_token_id
		i32 413; java_map_index
	}, 
	; 137
	%struct.TypeMapModuleEntry {
		i32 33554870, ; type_token_id
		i32 382; java_map_index
	}, 
	; 138
	%struct.TypeMapModuleEntry {
		i32 33554872, ; type_token_id
		i32 551; java_map_index
	}, 
	; 139
	%struct.TypeMapModuleEntry {
		i32 33554874, ; type_token_id
		i32 399; java_map_index
	}, 
	; 140
	%struct.TypeMapModuleEntry {
		i32 33554875, ; type_token_id
		i32 157; java_map_index
	}, 
	; 141
	%struct.TypeMapModuleEntry {
		i32 33554877, ; type_token_id
		i32 108; java_map_index
	}, 
	; 142
	%struct.TypeMapModuleEntry {
		i32 33554881, ; type_token_id
		i32 337; java_map_index
	}, 
	; 143
	%struct.TypeMapModuleEntry {
		i32 33554882, ; type_token_id
		i32 228; java_map_index
	}, 
	; 144
	%struct.TypeMapModuleEntry {
		i32 33554886, ; type_token_id
		i32 423; java_map_index
	}, 
	; 145
	%struct.TypeMapModuleEntry {
		i32 33554889, ; type_token_id
		i32 450; java_map_index
	}, 
	; 146
	%struct.TypeMapModuleEntry {
		i32 33554890, ; type_token_id
		i32 460; java_map_index
	}, 
	; 147
	%struct.TypeMapModuleEntry {
		i32 33554892, ; type_token_id
		i32 606; java_map_index
	}, 
	; 148
	%struct.TypeMapModuleEntry {
		i32 33554893, ; type_token_id
		i32 76; java_map_index
	}, 
	; 149
	%struct.TypeMapModuleEntry {
		i32 33554894, ; type_token_id
		i32 519; java_map_index
	}, 
	; 150
	%struct.TypeMapModuleEntry {
		i32 33554897, ; type_token_id
		i32 156; java_map_index
	}, 
	; 151
	%struct.TypeMapModuleEntry {
		i32 33554900, ; type_token_id
		i32 207; java_map_index
	}, 
	; 152
	%struct.TypeMapModuleEntry {
		i32 33554901, ; type_token_id
		i32 146; java_map_index
	}, 
	; 153
	%struct.TypeMapModuleEntry {
		i32 33554903, ; type_token_id
		i32 213; java_map_index
	}, 
	; 154
	%struct.TypeMapModuleEntry {
		i32 33554906, ; type_token_id
		i32 600; java_map_index
	}, 
	; 155
	%struct.TypeMapModuleEntry {
		i32 33554908, ; type_token_id
		i32 181; java_map_index
	}, 
	; 156
	%struct.TypeMapModuleEntry {
		i32 33554911, ; type_token_id
		i32 44; java_map_index
	}, 
	; 157
	%struct.TypeMapModuleEntry {
		i32 33554914, ; type_token_id
		i32 297; java_map_index
	}, 
	; 158
	%struct.TypeMapModuleEntry {
		i32 33554916, ; type_token_id
		i32 244; java_map_index
	}, 
	; 159
	%struct.TypeMapModuleEntry {
		i32 33554918, ; type_token_id
		i32 338; java_map_index
	}, 
	; 160
	%struct.TypeMapModuleEntry {
		i32 33554920, ; type_token_id
		i32 234; java_map_index
	}, 
	; 161
	%struct.TypeMapModuleEntry {
		i32 33554922, ; type_token_id
		i32 326; java_map_index
	}, 
	; 162
	%struct.TypeMapModuleEntry {
		i32 33554925, ; type_token_id
		i32 38; java_map_index
	}, 
	; 163
	%struct.TypeMapModuleEntry {
		i32 33554926, ; type_token_id
		i32 188; java_map_index
	}, 
	; 164
	%struct.TypeMapModuleEntry {
		i32 33554927, ; type_token_id
		i32 36; java_map_index
	}, 
	; 165
	%struct.TypeMapModuleEntry {
		i32 33554928, ; type_token_id
		i32 598; java_map_index
	}, 
	; 166
	%struct.TypeMapModuleEntry {
		i32 33554929, ; type_token_id
		i32 421; java_map_index
	}, 
	; 167
	%struct.TypeMapModuleEntry {
		i32 33554931, ; type_token_id
		i32 161; java_map_index
	}, 
	; 168
	%struct.TypeMapModuleEntry {
		i32 33554932, ; type_token_id
		i32 45; java_map_index
	}, 
	; 169
	%struct.TypeMapModuleEntry {
		i32 33554934, ; type_token_id
		i32 419; java_map_index
	}, 
	; 170
	%struct.TypeMapModuleEntry {
		i32 33554936, ; type_token_id
		i32 7; java_map_index
	}, 
	; 171
	%struct.TypeMapModuleEntry {
		i32 33554938, ; type_token_id
		i32 570; java_map_index
	}, 
	; 172
	%struct.TypeMapModuleEntry {
		i32 33554940, ; type_token_id
		i32 229; java_map_index
	}, 
	; 173
	%struct.TypeMapModuleEntry {
		i32 33554942, ; type_token_id
		i32 251; java_map_index
	}, 
	; 174
	%struct.TypeMapModuleEntry {
		i32 33554944, ; type_token_id
		i32 576; java_map_index
	}, 
	; 175
	%struct.TypeMapModuleEntry {
		i32 33554946, ; type_token_id
		i32 233; java_map_index
	}, 
	; 176
	%struct.TypeMapModuleEntry {
		i32 33554947, ; type_token_id
		i32 64; java_map_index
	}, 
	; 177
	%struct.TypeMapModuleEntry {
		i32 33554949, ; type_token_id
		i32 283; java_map_index
	}, 
	; 178
	%struct.TypeMapModuleEntry {
		i32 33554951, ; type_token_id
		i32 149; java_map_index
	}, 
	; 179
	%struct.TypeMapModuleEntry {
		i32 33554953, ; type_token_id
		i32 70; java_map_index
	}, 
	; 180
	%struct.TypeMapModuleEntry {
		i32 33554954, ; type_token_id
		i32 293; java_map_index
	}, 
	; 181
	%struct.TypeMapModuleEntry {
		i32 33554955, ; type_token_id
		i32 219; java_map_index
	}, 
	; 182
	%struct.TypeMapModuleEntry {
		i32 33554958, ; type_token_id
		i32 375; java_map_index
	}, 
	; 183
	%struct.TypeMapModuleEntry {
		i32 33554959, ; type_token_id
		i32 107; java_map_index
	}, 
	; 184
	%struct.TypeMapModuleEntry {
		i32 33554960, ; type_token_id
		i32 556; java_map_index
	}, 
	; 185
	%struct.TypeMapModuleEntry {
		i32 33554961, ; type_token_id
		i32 65; java_map_index
	}, 
	; 186
	%struct.TypeMapModuleEntry {
		i32 33554962, ; type_token_id
		i32 123; java_map_index
	}, 
	; 187
	%struct.TypeMapModuleEntry {
		i32 33554963, ; type_token_id
		i32 262; java_map_index
	}, 
	; 188
	%struct.TypeMapModuleEntry {
		i32 33554965, ; type_token_id
		i32 11; java_map_index
	}, 
	; 189
	%struct.TypeMapModuleEntry {
		i32 33554966, ; type_token_id
		i32 546; java_map_index
	}, 
	; 190
	%struct.TypeMapModuleEntry {
		i32 33554967, ; type_token_id
		i32 328; java_map_index
	}, 
	; 191
	%struct.TypeMapModuleEntry {
		i32 33554969, ; type_token_id
		i32 299; java_map_index
	}, 
	; 192
	%struct.TypeMapModuleEntry {
		i32 33554971, ; type_token_id
		i32 162; java_map_index
	}, 
	; 193
	%struct.TypeMapModuleEntry {
		i32 33554973, ; type_token_id
		i32 140; java_map_index
	}, 
	; 194
	%struct.TypeMapModuleEntry {
		i32 33554975, ; type_token_id
		i32 261; java_map_index
	}, 
	; 195
	%struct.TypeMapModuleEntry {
		i32 33554977, ; type_token_id
		i32 411; java_map_index
	}, 
	; 196
	%struct.TypeMapModuleEntry {
		i32 33554978, ; type_token_id
		i32 491; java_map_index
	}, 
	; 197
	%struct.TypeMapModuleEntry {
		i32 33554980, ; type_token_id
		i32 468; java_map_index
	}, 
	; 198
	%struct.TypeMapModuleEntry {
		i32 33554981, ; type_token_id
		i32 131; java_map_index
	}, 
	; 199
	%struct.TypeMapModuleEntry {
		i32 33554982, ; type_token_id
		i32 619; java_map_index
	}, 
	; 200
	%struct.TypeMapModuleEntry {
		i32 33554983, ; type_token_id
		i32 518; java_map_index
	}, 
	; 201
	%struct.TypeMapModuleEntry {
		i32 33554986, ; type_token_id
		i32 167; java_map_index
	}, 
	; 202
	%struct.TypeMapModuleEntry {
		i32 33554988, ; type_token_id
		i32 14; java_map_index
	}, 
	; 203
	%struct.TypeMapModuleEntry {
		i32 33554989, ; type_token_id
		i32 506; java_map_index
	}, 
	; 204
	%struct.TypeMapModuleEntry {
		i32 33554991, ; type_token_id
		i32 371; java_map_index
	}, 
	; 205
	%struct.TypeMapModuleEntry {
		i32 33554992, ; type_token_id
		i32 294; java_map_index
	}, 
	; 206
	%struct.TypeMapModuleEntry {
		i32 33554994, ; type_token_id
		i32 547; java_map_index
	}, 
	; 207
	%struct.TypeMapModuleEntry {
		i32 33554995, ; type_token_id
		i32 260; java_map_index
	}, 
	; 208
	%struct.TypeMapModuleEntry {
		i32 33554996, ; type_token_id
		i32 152; java_map_index
	}, 
	; 209
	%struct.TypeMapModuleEntry {
		i32 33554999, ; type_token_id
		i32 604; java_map_index
	}, 
	; 210
	%struct.TypeMapModuleEntry {
		i32 33555003, ; type_token_id
		i32 472; java_map_index
	}, 
	; 211
	%struct.TypeMapModuleEntry {
		i32 33555005, ; type_token_id
		i32 580; java_map_index
	}, 
	; 212
	%struct.TypeMapModuleEntry {
		i32 33555006, ; type_token_id
		i32 319; java_map_index
	}, 
	; 213
	%struct.TypeMapModuleEntry {
		i32 33555007, ; type_token_id
		i32 538; java_map_index
	}, 
	; 214
	%struct.TypeMapModuleEntry {
		i32 33555008, ; type_token_id
		i32 317; java_map_index
	}, 
	; 215
	%struct.TypeMapModuleEntry {
		i32 33555010, ; type_token_id
		i32 567; java_map_index
	}, 
	; 216
	%struct.TypeMapModuleEntry {
		i32 33555011, ; type_token_id
		i32 43; java_map_index
	}, 
	; 217
	%struct.TypeMapModuleEntry {
		i32 33555012, ; type_token_id
		i32 440; java_map_index
	}, 
	; 218
	%struct.TypeMapModuleEntry {
		i32 33555013, ; type_token_id
		i32 237; java_map_index
	}, 
	; 219
	%struct.TypeMapModuleEntry {
		i32 33555014, ; type_token_id
		i32 569; java_map_index
	}, 
	; 220
	%struct.TypeMapModuleEntry {
		i32 33555015, ; type_token_id
		i32 445; java_map_index
	}, 
	; 221
	%struct.TypeMapModuleEntry {
		i32 33555016, ; type_token_id
		i32 378; java_map_index
	}, 
	; 222
	%struct.TypeMapModuleEntry {
		i32 33555017, ; type_token_id
		i32 464; java_map_index
	}, 
	; 223
	%struct.TypeMapModuleEntry {
		i32 33555019, ; type_token_id
		i32 327; java_map_index
	}, 
	; 224
	%struct.TypeMapModuleEntry {
		i32 33555020, ; type_token_id
		i32 513; java_map_index
	}, 
	; 225
	%struct.TypeMapModuleEntry {
		i32 33555022, ; type_token_id
		i32 217; java_map_index
	}, 
	; 226
	%struct.TypeMapModuleEntry {
		i32 33555023, ; type_token_id
		i32 492; java_map_index
	}, 
	; 227
	%struct.TypeMapModuleEntry {
		i32 33555024, ; type_token_id
		i32 159; java_map_index
	}, 
	; 228
	%struct.TypeMapModuleEntry {
		i32 33555026, ; type_token_id
		i32 61; java_map_index
	}, 
	; 229
	%struct.TypeMapModuleEntry {
		i32 33555027, ; type_token_id
		i32 277; java_map_index
	}, 
	; 230
	%struct.TypeMapModuleEntry {
		i32 33555029, ; type_token_id
		i32 403; java_map_index
	}, 
	; 231
	%struct.TypeMapModuleEntry {
		i32 33555030, ; type_token_id
		i32 215; java_map_index
	}, 
	; 232
	%struct.TypeMapModuleEntry {
		i32 33555032, ; type_token_id
		i32 79; java_map_index
	}, 
	; 233
	%struct.TypeMapModuleEntry {
		i32 33555034, ; type_token_id
		i32 612; java_map_index
	}, 
	; 234
	%struct.TypeMapModuleEntry {
		i32 33555035, ; type_token_id
		i32 72; java_map_index
	}, 
	; 235
	%struct.TypeMapModuleEntry {
		i32 33555036, ; type_token_id
		i32 276; java_map_index
	}, 
	; 236
	%struct.TypeMapModuleEntry {
		i32 33555039, ; type_token_id
		i32 539; java_map_index
	}, 
	; 237
	%struct.TypeMapModuleEntry {
		i32 33555044, ; type_token_id
		i32 51; java_map_index
	}, 
	; 238
	%struct.TypeMapModuleEntry {
		i32 33555046, ; type_token_id
		i32 31; java_map_index
	}, 
	; 239
	%struct.TypeMapModuleEntry {
		i32 33555049, ; type_token_id
		i32 418; java_map_index
	}, 
	; 240
	%struct.TypeMapModuleEntry {
		i32 33555051, ; type_token_id
		i32 461; java_map_index
	}, 
	; 241
	%struct.TypeMapModuleEntry {
		i32 33555053, ; type_token_id
		i32 369; java_map_index
	}, 
	; 242
	%struct.TypeMapModuleEntry {
		i32 33555055, ; type_token_id
		i32 168; java_map_index
	}, 
	; 243
	%struct.TypeMapModuleEntry {
		i32 33555056, ; type_token_id
		i32 345; java_map_index
	}, 
	; 244
	%struct.TypeMapModuleEntry {
		i32 33555057, ; type_token_id
		i32 444; java_map_index
	}, 
	; 245
	%struct.TypeMapModuleEntry {
		i32 33555058, ; type_token_id
		i32 435; java_map_index
	}, 
	; 246
	%struct.TypeMapModuleEntry {
		i32 33555059, ; type_token_id
		i32 564; java_map_index
	}, 
	; 247
	%struct.TypeMapModuleEntry {
		i32 33555060, ; type_token_id
		i32 494; java_map_index
	}, 
	; 248
	%struct.TypeMapModuleEntry {
		i32 33555062, ; type_token_id
		i32 132; java_map_index
	}, 
	; 249
	%struct.TypeMapModuleEntry {
		i32 33555064, ; type_token_id
		i32 256; java_map_index
	}, 
	; 250
	%struct.TypeMapModuleEntry {
		i32 33555065, ; type_token_id
		i32 134; java_map_index
	}, 
	; 251
	%struct.TypeMapModuleEntry {
		i32 33555074, ; type_token_id
		i32 540; java_map_index
	}, 
	; 252
	%struct.TypeMapModuleEntry {
		i32 33555075, ; type_token_id
		i32 86; java_map_index
	}, 
	; 253
	%struct.TypeMapModuleEntry {
		i32 33555081, ; type_token_id
		i32 426; java_map_index
	}, 
	; 254
	%struct.TypeMapModuleEntry {
		i32 33555082, ; type_token_id
		i32 407; java_map_index
	}, 
	; 255
	%struct.TypeMapModuleEntry {
		i32 33555084, ; type_token_id
		i32 307; java_map_index
	}, 
	; 256
	%struct.TypeMapModuleEntry {
		i32 33555087, ; type_token_id
		i32 404; java_map_index
	}, 
	; 257
	%struct.TypeMapModuleEntry {
		i32 33555088, ; type_token_id
		i32 120; java_map_index
	}, 
	; 258
	%struct.TypeMapModuleEntry {
		i32 33555090, ; type_token_id
		i32 173; java_map_index
	}, 
	; 259
	%struct.TypeMapModuleEntry {
		i32 33555092, ; type_token_id
		i32 438; java_map_index
	}, 
	; 260
	%struct.TypeMapModuleEntry {
		i32 33555094, ; type_token_id
		i32 301; java_map_index
	}, 
	; 261
	%struct.TypeMapModuleEntry {
		i32 33555095, ; type_token_id
		i32 406; java_map_index
	}, 
	; 262
	%struct.TypeMapModuleEntry {
		i32 33555097, ; type_token_id
		i32 62; java_map_index
	}, 
	; 263
	%struct.TypeMapModuleEntry {
		i32 33555099, ; type_token_id
		i32 454; java_map_index
	}, 
	; 264
	%struct.TypeMapModuleEntry {
		i32 33555101, ; type_token_id
		i32 291; java_map_index
	}, 
	; 265
	%struct.TypeMapModuleEntry {
		i32 33555102, ; type_token_id
		i32 561; java_map_index
	}, 
	; 266
	%struct.TypeMapModuleEntry {
		i32 33555105, ; type_token_id
		i32 26; java_map_index
	}, 
	; 267
	%struct.TypeMapModuleEntry {
		i32 33555106, ; type_token_id
		i32 164; java_map_index
	}, 
	; 268
	%struct.TypeMapModuleEntry {
		i32 33555108, ; type_token_id
		i32 515; java_map_index
	}, 
	; 269
	%struct.TypeMapModuleEntry {
		i32 33555109, ; type_token_id
		i32 139; java_map_index
	}, 
	; 270
	%struct.TypeMapModuleEntry {
		i32 33555111, ; type_token_id
		i32 117; java_map_index
	}, 
	; 271
	%struct.TypeMapModuleEntry {
		i32 33555112, ; type_token_id
		i32 447; java_map_index
	}, 
	; 272
	%struct.TypeMapModuleEntry {
		i32 33555114, ; type_token_id
		i32 583; java_map_index
	}, 
	; 273
	%struct.TypeMapModuleEntry {
		i32 33555117, ; type_token_id
		i32 226; java_map_index
	}, 
	; 274
	%struct.TypeMapModuleEntry {
		i32 33555119, ; type_token_id
		i32 264; java_map_index
	}, 
	; 275
	%struct.TypeMapModuleEntry {
		i32 33555120, ; type_token_id
		i32 143; java_map_index
	}, 
	; 276
	%struct.TypeMapModuleEntry {
		i32 33555123, ; type_token_id
		i32 430; java_map_index
	}, 
	; 277
	%struct.TypeMapModuleEntry {
		i32 33555124, ; type_token_id
		i32 509; java_map_index
	}, 
	; 278
	%struct.TypeMapModuleEntry {
		i32 33555125, ; type_token_id
		i32 361; java_map_index
	}, 
	; 279
	%struct.TypeMapModuleEntry {
		i32 33555126, ; type_token_id
		i32 310; java_map_index
	}, 
	; 280
	%struct.TypeMapModuleEntry {
		i32 33555129, ; type_token_id
		i32 410; java_map_index
	}, 
	; 281
	%struct.TypeMapModuleEntry {
		i32 33555130, ; type_token_id
		i32 175; java_map_index
	}, 
	; 282
	%struct.TypeMapModuleEntry {
		i32 33555131, ; type_token_id
		i32 281; java_map_index
	}, 
	; 283
	%struct.TypeMapModuleEntry {
		i32 33555153, ; type_token_id
		i32 568; java_map_index
	}, 
	; 284
	%struct.TypeMapModuleEntry {
		i32 33555155, ; type_token_id
		i32 388; java_map_index
	}, 
	; 285
	%struct.TypeMapModuleEntry {
		i32 33555157, ; type_token_id
		i32 621; java_map_index
	}, 
	; 286
	%struct.TypeMapModuleEntry {
		i32 33555159, ; type_token_id
		i32 279; java_map_index
	}, 
	; 287
	%struct.TypeMapModuleEntry {
		i32 33555168, ; type_token_id
		i32 390; java_map_index
	}, 
	; 288
	%struct.TypeMapModuleEntry {
		i32 33555170, ; type_token_id
		i32 566; java_map_index
	}, 
	; 289
	%struct.TypeMapModuleEntry {
		i32 33555172, ; type_token_id
		i32 53; java_map_index
	}, 
	; 290
	%struct.TypeMapModuleEntry {
		i32 33555173, ; type_token_id
		i32 48; java_map_index
	}, 
	; 291
	%struct.TypeMapModuleEntry {
		i32 33555189, ; type_token_id
		i32 479; java_map_index
	}, 
	; 292
	%struct.TypeMapModuleEntry {
		i32 33555202, ; type_token_id
		i32 548; java_map_index
	}, 
	; 293
	%struct.TypeMapModuleEntry {
		i32 33555203, ; type_token_id
		i32 402; java_map_index
	}, 
	; 294
	%struct.TypeMapModuleEntry {
		i32 33555204, ; type_token_id
		i32 258; java_map_index
	}, 
	; 295
	%struct.TypeMapModuleEntry {
		i32 33555205, ; type_token_id
		i32 22; java_map_index
	}, 
	; 296
	%struct.TypeMapModuleEntry {
		i32 33555207, ; type_token_id
		i32 611; java_map_index
	}, 
	; 297
	%struct.TypeMapModuleEntry {
		i32 33555209, ; type_token_id
		i32 50; java_map_index
	}, 
	; 298
	%struct.TypeMapModuleEntry {
		i32 33555211, ; type_token_id
		i32 94; java_map_index
	}, 
	; 299
	%struct.TypeMapModuleEntry {
		i32 33555213, ; type_token_id
		i32 145; java_map_index
	}, 
	; 300
	%struct.TypeMapModuleEntry {
		i32 33555214, ; type_token_id
		i32 60; java_map_index
	}, 
	; 301
	%struct.TypeMapModuleEntry {
		i32 33555215, ; type_token_id
		i32 74; java_map_index
	}, 
	; 302
	%struct.TypeMapModuleEntry {
		i32 33555216, ; type_token_id
		i32 595; java_map_index
	}, 
	; 303
	%struct.TypeMapModuleEntry {
		i32 33555217, ; type_token_id
		i32 174; java_map_index
	}, 
	; 304
	%struct.TypeMapModuleEntry {
		i32 33555219, ; type_token_id
		i32 151; java_map_index
	}, 
	; 305
	%struct.TypeMapModuleEntry {
		i32 33555221, ; type_token_id
		i32 544; java_map_index
	}, 
	; 306
	%struct.TypeMapModuleEntry {
		i32 33555222, ; type_token_id
		i32 427; java_map_index
	}, 
	; 307
	%struct.TypeMapModuleEntry {
		i32 33555223, ; type_token_id
		i32 463; java_map_index
	}, 
	; 308
	%struct.TypeMapModuleEntry {
		i32 33555224, ; type_token_id
		i32 4; java_map_index
	}, 
	; 309
	%struct.TypeMapModuleEntry {
		i32 33555225, ; type_token_id
		i32 341; java_map_index
	}, 
	; 310
	%struct.TypeMapModuleEntry {
		i32 33555226, ; type_token_id
		i32 222; java_map_index
	}, 
	; 311
	%struct.TypeMapModuleEntry {
		i32 33555228, ; type_token_id
		i32 588; java_map_index
	}, 
	; 312
	%struct.TypeMapModuleEntry {
		i32 33555230, ; type_token_id
		i32 55; java_map_index
	}, 
	; 313
	%struct.TypeMapModuleEntry {
		i32 33555232, ; type_token_id
		i32 373; java_map_index
	}, 
	; 314
	%struct.TypeMapModuleEntry {
		i32 33555233, ; type_token_id
		i32 324; java_map_index
	}, 
	; 315
	%struct.TypeMapModuleEntry {
		i32 33555235, ; type_token_id
		i32 591; java_map_index
	}, 
	; 316
	%struct.TypeMapModuleEntry {
		i32 33555236, ; type_token_id
		i32 537; java_map_index
	}, 
	; 317
	%struct.TypeMapModuleEntry {
		i32 33555238, ; type_token_id
		i32 169; java_map_index
	}, 
	; 318
	%struct.TypeMapModuleEntry {
		i32 33555240, ; type_token_id
		i32 98; java_map_index
	}, 
	; 319
	%struct.TypeMapModuleEntry {
		i32 33555241, ; type_token_id
		i32 392; java_map_index
	}, 
	; 320
	%struct.TypeMapModuleEntry {
		i32 33555243, ; type_token_id
		i32 224; java_map_index
	}, 
	; 321
	%struct.TypeMapModuleEntry {
		i32 33555244, ; type_token_id
		i32 416; java_map_index
	}, 
	; 322
	%struct.TypeMapModuleEntry {
		i32 33555246, ; type_token_id
		i32 446; java_map_index
	}, 
	; 323
	%struct.TypeMapModuleEntry {
		i32 33555248, ; type_token_id
		i32 596; java_map_index
	}, 
	; 324
	%struct.TypeMapModuleEntry {
		i32 33555249, ; type_token_id
		i32 141; java_map_index
	}, 
	; 325
	%struct.TypeMapModuleEntry {
		i32 33555252, ; type_token_id
		i32 560; java_map_index
	}, 
	; 326
	%struct.TypeMapModuleEntry {
		i32 33555255, ; type_token_id
		i32 209; java_map_index
	}, 
	; 327
	%struct.TypeMapModuleEntry {
		i32 33555257, ; type_token_id
		i32 73; java_map_index
	}, 
	; 328
	%struct.TypeMapModuleEntry {
		i32 33555259, ; type_token_id
		i32 471; java_map_index
	}, 
	; 329
	%struct.TypeMapModuleEntry {
		i32 33555261, ; type_token_id
		i32 545; java_map_index
	}, 
	; 330
	%struct.TypeMapModuleEntry {
		i32 33555263, ; type_token_id
		i32 133; java_map_index
	}, 
	; 331
	%struct.TypeMapModuleEntry {
		i32 33555265, ; type_token_id
		i32 71; java_map_index
	}, 
	; 332
	%struct.TypeMapModuleEntry {
		i32 33555267, ; type_token_id
		i32 481; java_map_index
	}, 
	; 333
	%struct.TypeMapModuleEntry {
		i32 33555269, ; type_token_id
		i32 353; java_map_index
	}, 
	; 334
	%struct.TypeMapModuleEntry {
		i32 33555271, ; type_token_id
		i32 35; java_map_index
	}, 
	; 335
	%struct.TypeMapModuleEntry {
		i32 33555273, ; type_token_id
		i32 394; java_map_index
	}, 
	; 336
	%struct.TypeMapModuleEntry {
		i32 33555275, ; type_token_id
		i32 376; java_map_index
	}, 
	; 337
	%struct.TypeMapModuleEntry {
		i32 33555277, ; type_token_id
		i32 289; java_map_index
	}, 
	; 338
	%struct.TypeMapModuleEntry {
		i32 33555279, ; type_token_id
		i32 315; java_map_index
	}, 
	; 339
	%struct.TypeMapModuleEntry {
		i32 33555280, ; type_token_id
		i32 493; java_map_index
	}, 
	; 340
	%struct.TypeMapModuleEntry {
		i32 33555281, ; type_token_id
		i32 272; java_map_index
	}, 
	; 341
	%struct.TypeMapModuleEntry {
		i32 33555282, ; type_token_id
		i32 165; java_map_index
	}, 
	; 342
	%struct.TypeMapModuleEntry {
		i32 33555283, ; type_token_id
		i32 405; java_map_index
	}, 
	; 343
	%struct.TypeMapModuleEntry {
		i32 33555284, ; type_token_id
		i32 589; java_map_index
	}, 
	; 344
	%struct.TypeMapModuleEntry {
		i32 33555285, ; type_token_id
		i32 39; java_map_index
	}, 
	; 345
	%struct.TypeMapModuleEntry {
		i32 33555286, ; type_token_id
		i32 620; java_map_index
	}, 
	; 346
	%struct.TypeMapModuleEntry {
		i32 33555287, ; type_token_id
		i32 502; java_map_index
	}, 
	; 347
	%struct.TypeMapModuleEntry {
		i32 33555288, ; type_token_id
		i32 422; java_map_index
	}, 
	; 348
	%struct.TypeMapModuleEntry {
		i32 33555289, ; type_token_id
		i32 354; java_map_index
	}, 
	; 349
	%struct.TypeMapModuleEntry {
		i32 33555290, ; type_token_id
		i32 476; java_map_index
	}, 
	; 350
	%struct.TypeMapModuleEntry {
		i32 33555291, ; type_token_id
		i32 459; java_map_index
	}, 
	; 351
	%struct.TypeMapModuleEntry {
		i32 33555292, ; type_token_id
		i32 364; java_map_index
	}, 
	; 352
	%struct.TypeMapModuleEntry {
		i32 33555293, ; type_token_id
		i32 2; java_map_index
	}, 
	; 353
	%struct.TypeMapModuleEntry {
		i32 33555295, ; type_token_id
		i32 339; java_map_index
	}, 
	; 354
	%struct.TypeMapModuleEntry {
		i32 33555296, ; type_token_id
		i32 387; java_map_index
	}, 
	; 355
	%struct.TypeMapModuleEntry {
		i32 33555297, ; type_token_id
		i32 511; java_map_index
	}, 
	; 356
	%struct.TypeMapModuleEntry {
		i32 33555298, ; type_token_id
		i32 477; java_map_index
	}, 
	; 357
	%struct.TypeMapModuleEntry {
		i32 33555299, ; type_token_id
		i32 333; java_map_index
	}, 
	; 358
	%struct.TypeMapModuleEntry {
		i32 33555301, ; type_token_id
		i32 232; java_map_index
	}, 
	; 359
	%struct.TypeMapModuleEntry {
		i32 33555303, ; type_token_id
		i32 203; java_map_index
	}, 
	; 360
	%struct.TypeMapModuleEntry {
		i32 33555304, ; type_token_id
		i32 530; java_map_index
	}, 
	; 361
	%struct.TypeMapModuleEntry {
		i32 33555306, ; type_token_id
		i32 206; java_map_index
	}, 
	; 362
	%struct.TypeMapModuleEntry {
		i32 33555310, ; type_token_id
		i32 495; java_map_index
	}, 
	; 363
	%struct.TypeMapModuleEntry {
		i32 33555312, ; type_token_id
		i32 368; java_map_index
	}, 
	; 364
	%struct.TypeMapModuleEntry {
		i32 33555314, ; type_token_id
		i32 384; java_map_index
	}, 
	; 365
	%struct.TypeMapModuleEntry {
		i32 33555316, ; type_token_id
		i32 296; java_map_index
	}, 
	; 366
	%struct.TypeMapModuleEntry {
		i32 33555317, ; type_token_id
		i32 412; java_map_index
	}, 
	; 367
	%struct.TypeMapModuleEntry {
		i32 33555318, ; type_token_id
		i32 408; java_map_index
	}, 
	; 368
	%struct.TypeMapModuleEntry {
		i32 33555319, ; type_token_id
		i32 255; java_map_index
	}, 
	; 369
	%struct.TypeMapModuleEntry {
		i32 33555321, ; type_token_id
		i32 303; java_map_index
	}, 
	; 370
	%struct.TypeMapModuleEntry {
		i32 33555323, ; type_token_id
		i32 348; java_map_index
	}, 
	; 371
	%struct.TypeMapModuleEntry {
		i32 33555324, ; type_token_id
		i32 343; java_map_index
	}, 
	; 372
	%struct.TypeMapModuleEntry {
		i32 33555325, ; type_token_id
		i32 349; java_map_index
	}, 
	; 373
	%struct.TypeMapModuleEntry {
		i32 33555326, ; type_token_id
		i32 415; java_map_index
	}, 
	; 374
	%struct.TypeMapModuleEntry {
		i32 33555328, ; type_token_id
		i32 590; java_map_index
	}, 
	; 375
	%struct.TypeMapModuleEntry {
		i32 33555329, ; type_token_id
		i32 344; java_map_index
	}, 
	; 376
	%struct.TypeMapModuleEntry {
		i32 33555330, ; type_token_id
		i32 359; java_map_index
	}, 
	; 377
	%struct.TypeMapModuleEntry {
		i32 33555331, ; type_token_id
		i32 202; java_map_index
	}, 
	; 378
	%struct.TypeMapModuleEntry {
		i32 33555333, ; type_token_id
		i32 467; java_map_index
	}, 
	; 379
	%struct.TypeMapModuleEntry {
		i32 33555335, ; type_token_id
		i32 265; java_map_index
	}, 
	; 380
	%struct.TypeMapModuleEntry {
		i32 33555337, ; type_token_id
		i32 32; java_map_index
	}, 
	; 381
	%struct.TypeMapModuleEntry {
		i32 33555339, ; type_token_id
		i32 565; java_map_index
	}, 
	; 382
	%struct.TypeMapModuleEntry {
		i32 33555341, ; type_token_id
		i32 102; java_map_index
	}, 
	; 383
	%struct.TypeMapModuleEntry {
		i32 33555342, ; type_token_id
		i32 267; java_map_index
	}, 
	; 384
	%struct.TypeMapModuleEntry {
		i32 33555343, ; type_token_id
		i32 52; java_map_index
	}, 
	; 385
	%struct.TypeMapModuleEntry {
		i32 33555344, ; type_token_id
		i32 597; java_map_index
	}, 
	; 386
	%struct.TypeMapModuleEntry {
		i32 33555346, ; type_token_id
		i32 263; java_map_index
	}, 
	; 387
	%struct.TypeMapModuleEntry {
		i32 33555348, ; type_token_id
		i32 84; java_map_index
	}, 
	; 388
	%struct.TypeMapModuleEntry {
		i32 33555350, ; type_token_id
		i32 270; java_map_index
	}, 
	; 389
	%struct.TypeMapModuleEntry {
		i32 33555351, ; type_token_id
		i32 69; java_map_index
	}, 
	; 390
	%struct.TypeMapModuleEntry {
		i32 33555352, ; type_token_id
		i32 347; java_map_index
	}, 
	; 391
	%struct.TypeMapModuleEntry {
		i32 33555354, ; type_token_id
		i32 578; java_map_index
	}, 
	; 392
	%struct.TypeMapModuleEntry {
		i32 33555356, ; type_token_id
		i32 136; java_map_index
	}, 
	; 393
	%struct.TypeMapModuleEntry {
		i32 33555357, ; type_token_id
		i32 318; java_map_index
	}, 
	; 394
	%struct.TypeMapModuleEntry {
		i32 33555359, ; type_token_id
		i32 457; java_map_index
	}, 
	; 395
	%struct.TypeMapModuleEntry {
		i32 33555360, ; type_token_id
		i32 529; java_map_index
	}, 
	; 396
	%struct.TypeMapModuleEntry {
		i32 33555383, ; type_token_id
		i32 443; java_map_index
	}
], align 16; end of 'module7_managed_to_java' array


; module7_managed_to_java_duplicates
@module7_managed_to_java_duplicates = internal constant [199 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554599, ; type_token_id
		i32 517; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554603, ; type_token_id
		i32 153; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554605, ; type_token_id
		i32 231; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554607, ; type_token_id
		i32 191; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554609, ; type_token_id
		i32 25; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554611, ; type_token_id
		i32 516; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554613, ; type_token_id
		i32 322; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554615, ; type_token_id
		i32 248; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554617, ; type_token_id
		i32 535; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554619, ; type_token_id
		i32 543; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554621, ; type_token_id
		i32 357; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554625, ; type_token_id
		i32 617; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554628, ; type_token_id
		i32 236; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554630, ; type_token_id
		i32 363; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554632, ; type_token_id
		i32 420; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554644, ; type_token_id
		i32 18; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554646, ; type_token_id
		i32 528; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554650, ; type_token_id
		i32 470; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554652, ; type_token_id
		i32 584; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554654, ; type_token_id
		i32 184; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554658, ; type_token_id
		i32 366; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554661, ; type_token_id
		i32 89; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554664, ; type_token_id
		i32 432; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554666, ; type_token_id
		i32 56; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554668, ; type_token_id
		i32 522; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554669, ; type_token_id
		i32 137; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554673, ; type_token_id
		i32 128; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554676, ; type_token_id
		i32 505; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554680, ; type_token_id
		i32 332; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554681, ; type_token_id
		i32 137; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554683, ; type_token_id
		i32 618; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554684, ; type_token_id
		i32 618; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554689, ; type_token_id
		i32 474; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554690, ; type_token_id
		i32 386; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554694, ; type_token_id
		i32 579; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554695, ; type_token_id
		i32 424; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554700, ; type_token_id
		i32 230; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554702, ; type_token_id
		i32 336; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554704, ; type_token_id
		i32 274; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554709, ; type_token_id
		i32 23; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554711, ; type_token_id
		i32 150; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554724, ; type_token_id
		i32 433; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554727, ; type_token_id
		i32 33; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554731, ; type_token_id
		i32 163; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554737, ; type_token_id
		i32 218; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554739, ; type_token_id
		i32 462; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554742, ; type_token_id
		i32 306; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554744, ; type_token_id
		i32 271; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554746, ; type_token_id
		i32 436; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554750, ; type_token_id
		i32 365; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554754, ; type_token_id
		i32 483; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554764, ; type_token_id
		i32 431; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554767, ; type_token_id
		i32 183; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554769, ; type_token_id
		i32 311; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554773, ; type_token_id
		i32 105; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554775, ; type_token_id
		i32 321; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554777, ; type_token_id
		i32 49; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554779, ; type_token_id
		i32 241; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554782, ; type_token_id
		i32 249; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554785, ; type_token_id
		i32 182; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554786, ; type_token_id
		i32 240; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554789, ; type_token_id
		i32 19; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554797, ; type_token_id
		i32 613; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554799, ; type_token_id
		i32 609; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554802, ; type_token_id
		i32 116; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554804, ; type_token_id
		i32 286; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554806, ; type_token_id
		i32 198; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554809, ; type_token_id
		i32 187; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554811, ; type_token_id
		i32 305; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554813, ; type_token_id
		i32 147; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554816, ; type_token_id
		i32 129; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554818, ; type_token_id
		i32 82; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554820, ; type_token_id
		i32 101; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554822, ; type_token_id
		i32 148; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554824, ; type_token_id
		i32 437; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554826, ; type_token_id
		i32 95; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554828, ; type_token_id
		i32 442; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554830, ; type_token_id
		i32 486; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554833, ; type_token_id
		i32 358; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554837, ; type_token_id
		i32 316; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554847, ; type_token_id
		i32 59; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554862, ; type_token_id
		i32 216; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554863, ; type_token_id
		i32 573; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554866, ; type_token_id
		i32 106; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554871, ; type_token_id
		i32 382; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554873, ; type_token_id
		i32 551; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554876, ; type_token_id
		i32 157; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554887, ; type_token_id
		i32 423; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554891, ; type_token_id
		i32 460; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554895, ; type_token_id
		i32 519; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554898, ; type_token_id
		i32 156; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554902, ; type_token_id
		i32 146; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554904, ; type_token_id
		i32 213; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554907, ; type_token_id
		i32 600; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554909, ; type_token_id
		i32 181; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554912, ; type_token_id
		i32 44; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554915, ; type_token_id
		i32 297; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554917, ; type_token_id
		i32 244; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554923, ; type_token_id
		i32 326; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554930, ; type_token_id
		i32 421; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554933, ; type_token_id
		i32 45; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554935, ; type_token_id
		i32 419; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554937, ; type_token_id
		i32 7; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554939, ; type_token_id
		i32 570; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554941, ; type_token_id
		i32 229; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554943, ; type_token_id
		i32 251; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554945, ; type_token_id
		i32 576; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554948, ; type_token_id
		i32 64; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554950, ; type_token_id
		i32 283; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554952, ; type_token_id
		i32 149; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554956, ; type_token_id
		i32 219; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554968, ; type_token_id
		i32 328; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554970, ; type_token_id
		i32 299; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554972, ; type_token_id
		i32 162; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554974, ; type_token_id
		i32 140; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554976, ; type_token_id
		i32 261; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554985, ; type_token_id
		i32 556; java_map_index
	}, 
	; 117
	%struct.TypeMapModuleEntry {
		i32 33554987, ; type_token_id
		i32 167; java_map_index
	}, 
	; 118
	%struct.TypeMapModuleEntry {
		i32 33554990, ; type_token_id
		i32 506; java_map_index
	}, 
	; 119
	%struct.TypeMapModuleEntry {
		i32 33555021, ; type_token_id
		i32 513; java_map_index
	}, 
	; 120
	%struct.TypeMapModuleEntry {
		i32 33555025, ; type_token_id
		i32 327; java_map_index
	}, 
	; 121
	%struct.TypeMapModuleEntry {
		i32 33555031, ; type_token_id
		i32 215; java_map_index
	}, 
	; 122
	%struct.TypeMapModuleEntry {
		i32 33555033, ; type_token_id
		i32 79; java_map_index
	}, 
	; 123
	%struct.TypeMapModuleEntry {
		i32 33555037, ; type_token_id
		i32 276; java_map_index
	}, 
	; 124
	%struct.TypeMapModuleEntry {
		i32 33555043, ; type_token_id
		i32 403; java_map_index
	}, 
	; 125
	%struct.TypeMapModuleEntry {
		i32 33555045, ; type_token_id
		i32 51; java_map_index
	}, 
	; 126
	%struct.TypeMapModuleEntry {
		i32 33555047, ; type_token_id
		i32 31; java_map_index
	}, 
	; 127
	%struct.TypeMapModuleEntry {
		i32 33555052, ; type_token_id
		i32 461; java_map_index
	}, 
	; 128
	%struct.TypeMapModuleEntry {
		i32 33555054, ; type_token_id
		i32 369; java_map_index
	}, 
	; 129
	%struct.TypeMapModuleEntry {
		i32 33555063, ; type_token_id
		i32 132; java_map_index
	}, 
	; 130
	%struct.TypeMapModuleEntry {
		i32 33555076, ; type_token_id
		i32 86; java_map_index
	}, 
	; 131
	%struct.TypeMapModuleEntry {
		i32 33555078, ; type_token_id
		i32 418; java_map_index
	}, 
	; 132
	%struct.TypeMapModuleEntry {
		i32 33555083, ; type_token_id
		i32 407; java_map_index
	}, 
	; 133
	%struct.TypeMapModuleEntry {
		i32 33555091, ; type_token_id
		i32 173; java_map_index
	}, 
	; 134
	%struct.TypeMapModuleEntry {
		i32 33555093, ; type_token_id
		i32 404; java_map_index
	}, 
	; 135
	%struct.TypeMapModuleEntry {
		i32 33555096, ; type_token_id
		i32 406; java_map_index
	}, 
	; 136
	%struct.TypeMapModuleEntry {
		i32 33555098, ; type_token_id
		i32 62; java_map_index
	}, 
	; 137
	%struct.TypeMapModuleEntry {
		i32 33555100, ; type_token_id
		i32 454; java_map_index
	}, 
	; 138
	%struct.TypeMapModuleEntry {
		i32 33555103, ; type_token_id
		i32 561; java_map_index
	}, 
	; 139
	%struct.TypeMapModuleEntry {
		i32 33555107, ; type_token_id
		i32 164; java_map_index
	}, 
	; 140
	%struct.TypeMapModuleEntry {
		i32 33555110, ; type_token_id
		i32 139; java_map_index
	}, 
	; 141
	%struct.TypeMapModuleEntry {
		i32 33555121, ; type_token_id
		i32 143; java_map_index
	}, 
	; 142
	%struct.TypeMapModuleEntry {
		i32 33555127, ; type_token_id
		i32 430; java_map_index
	}, 
	; 143
	%struct.TypeMapModuleEntry {
		i32 33555158, ; type_token_id
		i32 621; java_map_index
	}, 
	; 144
	%struct.TypeMapModuleEntry {
		i32 33555164, ; type_token_id
		i32 279; java_map_index
	}, 
	; 145
	%struct.TypeMapModuleEntry {
		i32 33555169, ; type_token_id
		i32 390; java_map_index
	}, 
	; 146
	%struct.TypeMapModuleEntry {
		i32 33555174, ; type_token_id
		i32 48; java_map_index
	}, 
	; 147
	%struct.TypeMapModuleEntry {
		i32 33555206, ; type_token_id
		i32 22; java_map_index
	}, 
	; 148
	%struct.TypeMapModuleEntry {
		i32 33555208, ; type_token_id
		i32 611; java_map_index
	}, 
	; 149
	%struct.TypeMapModuleEntry {
		i32 33555212, ; type_token_id
		i32 94; java_map_index
	}, 
	; 150
	%struct.TypeMapModuleEntry {
		i32 33555218, ; type_token_id
		i32 174; java_map_index
	}, 
	; 151
	%struct.TypeMapModuleEntry {
		i32 33555220, ; type_token_id
		i32 151; java_map_index
	}, 
	; 152
	%struct.TypeMapModuleEntry {
		i32 33555227, ; type_token_id
		i32 222; java_map_index
	}, 
	; 153
	%struct.TypeMapModuleEntry {
		i32 33555229, ; type_token_id
		i32 588; java_map_index
	}, 
	; 154
	%struct.TypeMapModuleEntry {
		i32 33555231, ; type_token_id
		i32 55; java_map_index
	}, 
	; 155
	%struct.TypeMapModuleEntry {
		i32 33555234, ; type_token_id
		i32 324; java_map_index
	}, 
	; 156
	%struct.TypeMapModuleEntry {
		i32 33555237, ; type_token_id
		i32 537; java_map_index
	}, 
	; 157
	%struct.TypeMapModuleEntry {
		i32 33555239, ; type_token_id
		i32 169; java_map_index
	}, 
	; 158
	%struct.TypeMapModuleEntry {
		i32 33555242, ; type_token_id
		i32 392; java_map_index
	}, 
	; 159
	%struct.TypeMapModuleEntry {
		i32 33555245, ; type_token_id
		i32 416; java_map_index
	}, 
	; 160
	%struct.TypeMapModuleEntry {
		i32 33555247, ; type_token_id
		i32 446; java_map_index
	}, 
	; 161
	%struct.TypeMapModuleEntry {
		i32 33555251, ; type_token_id
		i32 596; java_map_index
	}, 
	; 162
	%struct.TypeMapModuleEntry {
		i32 33555253, ; type_token_id
		i32 560; java_map_index
	}, 
	; 163
	%struct.TypeMapModuleEntry {
		i32 33555254, ; type_token_id
		i32 141; java_map_index
	}, 
	; 164
	%struct.TypeMapModuleEntry {
		i32 33555256, ; type_token_id
		i32 209; java_map_index
	}, 
	; 165
	%struct.TypeMapModuleEntry {
		i32 33555258, ; type_token_id
		i32 73; java_map_index
	}, 
	; 166
	%struct.TypeMapModuleEntry {
		i32 33555260, ; type_token_id
		i32 471; java_map_index
	}, 
	; 167
	%struct.TypeMapModuleEntry {
		i32 33555262, ; type_token_id
		i32 545; java_map_index
	}, 
	; 168
	%struct.TypeMapModuleEntry {
		i32 33555264, ; type_token_id
		i32 133; java_map_index
	}, 
	; 169
	%struct.TypeMapModuleEntry {
		i32 33555266, ; type_token_id
		i32 71; java_map_index
	}, 
	; 170
	%struct.TypeMapModuleEntry {
		i32 33555268, ; type_token_id
		i32 481; java_map_index
	}, 
	; 171
	%struct.TypeMapModuleEntry {
		i32 33555270, ; type_token_id
		i32 353; java_map_index
	}, 
	; 172
	%struct.TypeMapModuleEntry {
		i32 33555272, ; type_token_id
		i32 35; java_map_index
	}, 
	; 173
	%struct.TypeMapModuleEntry {
		i32 33555274, ; type_token_id
		i32 394; java_map_index
	}, 
	; 174
	%struct.TypeMapModuleEntry {
		i32 33555276, ; type_token_id
		i32 376; java_map_index
	}, 
	; 175
	%struct.TypeMapModuleEntry {
		i32 33555278, ; type_token_id
		i32 289; java_map_index
	}, 
	; 176
	%struct.TypeMapModuleEntry {
		i32 33555300, ; type_token_id
		i32 333; java_map_index
	}, 
	; 177
	%struct.TypeMapModuleEntry {
		i32 33555302, ; type_token_id
		i32 232; java_map_index
	}, 
	; 178
	%struct.TypeMapModuleEntry {
		i32 33555305, ; type_token_id
		i32 530; java_map_index
	}, 
	; 179
	%struct.TypeMapModuleEntry {
		i32 33555307, ; type_token_id
		i32 206; java_map_index
	}, 
	; 180
	%struct.TypeMapModuleEntry {
		i32 33555308, ; type_token_id
		i32 502; java_map_index
	}, 
	; 181
	%struct.TypeMapModuleEntry {
		i32 33555311, ; type_token_id
		i32 495; java_map_index
	}, 
	; 182
	%struct.TypeMapModuleEntry {
		i32 33555313, ; type_token_id
		i32 368; java_map_index
	}, 
	; 183
	%struct.TypeMapModuleEntry {
		i32 33555315, ; type_token_id
		i32 384; java_map_index
	}, 
	; 184
	%struct.TypeMapModuleEntry {
		i32 33555320, ; type_token_id
		i32 255; java_map_index
	}, 
	; 185
	%struct.TypeMapModuleEntry {
		i32 33555322, ; type_token_id
		i32 303; java_map_index
	}, 
	; 186
	%struct.TypeMapModuleEntry {
		i32 33555327, ; type_token_id
		i32 415; java_map_index
	}, 
	; 187
	%struct.TypeMapModuleEntry {
		i32 33555332, ; type_token_id
		i32 202; java_map_index
	}, 
	; 188
	%struct.TypeMapModuleEntry {
		i32 33555334, ; type_token_id
		i32 467; java_map_index
	}, 
	; 189
	%struct.TypeMapModuleEntry {
		i32 33555336, ; type_token_id
		i32 265; java_map_index
	}, 
	; 190
	%struct.TypeMapModuleEntry {
		i32 33555338, ; type_token_id
		i32 32; java_map_index
	}, 
	; 191
	%struct.TypeMapModuleEntry {
		i32 33555340, ; type_token_id
		i32 565; java_map_index
	}, 
	; 192
	%struct.TypeMapModuleEntry {
		i32 33555345, ; type_token_id
		i32 597; java_map_index
	}, 
	; 193
	%struct.TypeMapModuleEntry {
		i32 33555347, ; type_token_id
		i32 263; java_map_index
	}, 
	; 194
	%struct.TypeMapModuleEntry {
		i32 33555349, ; type_token_id
		i32 84; java_map_index
	}, 
	; 195
	%struct.TypeMapModuleEntry {
		i32 33555353, ; type_token_id
		i32 347; java_map_index
	}, 
	; 196
	%struct.TypeMapModuleEntry {
		i32 33555355, ; type_token_id
		i32 578; java_map_index
	}, 
	; 197
	%struct.TypeMapModuleEntry {
		i32 33555358, ; type_token_id
		i32 318; java_map_index
	}, 
	; 198
	%struct.TypeMapModuleEntry {
		i32 33555361, ; type_token_id
		i32 529; java_map_index
	}
], align 16; end of 'module7_managed_to_java_duplicates' array


; module8_managed_to_java
@module8_managed_to_java = internal constant [12 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 377; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 96; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 92; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 572; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 489; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 196; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 449; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554444, ; type_token_id
		i32 536; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 245; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 555; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 57; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 389; java_map_index
	}
], align 16; end of 'module8_managed_to_java' array


; module8_managed_to_java_duplicates
@module8_managed_to_java_duplicates = internal constant [5 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 196; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 572; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 245; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554451, ; type_token_id
		i32 555; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554455, ; type_token_id
		i32 57; java_map_index
	}
], align 16; end of 'module8_managed_to_java_duplicates' array


; module9_managed_to_java
@module9_managed_to_java = internal constant [9 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 170; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 28; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 275; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 482; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 603; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 239; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 485; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 192; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 510; java_map_index
	}
], align 16; end of 'module9_managed_to_java' array


; module10_managed_to_java
@module10_managed_to_java = internal constant [5 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 534; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 247; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 340; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 533; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 531; java_map_index
	}
], align 16; end of 'module10_managed_to_java' array


; module11_managed_to_java
@module11_managed_to_java = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 104; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 587; java_map_index
	}
], align 16; end of 'module11_managed_to_java' array

; Map modules
@__TypeMapModule_assembly_name.0 = internal constant [31 x i8] c"Xamarin.Forms.Platform.Android\00", align 16
@__TypeMapModule_assembly_name.1 = internal constant [31 x i8] c"Xamarin.Android.Support.Compat\00", align 16
@__TypeMapModule_assembly_name.2 = internal constant [38 x i8] c"Xamarin.Android.Arch.Lifecycle.Common\00", align 16
@__TypeMapModule_assembly_name.3 = internal constant [32 x i8] c"Xamarin.Android.Support.Core.UI\00", align 16
@__TypeMapModule_assembly_name.4 = internal constant [36 x i8] c"Xamarin.Android.Support.v7.CardView\00", align 16
@__TypeMapModule_assembly_name.5 = internal constant [37 x i8] c"Xamarin.Android.Support.v7.AppCompat\00", align 16
@__TypeMapModule_assembly_name.6 = internal constant [28 x i8] c"ThreePointCheck_App.Android\00", align 16
@__TypeMapModule_assembly_name.7 = internal constant [13 x i8] c"Mono.Android\00", align 1
@__TypeMapModule_assembly_name.8 = internal constant [33 x i8] c"Xamarin.Android.Support.Fragment\00", align 16
@__TypeMapModule_assembly_name.9 = internal constant [31 x i8] c"Xamarin.Android.Support.Design\00", align 16
@__TypeMapModule_assembly_name.10 = internal constant [35 x i8] c"Xamarin.Android.Support.Core.Utils\00", align 16
@__TypeMapModule_assembly_name.11 = internal constant [15 x i8] c"FormsViewGroup\00", align 1

; map_modules
@map_modules = global [12 x %struct.TypeMapModule] [
	; 0
	%struct.TypeMapModule {
		[16 x i8] c"[mb\81\05*#J\BC!\D1\92\DFQ_\A9", ; module_uuid: 81626d5b-2a05-4a23-bc21-d192df515fa9
		i32 117, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([117 x %struct.TypeMapModuleEntry], [117 x %struct.TypeMapModuleEntry]* @module0_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__TypeMapModule_assembly_name.0, i32 0, i32 0), ; assembly_name: Xamarin.Forms.Platform.Android
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 1
	%struct.TypeMapModule {
		[16 x i8] c"|\15H\B5\01q'B\8B\9F\0B\B8\E5\C6\96]", ; module_uuid: b548157c-7101-4227-8b9f-0bb8e5c6965d
		i32 25, ; entry_count
		i32 2, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([25 x %struct.TypeMapModuleEntry], [25 x %struct.TypeMapModuleEntry]* @module1_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([2 x %struct.TypeMapModuleEntry], [2 x %struct.TypeMapModuleEntry]* @module1_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__TypeMapModule_assembly_name.1, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.Compat
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 2
	%struct.TypeMapModule {
		[16 x i8] c"\7FF\EE\8D\F8\CA\CEK\881r\0F;\09{o", ; module_uuid: 8dee467f-caf8-4bce-8831-720f3b097b6f
		i32 4, ; entry_count
		i32 1, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([4 x %struct.TypeMapModuleEntry], [4 x %struct.TypeMapModuleEntry]* @module2_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([1 x %struct.TypeMapModuleEntry], [1 x %struct.TypeMapModuleEntry]* @module2_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__TypeMapModule_assembly_name.2, i32 0, i32 0), ; assembly_name: Xamarin.Android.Arch.Lifecycle.Common
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 3
	%struct.TypeMapModule {
		[16 x i8] c"\8A1\1D\B5m4nI\9Fc\F5\CB\82\1F-\8E", ; module_uuid: b51d318a-346d-496e-9f63-f5cb821f2d8e
		i32 16, ; entry_count
		i32 1, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([16 x %struct.TypeMapModuleEntry], [16 x %struct.TypeMapModuleEntry]* @module3_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([1 x %struct.TypeMapModuleEntry], [1 x %struct.TypeMapModuleEntry]* @module3_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__TypeMapModule_assembly_name.3, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.Core.UI
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 4
	%struct.TypeMapModule {
		[16 x i8] c"\9BIHq\EBw\9DC\B2\B2\8F\8C\831\92m", ; module_uuid: 7148499b-77eb-439d-b2b2-8f8c8331926d
		i32 1, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([1 x %struct.TypeMapModuleEntry], [1 x %struct.TypeMapModuleEntry]* @module4_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__TypeMapModule_assembly_name.4, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.v7.CardView
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 5
	%struct.TypeMapModule {
		[16 x i8] c"\AC\982\96\99\1F\9DE\80\F1\EF\FBvP\0Cp", ; module_uuid: 963298ac-1f99-459d-80f1-effb76500c70
		i32 34, ; entry_count
		i32 4, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([34 x %struct.TypeMapModuleEntry], [34 x %struct.TypeMapModuleEntry]* @module5_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([4 x %struct.TypeMapModuleEntry], [4 x %struct.TypeMapModuleEntry]* @module5_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__TypeMapModule_assembly_name.5, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.v7.AppCompat
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 6
	%struct.TypeMapModule {
		[16 x i8] c"\AD\B1\DA\BD\A7\17nK\B0\1BR\A5\EC\03\D9\FD", ; module_uuid: bddab1ad-17a7-4b6e-b01b-52a5ec03d9fd
		i32 2, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([2 x %struct.TypeMapModuleEntry], [2 x %struct.TypeMapModuleEntry]* @module6_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__TypeMapModule_assembly_name.6, i32 0, i32 0), ; assembly_name: ThreePointCheck_App.Android
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 7
	%struct.TypeMapModule {
		[16 x i8] c"\B3\B2,\EE\A0\DA\A5H\A0\7Fl,f<\FFp", ; module_uuid: ee2cb2b3-daa0-48a5-a07f-6c2c663cff70
		i32 397, ; entry_count
		i32 199, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([397 x %struct.TypeMapModuleEntry], [397 x %struct.TypeMapModuleEntry]* @module7_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([199 x %struct.TypeMapModuleEntry], [199 x %struct.TypeMapModuleEntry]* @module7_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([13 x i8], [13 x i8]* @__TypeMapModule_assembly_name.7, i32 0, i32 0), ; assembly_name: Mono.Android
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 8
	%struct.TypeMapModule {
		[16 x i8] c"\C0\03Y\BDK|\8BM\8A\A6\8F'\F0\F6\CB\8A", ; module_uuid: bd5903c0-7c4b-4d8b-8aa6-8f27f0f6cb8a
		i32 12, ; entry_count
		i32 5, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([12 x %struct.TypeMapModuleEntry], [12 x %struct.TypeMapModuleEntry]* @module8_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* getelementptr inbounds ([5 x %struct.TypeMapModuleEntry], [5 x %struct.TypeMapModuleEntry]* @module8_managed_to_java_duplicates, i32 0, i32 0), ; duplicate_map
		i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__TypeMapModule_assembly_name.8, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.Fragment
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 9
	%struct.TypeMapModule {
		[16 x i8] c"\C70w\ACH\A8pL\BFl\AC\C2\B0\BE\9FY", ; module_uuid: ac7730c7-a848-4c70-bf6c-acc2b0be9f59
		i32 9, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([9 x %struct.TypeMapModuleEntry], [9 x %struct.TypeMapModuleEntry]* @module9_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__TypeMapModule_assembly_name.9, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.Design
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 10
	%struct.TypeMapModule {
		[16 x i8] c"\EAY\7F\0C\D0\0E3@\B5\B8\19\92\A5\10\86\93", ; module_uuid: 0c7f59ea-0ed0-4033-b5b8-1992a5108693
		i32 5, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([5 x %struct.TypeMapModuleEntry], [5 x %struct.TypeMapModuleEntry]* @module10_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__TypeMapModule_assembly_name.10, i32 0, i32 0), ; assembly_name: Xamarin.Android.Support.Core.Utils
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}, 
	; 11
	%struct.TypeMapModule {
		[16 x i8] c"\FE|)\1D\A9F^D\96Ud\D6w\EF\A8\B8", ; module_uuid: 1d297cfe-46a9-445e-9655-64d677efa8b8
		i32 2, ; entry_count
		i32 0, ; duplicate_count
		%struct.TypeMapModuleEntry* getelementptr inbounds ([2 x %struct.TypeMapModuleEntry], [2 x %struct.TypeMapModuleEntry]* @module11_managed_to_java, i32 0, i32 0), ; map
		%struct.TypeMapModuleEntry* null, ; duplicate_map
		i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__TypeMapModule_assembly_name.11, i32 0, i32 0), ; assembly_name: FormsViewGroup
		%struct.MonoImage* null, ; image
		i32 0, ; java_name_width
		i8* null; java_map
	}
], align 16; end of 'map_modules' array


; Java to managed map

; map_java
@map_java = local_unnamed_addr constant [624 x %struct.TypeMapJava] [
	; 0
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554637, ; type_token_id
		i32 14; java_name_index
	}, 
	; 1
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554449, ; type_token_id
		i32 153; java_name_index
	}, 
	; 2
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555293, ; type_token_id
		i32 551; java_name_index
	}, 
	; 3
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554486, ; type_token_id
		i32 19; java_name_index
	}, 
	; 4
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555224, ; type_token_id
		i32 507; java_name_index
	}, 
	; 5
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554569, ; type_token_id
		i32 80; java_name_index
	}, 
	; 6
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554630, ; type_token_id
		i32 8; java_name_index
	}, 
	; 7
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 369; java_name_index
	}, 
	; 8
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554435, ; type_token_id
		i32 143; java_name_index
	}, 
	; 9
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554685, ; type_token_id
		i32 241; java_name_index
	}, 
	; 10
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554472, ; type_token_id
		i32 187; java_name_index
	}, 
	; 11
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554965, ; type_token_id
		i32 387; java_name_index
	}, 
	; 12
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554674, ; type_token_id
		i32 236; java_name_index
	}, 
	; 13
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554708, ; type_token_id
		i32 104; java_name_index
	}, 
	; 14
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554988, ; type_token_id
		i32 401; java_name_index
	}, 
	; 15
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554549, ; type_token_id
		i32 56; java_name_index
	}, 
	; 16
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554478, ; type_token_id
		i32 140; java_name_index
	}, 
	; 17
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554671, ; type_token_id
		i32 234; java_name_index
	}, 
	; 18
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 219; java_name_index
	}, 
	; 19
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554788, ; type_token_id
		i32 301; java_name_index
	}, 
	; 20
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554443, ; type_token_id
		i32 168; java_name_index
	}, 
	; 21
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554570, ; type_token_id
		i32 81; java_name_index
	}, 
	; 22
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555205, ; type_token_id
		i32 494; java_name_index
	}, 
	; 23
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 256; java_name_index
	}, 
	; 24
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554463, ; type_token_id
		i32 130; java_name_index
	}, 
	; 25
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554608, ; type_token_id
		i32 205; java_name_index
	}, 
	; 26
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555105, ; type_token_id
		i32 465; java_name_index
	}, 
	; 27
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554770, ; type_token_id
		i32 291; java_name_index
	}, 
	; 28
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554436, ; type_token_id
		i32 609; java_name_index
	}, 
	; 29
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554504, ; type_token_id
		i32 28; java_name_index
	}, 
	; 30
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554500, ; type_token_id
		i32 26; java_name_index
	}, 
	; 31
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 437; java_name_index
	}, 
	; 32
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 579; java_name_index
	}, 
	; 33
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 269; java_name_index
	}, 
	; 34
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554568, ; type_token_id
		i32 79; java_name_index
	}, 
	; 35
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 533; java_name_index
	}, 
	; 36
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554927, ; type_token_id
		i32 363; java_name_index
	}, 
	; 37
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554729, ; type_token_id
		i32 271; java_name_index
	}, 
	; 38
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554925, ; type_token_id
		i32 361; java_name_index
	}, 
	; 39
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555285, ; type_token_id
		i32 543; java_name_index
	}, 
	; 40
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554518, ; type_token_id
		i32 37; java_name_index
	}, 
	; 41
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554473, ; type_token_id
		i32 137; java_name_index
	}, 
	; 42
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554602, ; type_token_id
		i32 97; java_name_index
	}, 
	; 43
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555011, ; type_token_id
		i32 415; java_name_index
	}, 
	; 44
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 355; java_name_index
	}, 
	; 45
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 367; java_name_index
	}, 
	; 46
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554542, ; type_token_id
		i32 49; java_name_index
	}, 
	; 47
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554488, ; type_token_id
		i32 195; java_name_index
	}, 
	; 48
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555173, ; type_token_id
		i32 489; java_name_index
	}, 
	; 49
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 295; java_name_index
	}, 
	; 50
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555209, ; type_token_id
		i32 496; java_name_index
	}, 
	; 51
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555044, ; type_token_id
		i32 436; java_name_index
	}, 
	; 52
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555343, ; type_token_id
		i32 583; java_name_index
	}, 
	; 53
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555172, ; type_token_id
		i32 488; java_name_index
	}, 
	; 54
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554524, ; type_token_id
		i32 41; java_name_index
	}, 
	; 55
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 511; java_name_index
	}, 
	; 56
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 231; java_name_index
	}, 
	; 57
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554452, ; type_token_id
		i32 606; java_name_index
	}, 
	; 58
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554484, ; type_token_id
		i32 192; java_name_index
	}, 
	; 59
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 325; java_name_index
	}, 
	; 60
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555214, ; type_token_id
		i32 499; java_name_index
	}, 
	; 61
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555026, ; type_token_id
		i32 427; java_name_index
	}, 
	; 62
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 461; java_name_index
	}, 
	; 63
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554624, ; type_token_id
		i32 1; java_name_index
	}, 
	; 64
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 375; java_name_index
	}, 
	; 65
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554961, ; type_token_id
		i32 384; java_name_index
	}, 
	; 66
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554438, ; type_token_id
		i32 119; java_name_index
	}, 
	; 67
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554481, ; type_token_id
		i32 17; java_name_index
	}, 
	; 68
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554622, ; type_token_id
		i32 0; java_name_index
	}, 
	; 69
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555351, ; type_token_id
		i32 588; java_name_index
	}, 
	; 70
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554953, ; type_token_id
		i32 378; java_name_index
	}, 
	; 71
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 530; java_name_index
	}, 
	; 72
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555035, ; type_token_id
		i32 433; java_name_index
	}, 
	; 73
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555257, ; type_token_id
		i32 526; java_name_index
	}, 
	; 74
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555215, ; type_token_id
		i32 500; java_name_index
	}, 
	; 75
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554711, ; type_token_id
		i32 108; java_name_index
	}, 
	; 76
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554893, ; type_token_id
		i32 347; java_name_index
	}, 
	; 77
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554464, ; type_token_id
		i32 10; java_name_index
	}, 
	; 78
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554585, ; type_token_id
		i32 91; java_name_index
	}, 
	; 79
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 431; java_name_index
	}, 
	; 80
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554496, ; type_token_id
		i32 21; java_name_index
	}, 
	; 81
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554840, ; type_token_id
		i32 323; java_name_index
	}, 
	; 82
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554817, ; type_token_id
		i32 314; java_name_index
	}, 
	; 83
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554600, ; type_token_id
		i32 201; java_name_index
	}, 
	; 84
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555348, ; type_token_id
		i32 586; java_name_index
	}, 
	; 85
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554466, ; type_token_id
		i32 11; java_name_index
	}, 
	; 86
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 451; java_name_index
	}, 
	; 87
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554735, ; type_token_id
		i32 275; java_name_index
	}, 
	; 88
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554645, ; type_token_id
		i32 24; java_name_index
	}, 
	; 89
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554659, ; type_token_id
		i32 228; java_name_index
	}, 
	; 90
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554606, ; type_token_id
		i32 100; java_name_index
	}, 
	; 91
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554650, ; type_token_id
		i32 31; java_name_index
	}, 
	; 92
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554436, ; type_token_id
		i32 598; java_name_index
	}, 
	; 93
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554597, ; type_token_id
		i32 94; java_name_index
	}, 
	; 94
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555211, ; type_token_id
		i32 497; java_name_index
	}, 
	; 95
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 318; java_name_index
	}, 
	; 96
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554435, ; type_token_id
		i32 597; java_name_index
	}, 
	; 97
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554666, ; type_token_id
		i32 53; java_name_index
	}, 
	; 98
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555240, ; type_token_id
		i32 517; java_name_index
	}, 
	; 99
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554684, ; type_token_id
		i32 82; java_name_index
	}, 
	; 100
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554533, ; type_token_id
		i32 43; java_name_index
	}, 
	; 101
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 315; java_name_index
	}, 
	; 102
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555341, ; type_token_id
		i32 581; java_name_index
	}, 
	; 103
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554541, ; type_token_id
		i32 48; java_name_index
	}, 
	; 104
	%struct.TypeMapJava {
		i32 11, ; module_index
		i32 33554434, ; type_token_id
		i32 622; java_name_index
	}, 
	; 105
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 293; java_name_index
	}, 
	; 106
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554780, ; type_token_id
		i32 297; java_name_index
	}, 
	; 107
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554959, ; type_token_id
		i32 382; java_name_index
	}, 
	; 108
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554877, ; type_token_id
		i32 340; java_name_index
	}, 
	; 109
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554462, ; type_token_id
		i32 129; java_name_index
	}, 
	; 110
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554719, ; type_token_id
		i32 263; java_name_index
	}, 
	; 111
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554469, ; type_token_id
		i32 134; java_name_index
	}, 
	; 112
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554685, ; type_token_id
		i32 84; java_name_index
	}, 
	; 113
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554676, ; type_token_id
		i32 65; java_name_index
	}, 
	; 114
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554468, ; type_token_id
		i32 159; java_name_index
	}, 
	; 115
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554612, ; type_token_id
		i32 111; java_name_index
	}, 
	; 116
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 307; java_name_index
	}, 
	; 117
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555111, ; type_token_id
		i32 469; java_name_index
	}, 
	; 118
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554454, ; type_token_id
		i32 4; java_name_index
	}, 
	; 119
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554466, ; type_token_id
		i32 132; java_name_index
	}, 
	; 120
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555088, ; type_token_id
		i32 456; java_name_index
	}, 
	; 121
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554441, ; type_token_id
		i32 167; java_name_index
	}, 
	; 122
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554634, ; type_token_id
		i32 12; java_name_index
	}, 
	; 123
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554962, ; type_token_id
		i32 385; java_name_index
	}, 
	; 124
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554448, ; type_token_id
		i32 171; java_name_index
	}, 
	; 125
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554462, ; type_token_id
		i32 156; java_name_index
	}, 
	; 126
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554467, ; type_token_id
		i32 184; java_name_index
	}, 
	; 127
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554721, ; type_token_id
		i32 265; java_name_index
	}, 
	; 128
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 235; java_name_index
	}, 
	; 129
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 313; java_name_index
	}, 
	; 130
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554460, ; type_token_id
		i32 178; java_name_index
	}, 
	; 131
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554981, ; type_token_id
		i32 397; java_name_index
	}, 
	; 132
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 447; java_name_index
	}, 
	; 133
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 529; java_name_index
	}, 
	; 134
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555065, ; type_token_id
		i32 449; java_name_index
	}, 
	; 135
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554482, ; type_token_id
		i32 18; java_name_index
	}, 
	; 136
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555356, ; type_token_id
		i32 591; java_name_index
	}, 
	; 137
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554662, ; type_token_id
		i32 229; java_name_index
	}, 
	; 138
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554499, ; type_token_id
		i32 23; java_name_index
	}, 
	; 139
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 468; java_name_index
	}, 
	; 140
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 392; java_name_index
	}, 
	; 141
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555249, ; type_token_id
		i32 523; java_name_index
	}, 
	; 142
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554445, ; type_token_id
		i32 169; java_name_index
	}, 
	; 143
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555120, ; type_token_id
		i32 474; java_name_index
	}, 
	; 144
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554636, ; type_token_id
		i32 13; java_name_index
	}, 
	; 145
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555213, ; type_token_id
		i32 498; java_name_index
	}, 
	; 146
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 351; java_name_index
	}, 
	; 147
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 312; java_name_index
	}, 
	; 148
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 316; java_name_index
	}, 
	; 149
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554951, ; type_token_id
		i32 377; java_name_index
	}, 
	; 150
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 257; java_name_index
	}, 
	; 151
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555219, ; type_token_id
		i32 503; java_name_index
	}, 
	; 152
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554996, ; type_token_id
		i32 407; java_name_index
	}, 
	; 153
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554602, ; type_token_id
		i32 202; java_name_index
	}, 
	; 154
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554519, ; type_token_id
		i32 38; java_name_index
	}, 
	; 155
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554465, ; type_token_id
		i32 182; java_name_index
	}, 
	; 156
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 349; java_name_index
	}, 
	; 157
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 339; java_name_index
	}, 
	; 158
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554552, ; type_token_id
		i32 59; java_name_index
	}, 
	; 159
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555024, ; type_token_id
		i32 426; java_name_index
	}, 
	; 160
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554690, ; type_token_id
		i32 88; java_name_index
	}, 
	; 161
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554931, ; type_token_id
		i32 366; java_name_index
	}, 
	; 162
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 391; java_name_index
	}, 
	; 163
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 272; java_name_index
	}, 
	; 164
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 466; java_name_index
	}, 
	; 165
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555282, ; type_token_id
		i32 540; java_name_index
	}, 
	; 166
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554603, ; type_token_id
		i32 98; java_name_index
	}, 
	; 167
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554986, ; type_token_id
		i32 400; java_name_index
	}, 
	; 168
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555055, ; type_token_id
		i32 441; java_name_index
	}, 
	; 169
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 516; java_name_index
	}, 
	; 170
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554434, ; type_token_id
		i32 608; java_name_index
	}, 
	; 171
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554463, ; type_token_id
		i32 9; java_name_index
	}, 
	; 172
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554474, ; type_token_id
		i32 188; java_name_index
	}, 
	; 173
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555090, ; type_token_id
		i32 457; java_name_index
	}, 
	; 174
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555217, ; type_token_id
		i32 502; java_name_index
	}, 
	; 175
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555130, ; type_token_id
		i32 480; java_name_index
	}, 
	; 176
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554508, ; type_token_id
		i32 33; java_name_index
	}, 
	; 177
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554626, ; type_token_id
		i32 215; java_name_index
	}, 
	; 178
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554435, ; type_token_id
		i32 117; java_name_index
	}, 
	; 179
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554561, ; type_token_id
		i32 71; java_name_index
	}, 
	; 180
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 85; java_name_index
	}, 
	; 181
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 354; java_name_index
	}, 
	; 182
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 300; java_name_index
	}, 
	; 183
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 289; java_name_index
	}, 
	; 184
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554653, ; type_token_id
		i32 224; java_name_index
	}, 
	; 185
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554510, ; type_token_id
		i32 35; java_name_index
	}, 
	; 186
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554646, ; type_token_id
		i32 25; java_name_index
	}, 
	; 187
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 310; java_name_index
	}, 
	; 188
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554926, ; type_token_id
		i32 362; java_name_index
	}, 
	; 189
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554553, ; type_token_id
		i32 60; java_name_index
	}, 
	; 190
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554728, ; type_token_id
		i32 270; java_name_index
	}, 
	; 191
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554606, ; type_token_id
		i32 204; java_name_index
	}, 
	; 192
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554454, ; type_token_id
		i32 615; java_name_index
	}, 
	; 193
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554658, ; type_token_id
		i32 46; java_name_index
	}, 
	; 194
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554547, ; type_token_id
		i32 55; java_name_index
	}, 
	; 195
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554487, ; type_token_id
		i32 194; java_name_index
	}, 
	; 196
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554440, ; type_token_id
		i32 601; java_name_index
	}, 
	; 197
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554445, ; type_token_id
		i32 123; java_name_index
	}, 
	; 198
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 309; java_name_index
	}, 
	; 199
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554460, ; type_token_id
		i32 155; java_name_index
	}, 
	; 200
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554458, ; type_token_id
		i32 154; java_name_index
	}, 
	; 201
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554609, ; type_token_id
		i32 105; java_name_index
	}, 
	; 202
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 576; java_name_index
	}, 
	; 203
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555303, ; type_token_id
		i32 558; java_name_index
	}, 
	; 204
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554471, ; type_token_id
		i32 136; java_name_index
	}, 
	; 205
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554567, ; type_token_id
		i32 78; java_name_index
	}, 
	; 206
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 560; java_name_index
	}, 
	; 207
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554900, ; type_token_id
		i32 350; java_name_index
	}, 
	; 208
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554473, ; type_token_id
		i32 160; java_name_index
	}, 
	; 209
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555255, ; type_token_id
		i32 525; java_name_index
	}, 
	; 210
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554511, ; type_token_id
		i32 36; java_name_index
	}, 
	; 211
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554855, ; type_token_id
		i32 329; java_name_index
	}, 
	; 212
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554615, ; type_token_id
		i32 115; java_name_index
	}, 
	; 213
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 352; java_name_index
	}, 
	; 214
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554557, ; type_token_id
		i32 67; java_name_index
	}, 
	; 215
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 430; java_name_index
	}, 
	; 216
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 333; java_name_index
	}, 
	; 217
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555022, ; type_token_id
		i32 424; java_name_index
	}, 
	; 218
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 276; java_name_index
	}, 
	; 219
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 380; java_name_index
	}, 
	; 220
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554710, ; type_token_id
		i32 107; java_name_index
	}, 
	; 221
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554461, ; type_token_id
		i32 179; java_name_index
	}, 
	; 222
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555226, ; type_token_id
		i32 509; java_name_index
	}, 
	; 223
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554482, ; type_token_id
		i32 191; java_name_index
	}, 
	; 224
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555243, ; type_token_id
		i32 519; java_name_index
	}, 
	; 225
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554714, ; type_token_id
		i32 259; java_name_index
	}, 
	; 226
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555117, ; type_token_id
		i32 472; java_name_index
	}, 
	; 227
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554696, ; type_token_id
		i32 247; java_name_index
	}, 
	; 228
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554882, ; type_token_id
		i32 342; java_name_index
	}, 
	; 229
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 371; java_name_index
	}, 
	; 230
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 250; java_name_index
	}, 
	; 231
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554604, ; type_token_id
		i32 203; java_name_index
	}, 
	; 232
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555301, ; type_token_id
		i32 557; java_name_index
	}, 
	; 233
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554946, ; type_token_id
		i32 374; java_name_index
	}, 
	; 234
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554920, ; type_token_id
		i32 359; java_name_index
	}, 
	; 235
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554713, ; type_token_id
		i32 258; java_name_index
	}, 
	; 236
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 216; java_name_index
	}, 
	; 237
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555013, ; type_token_id
		i32 417; java_name_index
	}, 
	; 238
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554546, ; type_token_id
		i32 54; java_name_index
	}, 
	; 239
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554450, ; type_token_id
		i32 613; java_name_index
	}, 
	; 240
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554783, ; type_token_id
		i32 299; java_name_index
	}, 
	; 241
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 296; java_name_index
	}, 
	; 242
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554651, ; type_token_id
		i32 32; java_name_index
	}, 
	; 243
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554692, ; type_token_id
		i32 90; java_name_index
	}, 
	; 244
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554916, ; type_token_id
		i32 357; java_name_index
	}, 
	; 245
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554448, ; type_token_id
		i32 604; java_name_index
	}, 
	; 246
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554544, ; type_token_id
		i32 51; java_name_index
	}, 
	; 247
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554436, ; type_token_id
		i32 618; java_name_index
	}, 
	; 248
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 208; java_name_index
	}, 
	; 249
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 298; java_name_index
	}, 
	; 250
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554543, ; type_token_id
		i32 50; java_name_index
	}, 
	; 251
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554942, ; type_token_id
		i32 372; java_name_index
	}, 
	; 252
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554853, ; type_token_id
		i32 328; java_name_index
	}, 
	; 253
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554478, ; type_token_id
		i32 190; java_name_index
	}, 
	; 254
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554560, ; type_token_id
		i32 70; java_name_index
	}, 
	; 255
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 567; java_name_index
	}, 
	; 256
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555064, ; type_token_id
		i32 448; java_name_index
	}, 
	; 257
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554712, ; type_token_id
		i32 109; java_name_index
	}, 
	; 258
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555204, ; type_token_id
		i32 493; java_name_index
	}, 
	; 259
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554453, ; type_token_id
		i32 3; java_name_index
	}, 
	; 260
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554995, ; type_token_id
		i32 406; java_name_index
	}, 
	; 261
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 393; java_name_index
	}, 
	; 262
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554963, ; type_token_id
		i32 386; java_name_index
	}, 
	; 263
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 585; java_name_index
	}, 
	; 264
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555119, ; type_token_id
		i32 473; java_name_index
	}, 
	; 265
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 578; java_name_index
	}, 
	; 266
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554748, ; type_token_id
		i32 282; java_name_index
	}, 
	; 267
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555342, ; type_token_id
		i32 582; java_name_index
	}, 
	; 268
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554562, ; type_token_id
		i32 72; java_name_index
	}, 
	; 269
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554831, ; type_token_id
		i32 321; java_name_index
	}, 
	; 270
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555350, ; type_token_id
		i32 587; java_name_index
	}, 
	; 271
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 280; java_name_index
	}, 
	; 272
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555281, ; type_token_id
		i32 539; java_name_index
	}, 
	; 273
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554439, ; type_token_id
		i32 120; java_name_index
	}, 
	; 274
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 252; java_name_index
	}, 
	; 275
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554440, ; type_token_id
		i32 610; java_name_index
	}, 
	; 276
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 434; java_name_index
	}, 
	; 277
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555027, ; type_token_id
		i32 428; java_name_index
	}, 
	; 278
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554457, ; type_token_id
		i32 177; java_name_index
	}, 
	; 279
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555159, ; type_token_id
		i32 485; java_name_index
	}, 
	; 280
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 68; java_name_index
	}, 
	; 281
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555131, ; type_token_id
		i32 481; java_name_index
	}, 
	; 282
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554718, ; type_token_id
		i32 262; java_name_index
	}, 
	; 283
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554949, ; type_token_id
		i32 376; java_name_index
	}, 
	; 284
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554495, ; type_token_id
		i32 20; java_name_index
	}, 
	; 285
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554498, ; type_token_id
		i32 22; java_name_index
	}, 
	; 286
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 308; java_name_index
	}, 
	; 287
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554450, ; type_token_id
		i32 173; java_name_index
	}, 
	; 288
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 45; java_name_index
	}, 
	; 289
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555277, ; type_token_id
		i32 536; java_name_index
	}, 
	; 290
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554464, ; type_token_id
		i32 131; java_name_index
	}, 
	; 291
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555101, ; type_token_id
		i32 463; java_name_index
	}, 
	; 292
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554725, ; type_token_id
		i32 268; java_name_index
	}, 
	; 293
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554954, ; type_token_id
		i32 379; java_name_index
	}, 
	; 294
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554992, ; type_token_id
		i32 404; java_name_index
	}, 
	; 295
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554436, ; type_token_id
		i32 165; java_name_index
	}, 
	; 296
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555316, ; type_token_id
		i32 564; java_name_index
	}, 
	; 297
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 356; java_name_index
	}, 
	; 298
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554461, ; type_token_id
		i32 7; java_name_index
	}, 
	; 299
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 390; java_name_index
	}, 
	; 300
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554479, ; type_token_id
		i32 16; java_name_index
	}, 
	; 301
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555094, ; type_token_id
		i32 459; java_name_index
	}, 
	; 302
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554452, ; type_token_id
		i32 175; java_name_index
	}, 
	; 303
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 568; java_name_index
	}, 
	; 304
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554563, ; type_token_id
		i32 73; java_name_index
	}, 
	; 305
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 311; java_name_index
	}, 
	; 306
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 279; java_name_index
	}, 
	; 307
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555084, ; type_token_id
		i32 454; java_name_index
	}, 
	; 308
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554434, ; type_token_id
		i32 163; java_name_index
	}, 
	; 309
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554441, ; type_token_id
		i32 121; java_name_index
	}, 
	; 310
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555126, ; type_token_id
		i32 478; java_name_index
	}, 
	; 311
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 290; java_name_index
	}, 
	; 312
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554464, ; type_token_id
		i32 181; java_name_index
	}, 
	; 313
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554475, ; type_token_id
		i32 189; java_name_index
	}, 
	; 314
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554599, ; type_token_id
		i32 95; java_name_index
	}, 
	; 315
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555279, ; type_token_id
		i32 537; java_name_index
	}, 
	; 316
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554765, ; type_token_id
		i32 288; java_name_index
	}, 
	; 317
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555008, ; type_token_id
		i32 413; java_name_index
	}, 
	; 318
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555357, ; type_token_id
		i32 592; java_name_index
	}, 
	; 319
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555006, ; type_token_id
		i32 411; java_name_index
	}, 
	; 320
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554554, ; type_token_id
		i32 61; java_name_index
	}, 
	; 321
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 294; java_name_index
	}, 
	; 322
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 207; java_name_index
	}, 
	; 323
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554860, ; type_token_id
		i32 332; java_name_index
	}, 
	; 324
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 513; java_name_index
	}, 
	; 325
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554706, ; type_token_id
		i32 254; java_name_index
	}, 
	; 326
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554922, ; type_token_id
		i32 360; java_name_index
	}, 
	; 327
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555019, ; type_token_id
		i32 422; java_name_index
	}, 
	; 328
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 389; java_name_index
	}, 
	; 329
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554463, ; type_token_id
		i32 157; java_name_index
	}, 
	; 330
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554732, ; type_token_id
		i32 273; java_name_index
	}, 
	; 331
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554458, ; type_token_id
		i32 127; java_name_index
	}, 
	; 332
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554679, ; type_token_id
		i32 240; java_name_index
	}, 
	; 333
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555299, ; type_token_id
		i32 556; java_name_index
	}, 
	; 334
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554468, ; type_token_id
		i32 133; java_name_index
	}, 
	; 335
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554455, ; type_token_id
		i32 176; java_name_index
	}, 
	; 336
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 251; java_name_index
	}, 
	; 337
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554881, ; type_token_id
		i32 341; java_name_index
	}, 
	; 338
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554918, ; type_token_id
		i32 358; java_name_index
	}, 
	; 339
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555295, ; type_token_id
		i32 552; java_name_index
	}, 
	; 340
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554438, ; type_token_id
		i32 619; java_name_index
	}, 
	; 341
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555225, ; type_token_id
		i32 508; java_name_index
	}, 
	; 342
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554864, ; type_token_id
		i32 334; java_name_index
	}, 
	; 343
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555324, ; type_token_id
		i32 570; java_name_index
	}, 
	; 344
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555329, ; type_token_id
		i32 574; java_name_index
	}, 
	; 345
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555056, ; type_token_id
		i32 442; java_name_index
	}, 
	; 346
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554689, ; type_token_id
		i32 86; java_name_index
	}, 
	; 347
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 589; java_name_index
	}, 
	; 348
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555323, ; type_token_id
		i32 569; java_name_index
	}, 
	; 349
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555325, ; type_token_id
		i32 571; java_name_index
	}, 
	; 350
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554470, ; type_token_id
		i32 186; java_name_index
	}, 
	; 351
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554589, ; type_token_id
		i32 92; java_name_index
	}, 
	; 352
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554848, ; type_token_id
		i32 326; java_name_index
	}, 
	; 353
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 532; java_name_index
	}, 
	; 354
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555289, ; type_token_id
		i32 547; java_name_index
	}, 
	; 355
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554716, ; type_token_id
		i32 261; java_name_index
	}, 
	; 356
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554859, ; type_token_id
		i32 331; java_name_index
	}, 
	; 357
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 211; java_name_index
	}, 
	; 358
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 322; java_name_index
	}, 
	; 359
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555330, ; type_token_id
		i32 575; java_name_index
	}, 
	; 360
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554525, ; type_token_id
		i32 42; java_name_index
	}, 
	; 361
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555125, ; type_token_id
		i32 477; java_name_index
	}, 
	; 362
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554551, ; type_token_id
		i32 58; java_name_index
	}, 
	; 363
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 217; java_name_index
	}, 
	; 364
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555292, ; type_token_id
		i32 550; java_name_index
	}, 
	; 365
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 283; java_name_index
	}, 
	; 366
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554657, ; type_token_id
		i32 227; java_name_index
	}, 
	; 367
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554437, ; type_token_id
		i32 148; java_name_index
	}, 
	; 368
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 562; java_name_index
	}, 
	; 369
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 440; java_name_index
	}, 
	; 370
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554597, ; type_token_id
		i32 199; java_name_index
	}, 
	; 371
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554991, ; type_token_id
		i32 403; java_name_index
	}, 
	; 372
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554456, ; type_token_id
		i32 126; java_name_index
	}, 
	; 373
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555232, ; type_token_id
		i32 512; java_name_index
	}, 
	; 374
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554435, ; type_token_id
		i32 164; java_name_index
	}, 
	; 375
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554958, ; type_token_id
		i32 381; java_name_index
	}, 
	; 376
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 535; java_name_index
	}, 
	; 377
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554434, ; type_token_id
		i32 596; java_name_index
	}, 
	; 378
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555016, ; type_token_id
		i32 420; java_name_index
	}, 
	; 379
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554468, ; type_token_id
		i32 185; java_name_index
	}, 
	; 380
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554460, ; type_token_id
		i32 128; java_name_index
	}, 
	; 381
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554795, ; type_token_id
		i32 304; java_name_index
	}, 
	; 382
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554870, ; type_token_id
		i32 336; java_name_index
	}, 
	; 383
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554623, ; type_token_id
		i32 213; java_name_index
	}, 
	; 384
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 563; java_name_index
	}, 
	; 385
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554556, ; type_token_id
		i32 64; java_name_index
	}, 
	; 386
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554687, ; type_token_id
		i32 242; java_name_index
	}, 
	; 387
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555296, ; type_token_id
		i32 553; java_name_index
	}, 
	; 388
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 483; java_name_index
	}, 
	; 389
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554454, ; type_token_id
		i32 607; java_name_index
	}, 
	; 390
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555168, ; type_token_id
		i32 486; java_name_index
	}, 
	; 391
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554611, ; type_token_id
		i32 110; java_name_index
	}, 
	; 392
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555241, ; type_token_id
		i32 518; java_name_index
	}, 
	; 393
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554463, ; type_token_id
		i32 180; java_name_index
	}, 
	; 394
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 534; java_name_index
	}, 
	; 395
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554447, ; type_token_id
		i32 152; java_name_index
	}, 
	; 396
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554466, ; type_token_id
		i32 183; java_name_index
	}, 
	; 397
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554734, ; type_token_id
		i32 274; java_name_index
	}, 
	; 398
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554701, ; type_token_id
		i32 101; java_name_index
	}, 
	; 399
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554874, ; type_token_id
		i32 338; java_name_index
	}, 
	; 400
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554674, ; type_token_id
		i32 62; java_name_index
	}, 
	; 401
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554691, ; type_token_id
		i32 244; java_name_index
	}, 
	; 402
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555203, ; type_token_id
		i32 492; java_name_index
	}, 
	; 403
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555029, ; type_token_id
		i32 429; java_name_index
	}, 
	; 404
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555087, ; type_token_id
		i32 455; java_name_index
	}, 
	; 405
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555283, ; type_token_id
		i32 541; java_name_index
	}, 
	; 406
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 460; java_name_index
	}, 
	; 407
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555082, ; type_token_id
		i32 453; java_name_index
	}, 
	; 408
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555318, ; type_token_id
		i32 566; java_name_index
	}, 
	; 409
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554486, ; type_token_id
		i32 193; java_name_index
	}, 
	; 410
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555129, ; type_token_id
		i32 479; java_name_index
	}, 
	; 411
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554977, ; type_token_id
		i32 394; java_name_index
	}, 
	; 412
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555317, ; type_token_id
		i32 565; java_name_index
	}, 
	; 413
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554869, ; type_token_id
		i32 335; java_name_index
	}, 
	; 414
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554477, ; type_token_id
		i32 139; java_name_index
	}, 
	; 415
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555326, ; type_token_id
		i32 572; java_name_index
	}, 
	; 416
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 520; java_name_index
	}, 
	; 417
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554579, ; type_token_id
		i32 87; java_name_index
	}, 
	; 418
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555049, ; type_token_id
		i32 438; java_name_index
	}, 
	; 419
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 368; java_name_index
	}, 
	; 420
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554631, ; type_token_id
		i32 218; java_name_index
	}, 
	; 421
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554929, ; type_token_id
		i32 365; java_name_index
	}, 
	; 422
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555288, ; type_token_id
		i32 546; java_name_index
	}, 
	; 423
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 343; java_name_index
	}, 
	; 424
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554692, ; type_token_id
		i32 245; java_name_index
	}, 
	; 425
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554705, ; type_token_id
		i32 253; java_name_index
	}, 
	; 426
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555081, ; type_token_id
		i32 452; java_name_index
	}, 
	; 427
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555222, ; type_token_id
		i32 505; java_name_index
	}, 
	; 428
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554441, ; type_token_id
		i32 150; java_name_index
	}, 
	; 429
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554439, ; type_token_id
		i32 145; java_name_index
	}, 
	; 430
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 475; java_name_index
	}, 
	; 431
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 287; java_name_index
	}, 
	; 432
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 230; java_name_index
	}, 
	; 433
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 267; java_name_index
	}, 
	; 434
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554470, ; type_token_id
		i32 135; java_name_index
	}, 
	; 435
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555058, ; type_token_id
		i32 444; java_name_index
	}, 
	; 436
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 281; java_name_index
	}, 
	; 437
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 317; java_name_index
	}, 
	; 438
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555092, ; type_token_id
		i32 458; java_name_index
	}, 
	; 439
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554698, ; type_token_id
		i32 249; java_name_index
	}, 
	; 440
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555012, ; type_token_id
		i32 416; java_name_index
	}, 
	; 441
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554601, ; type_token_id
		i32 96; java_name_index
	}, 
	; 442
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 319; java_name_index
	}, 
	; 443
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555383, ; type_token_id
		i32 595; java_name_index
	}, 
	; 444
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555057, ; type_token_id
		i32 443; java_name_index
	}, 
	; 445
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555015, ; type_token_id
		i32 419; java_name_index
	}, 
	; 446
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555246, ; type_token_id
		i32 521; java_name_index
	}, 
	; 447
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555112, ; type_token_id
		i32 470; java_name_index
	}, 
	; 448
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554539, ; type_token_id
		i32 47; java_name_index
	}, 
	; 449
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554443, ; type_token_id
		i32 602; java_name_index
	}, 
	; 450
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554889, ; type_token_id
		i32 344; java_name_index
	}, 
	; 451
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554480, ; type_token_id
		i32 141; java_name_index
	}, 
	; 452
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554505, ; type_token_id
		i32 29; java_name_index
	}, 
	; 453
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554443, ; type_token_id
		i32 151; java_name_index
	}, 
	; 454
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 462; java_name_index
	}, 
	; 455
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554555, ; type_token_id
		i32 63; java_name_index
	}, 
	; 456
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554559, ; type_token_id
		i32 69; java_name_index
	}, 
	; 457
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555359, ; type_token_id
		i32 593; java_name_index
	}, 
	; 458
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554571, ; type_token_id
		i32 83; java_name_index
	}, 
	; 459
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555291, ; type_token_id
		i32 549; java_name_index
	}, 
	; 460
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 345; java_name_index
	}, 
	; 461
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555051, ; type_token_id
		i32 439; java_name_index
	}, 
	; 462
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 277; java_name_index
	}, 
	; 463
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555223, ; type_token_id
		i32 506; java_name_index
	}, 
	; 464
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555017, ; type_token_id
		i32 421; java_name_index
	}, 
	; 465
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554434, ; type_token_id
		i32 142; java_name_index
	}, 
	; 466
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554683, ; type_token_id
		i32 76; java_name_index
	}, 
	; 467
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 577; java_name_index
	}, 
	; 468
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554980, ; type_token_id
		i32 396; java_name_index
	}, 
	; 469
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554722, ; type_token_id
		i32 266; java_name_index
	}, 
	; 470
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554649, ; type_token_id
		i32 222; java_name_index
	}, 
	; 471
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555259, ; type_token_id
		i32 527; java_name_index
	}, 
	; 472
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555003, ; type_token_id
		i32 409; java_name_index
	}, 
	; 473
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554454, ; type_token_id
		i32 125; java_name_index
	}, 
	; 474
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 243; java_name_index
	}, 
	; 475
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554622, ; type_token_id
		i32 212; java_name_index
	}, 
	; 476
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555290, ; type_token_id
		i32 548; java_name_index
	}, 
	; 477
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555298, ; type_token_id
		i32 555; java_name_index
	}, 
	; 478
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554456, ; type_token_id
		i32 5; java_name_index
	}, 
	; 479
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555189, ; type_token_id
		i32 490; java_name_index
	}, 
	; 480
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554446, ; type_token_id
		i32 170; java_name_index
	}, 
	; 481
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 531; java_name_index
	}, 
	; 482
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554441, ; type_token_id
		i32 611; java_name_index
	}, 
	; 483
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 285; java_name_index
	}, 
	; 484
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554509, ; type_token_id
		i32 34; java_name_index
	}, 
	; 485
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554452, ; type_token_id
		i32 614; java_name_index
	}, 
	; 486
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 320; java_name_index
	}, 
	; 487
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554439, ; type_token_id
		i32 149; java_name_index
	}, 
	; 488
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554491, ; type_token_id
		i32 196; java_name_index
	}, 
	; 489
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554439, ; type_token_id
		i32 600; java_name_index
	}, 
	; 490
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554707, ; type_token_id
		i32 255; java_name_index
	}, 
	; 491
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554978, ; type_token_id
		i32 395; java_name_index
	}, 
	; 492
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555023, ; type_token_id
		i32 425; java_name_index
	}, 
	; 493
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555280, ; type_token_id
		i32 538; java_name_index
	}, 
	; 494
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555060, ; type_token_id
		i32 446; java_name_index
	}, 
	; 495
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 561; java_name_index
	}, 
	; 496
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554752, ; type_token_id
		i32 284; java_name_index
	}, 
	; 497
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554449, ; type_token_id
		i32 172; java_name_index
	}, 
	; 498
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554475, ; type_token_id
		i32 138; java_name_index
	}, 
	; 499
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554648, ; type_token_id
		i32 221; java_name_index
	}, 
	; 500
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554740, ; type_token_id
		i32 278; java_name_index
	}, 
	; 501
	%struct.TypeMapJava {
		i32 6, ; module_index
		i32 33554434, ; type_token_id
		i32 197; java_name_index
	}, 
	; 502
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 545; java_name_index
	}, 
	; 503
	%struct.TypeMapJava {
		i32 6, ; module_index
		i32 33554437, ; type_token_id
		i32 198; java_name_index
	}, 
	; 504
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 114; java_name_index
	}, 
	; 505
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 237; java_name_index
	}, 
	; 506
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 402; java_name_index
	}, 
	; 507
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554458, ; type_token_id
		i32 6; java_name_index
	}, 
	; 508
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554443, ; type_token_id
		i32 122; java_name_index
	}, 
	; 509
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555124, ; type_token_id
		i32 476; java_name_index
	}, 
	; 510
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554456, ; type_token_id
		i32 616; java_name_index
	}, 
	; 511
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555297, ; type_token_id
		i32 554; java_name_index
	}, 
	; 512
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554729, ; type_token_id
		i32 15; java_name_index
	}, 
	; 513
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 423; java_name_index
	}, 
	; 514
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554604, ; type_token_id
		i32 99; java_name_index
	}, 
	; 515
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555108, ; type_token_id
		i32 467; java_name_index
	}, 
	; 516
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 206; java_name_index
	}, 
	; 517
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 200; java_name_index
	}, 
	; 518
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554983, ; type_token_id
		i32 399; java_name_index
	}, 
	; 519
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 348; java_name_index
	}, 
	; 520
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554522, ; type_token_id
		i32 40; java_name_index
	}, 
	; 521
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554718, ; type_token_id
		i32 113; java_name_index
	}, 
	; 522
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 232; java_name_index
	}, 
	; 523
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 116; java_name_index
	}, 
	; 524
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554451, ; type_token_id
		i32 174; java_name_index
	}, 
	; 525
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554447, ; type_token_id
		i32 124; java_name_index
	}, 
	; 526
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554677, ; type_token_id
		i32 238; java_name_index
	}, 
	; 527
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554583, ; type_token_id
		i32 89; java_name_index
	}, 
	; 528
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 220; java_name_index
	}, 
	; 529
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555360, ; type_token_id
		i32 594; java_name_index
	}, 
	; 530
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 559; java_name_index
	}, 
	; 531
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554441, ; type_token_id
		i32 621; java_name_index
	}, 
	; 532
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554595, ; type_token_id
		i32 93; java_name_index
	}, 
	; 533
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554439, ; type_token_id
		i32 620; java_name_index
	}, 
	; 534
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554434, ; type_token_id
		i32 617; java_name_index
	}, 
	; 535
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 209; java_name_index
	}, 
	; 536
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554444, ; type_token_id
		i32 603; java_name_index
	}, 
	; 537
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 515; java_name_index
	}, 
	; 538
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555007, ; type_token_id
		i32 412; java_name_index
	}, 
	; 539
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555039, ; type_token_id
		i32 435; java_name_index
	}, 
	; 540
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555074, ; type_token_id
		i32 450; java_name_index
	}, 
	; 541
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554715, ; type_token_id
		i32 260; java_name_index
	}, 
	; 542
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554474, ; type_token_id
		i32 161; java_name_index
	}, 
	; 543
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 210; java_name_index
	}, 
	; 544
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555221, ; type_token_id
		i32 504; java_name_index
	}, 
	; 545
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 528; java_name_index
	}, 
	; 546
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554966, ; type_token_id
		i32 388; java_name_index
	}, 
	; 547
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554994, ; type_token_id
		i32 405; java_name_index
	}, 
	; 548
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555202, ; type_token_id
		i32 491; java_name_index
	}, 
	; 549
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554656, ; type_token_id
		i32 226; java_name_index
	}, 
	; 550
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554771, ; type_token_id
		i32 292; java_name_index
	}, 
	; 551
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554872, ; type_token_id
		i32 337; java_name_index
	}, 
	; 552
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554521, ; type_token_id
		i32 39; java_name_index
	}, 
	; 553
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554564, ; type_token_id
		i32 74; java_name_index
	}, 
	; 554
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554845, ; type_token_id
		i32 324; java_name_index
	}, 
	; 555
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554450, ; type_token_id
		i32 605; java_name_index
	}, 
	; 556
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554960, ; type_token_id
		i32 383; java_name_index
	}, 
	; 557
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554437, ; type_token_id
		i32 118; java_name_index
	}, 
	; 558
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554790, ; type_token_id
		i32 302; java_name_index
	}, 
	; 559
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554466, ; type_token_id
		i32 158; java_name_index
	}, 
	; 560
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555252, ; type_token_id
		i32 524; java_name_index
	}, 
	; 561
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 464; java_name_index
	}, 
	; 562
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554850, ; type_token_id
		i32 327; java_name_index
	}, 
	; 563
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554610, ; type_token_id
		i32 106; java_name_index
	}, 
	; 564
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555059, ; type_token_id
		i32 445; java_name_index
	}, 
	; 565
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 580; java_name_index
	}, 
	; 566
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555170, ; type_token_id
		i32 487; java_name_index
	}, 
	; 567
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555010, ; type_token_id
		i32 414; java_name_index
	}, 
	; 568
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555153, ; type_token_id
		i32 482; java_name_index
	}, 
	; 569
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555014, ; type_token_id
		i32 418; java_name_index
	}, 
	; 570
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 370; java_name_index
	}, 
	; 571
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554545, ; type_token_id
		i32 52; java_name_index
	}, 
	; 572
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554437, ; type_token_id
		i32 599; java_name_index
	}, 
	; 573
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554858, ; type_token_id
		i32 330; java_name_index
	}, 
	; 574
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554438, ; type_token_id
		i32 166; java_name_index
	}, 
	; 575
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554437, ; type_token_id
		i32 144; java_name_index
	}, 
	; 576
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554944, ; type_token_id
		i32 373; java_name_index
	}, 
	; 577
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554434, ; type_token_id
		i32 146; java_name_index
	}, 
	; 578
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555354, ; type_token_id
		i32 590; java_name_index
	}, 
	; 579
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 246; java_name_index
	}, 
	; 580
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555005, ; type_token_id
		i32 410; java_name_index
	}, 
	; 581
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554649, ; type_token_id
		i32 30; java_name_index
	}, 
	; 582
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554613, ; type_token_id
		i32 112; java_name_index
	}, 
	; 583
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555114, ; type_token_id
		i32 471; java_name_index
	}, 
	; 584
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554651, ; type_token_id
		i32 223; java_name_index
	}, 
	; 585
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554762, ; type_token_id
		i32 286; java_name_index
	}, 
	; 586
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554565, ; type_token_id
		i32 75; java_name_index
	}, 
	; 587
	%struct.TypeMapJava {
		i32 11, ; module_index
		i32 33554436, ; type_token_id
		i32 623; java_name_index
	}, 
	; 588
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 510; java_name_index
	}, 
	; 589
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555284, ; type_token_id
		i32 542; java_name_index
	}, 
	; 590
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555328, ; type_token_id
		i32 573; java_name_index
	}, 
	; 591
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555235, ; type_token_id
		i32 514; java_name_index
	}, 
	; 592
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554502, ; type_token_id
		i32 27; java_name_index
	}, 
	; 593
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554792, ; type_token_id
		i32 303; java_name_index
	}, 
	; 594
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554707, ; type_token_id
		i32 103; java_name_index
	}, 
	; 595
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555216, ; type_token_id
		i32 501; java_name_index
	}, 
	; 596
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555248, ; type_token_id
		i32 522; java_name_index
	}, 
	; 597
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 584; java_name_index
	}, 
	; 598
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554928, ; type_token_id
		i32 364; java_name_index
	}, 
	; 599
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554566, ; type_token_id
		i32 77; java_name_index
	}, 
	; 600
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 353; java_name_index
	}, 
	; 601
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554677, ; type_token_id
		i32 66; java_name_index
	}, 
	; 602
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554720, ; type_token_id
		i32 264; java_name_index
	}, 
	; 603
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554448, ; type_token_id
		i32 612; java_name_index
	}, 
	; 604
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554999, ; type_token_id
		i32 408; java_name_index
	}, 
	; 605
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554452, ; type_token_id
		i32 2; java_name_index
	}, 
	; 606
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554892, ; type_token_id
		i32 346; java_name_index
	}, 
	; 607
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554697, ; type_token_id
		i32 248; java_name_index
	}, 
	; 608
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554435, ; type_token_id
		i32 147; java_name_index
	}, 
	; 609
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 306; java_name_index
	}, 
	; 610
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554655, ; type_token_id
		i32 225; java_name_index
	}, 
	; 611
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555207, ; type_token_id
		i32 495; java_name_index
	}, 
	; 612
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555034, ; type_token_id
		i32 432; java_name_index
	}, 
	; 613
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 305; java_name_index
	}, 
	; 614
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554668, ; type_token_id
		i32 57; java_name_index
	}, 
	; 615
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554608, ; type_token_id
		i32 102; java_name_index
	}, 
	; 616
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554536, ; type_token_id
		i32 44; java_name_index
	}, 
	; 617
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554624, ; type_token_id
		i32 214; java_name_index
	}, 
	; 618
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 233; java_name_index
	}, 
	; 619
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554982, ; type_token_id
		i32 398; java_name_index
	}, 
	; 620
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555286, ; type_token_id
		i32 544; java_name_index
	}, 
	; 621
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555157, ; type_token_id
		i32 484; java_name_index
	}, 
	; 622
	%struct.TypeMapJava {
		i32 4, ; module_index
		i32 33554434, ; type_token_id
		i32 162; java_name_index
	}, 
	; 623
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554678, ; type_token_id
		i32 239; java_name_index
	}
], align 16; end of 'map_java' array

@map_java_hashes = local_unnamed_addr constant [624 x i64] [
	i64 58144275653889021, ; 0: 0xce91e920128bfd => crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer
	i64 91366123682805704, ; 1: 0x1449901629e37c8 => android/support/v4/view/ViewPager$PageTransformer
	i64 128182020419974451, ; 2: 0x1c764de51b97533 => java/lang/String
	i64 174790719045131473, ; 3: 0x26cfb3b9eb85cd1 => crc643f46942d9dd1fff9/NativeViewWrapperRenderer
	i64 229629845183097875, ; 4: 0x32fcf20a7f76c13 => java/net/URI
	i64 288118547961651785, ; 5: 0x3ff9a4af874a249 => crc643f46942d9dd1fff9/TableViewRenderer
	i64 294901662421295971, ; 6: 0x417b37fe04b2363 => crc643f46942d9dd1fff9/GestureManager_TapAndPanGestureDetector
	i64 303634842664035266, ; 7: 0x436ba47da6be3c2 => android/text/style/UpdateAppearance
	i64 305308685063467181, ; 8: 0x43caca1a80cb0ad => android/arch/lifecycle/Lifecycle$State
	i64 318564728890166633, ; 9: 0x46bc4eedf778d69 => android/widget/Button
	i64 334388001803951069, ; 10: 0x4a3fc1db0ad5bdd => mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor
	i64 361870449891484378, ; 11: 0x5059f41c47e22da => android/os/Bundle
	i64 363417747702605178, ; 12: 0x50b1e841ce2e57a => android/widget/TextView
	i64 367157139588167896, ; 13: 0x518677921e6b8d8 => crc64720bb2db43a66fe9/ButtonRenderer_ButtonTouchListener
	i64 420183352050048797, ; 14: 0x5d4ca884f79df1d => android/media/MediaPlayer
	i64 421572720036924600, ; 15: 0x5d9ba27c0cbccb8 => crc643f46942d9dd1fff9/FrameRenderer
	i64 427729766984942981, ; 16: 0x5ef99f4f4ff8585 => android/support/v4/app/SharedElementCallback
	i64 439133414594709010, ; 17: 0x6181d8391ec0612 => android/widget/DatePicker
	i64 515916014736443504, ; 18: 0x728e6e1c84d0870 => android/webkit/ValueCallback
	i64 582128946798849863, ; 19: 0x81423315f6aef47 => android/view/ActionProvider
	i64 607287300891387102, ; 20: 0x86d8495263ca4de => android/support/v7/view/menu/MenuPresenter
	i64 608661263042661401, ; 21: 0x8726631a432cc19 => crc643f46942d9dd1fff9/TimePickerRenderer
	i64 619638459439082186, ; 22: 0x89965e558096aca => java/text/NumberFormat
	i64 654924058700157350, ; 23: 0x916c1f621ae11a6 => android/widget/SectionIndexer
	i64 677500945799965703, ; 24: 0x966f7854965ec07 => android/support/v4/view/ScaleGestureDetectorCompat
	i64 698692053645229055, ; 25: 0x9b240b890e97bff => javax/net/ssl/HttpsURLConnection
	i64 698738878519169148, ; 26: 0x9b26b4ed4e3d07c => mono/android/content/DialogInterface_OnClickListenerImplementor
	i64 705175846315662030, ; 27: 0x9c949b22fd49ace => android/view/MotionEvent
	i64 735491138525943134, ; 28: 0xa34fd4b2f49555e => android/support/design/widget/TabLayout$OnTabSelectedListener
	i64 742261478631417376, ; 29: 0xa4d0ae1d4482620 => crc643f46942d9dd1fff9/EntryEditText
	i64 749341527407275199, ; 30: 0xa663226248f2cbf => crc643f46942d9dd1fff9/ConditionalFocusLayout
	i64 753213119692529150, ; 31: 0xa73f357776fddfe => android/animation/TimeInterpolator
	i64 753844298871422754, ; 32: 0xa763165522f3f22 => java/lang/reflect/Type
	i64 769314120471534533, ; 33: 0xaad271dd765dbc5 => android/widget/SeekBar$OnSeekBarChangeListener
	i64 801953498771834695, ; 34: 0xb211c754cad4747 => crc643f46942d9dd1fff9/TableViewModelRenderer
	i64 809480176342503793, ; 35: 0xb3bd9ee7b9d9171 => java/nio/channels/ScatteringByteChannel
	i64 816513157356790819, ; 36: 0xb54d663faaf2423 => android/text/TextUtils$TruncateAt
	i64 844845191340040045, ; 37: 0xbb97e39b0051f6d => android/widget/TimePicker
	i64 868122344904594316, ; 38: 0xc0c30ac559e138c => android/text/TextPaint
	i64 870874870088288028, ; 39: 0xc15f8148b6d471c => java/lang/Exception
	i64 927185278642030230, ; 40: 0xcde0619366e0696 => crc643f46942d9dd1fff9/LocalizedDigitsKeyListener
	i64 971283029184991444, ; 41: 0xd7ab0c4daefd0d4 => android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback
	i64 973840855993032556, ; 42: 0xd83c719513a1f6c => crc64720bb2db43a66fe9/FrameRenderer
	i64 1042816948562317609, ; 43: 0xe78d47d58d05129 => android/graphics/Path$Direction
	i64 1093289771861447773, ; 44: 0xf2c2541485e945d => android/text/Spanned
	i64 1129615369612962765, ; 45: 0xfad3331969a2bcd => android/text/style/LineHeightSpan
	i64 1170743664434896130, ; 46: 0x103f5128f1ae5d02 => crc643f46942d9dd1fff9/ActivityIndicatorRenderer
	i64 1191712594980513502, ; 47: 0x1089d04a8a2c26de => android/support/v7/app/AppCompatDelegate
	i64 1217044833273073796, ; 48: 0x10e3cfd3e2f75084 => java/util/HashSet
	i64 1247566983430333137, ; 49: 0x11503f8fc0dee2d1 => android/view/ViewTreeObserver$OnPreDrawListener
	i64 1283121375857603354, ; 50: 0x11ce9017d3b3f31a => java/net/ConnectException
	i64 1309713578889228674, ; 51: 0x122d098f9332b182 => android/animation/AnimatorListenerAdapter
	i64 1317579852464953526, ; 52: 0x1248fbe51d6298b6 => java/io/FileInputStream
	i64 1320822650197077237, ; 53: 0x12548133cc496cf5 => android/runtime/JavaProxyThrowable
	i64 1332472170731495567, ; 54: 0x127de461298b608f => crc643f46942d9dd1fff9/ToolbarButton
	i64 1362770524300979611, ; 55: 0x12e9889253552d9b => java/util/Iterator
	i64 1407244619530254470, ; 56: 0x138789868b2e3886 => android/widget/AdapterView$OnItemLongClickListener
	i64 1448336174627311259, ; 57: 0x14198613c4024e9b => android/support/v4/app/LoaderManager
	i64 1455494196126435723, ; 58: 0x1432f44284c2498b => android/support/v7/app/ActionBarDrawerToggle$Delegate
	i64 1494974867389571991, ; 59: 0x14bf37b89ee46397 => android/view/ScaleGestureDetector$OnScaleGestureListener
	i64 1550860884384862055, ; 60: 0x1585c3c1edcecf67 => java/net/ProtocolException
	i64 1585010481244597099, ; 61: 0x15ff16a28bdaeb6b => android/graphics/drawable/GradientDrawable
	i64 1608247358826116468, ; 62: 0x1651a473b5ca7574 => android/content/ComponentCallbacks2
	i64 1627377857298732749, ; 63: 0x16959b89fba096cd => crc643f46942d9dd1fff9/PageExtensions_EmbeddedSupportFragment
	i64 1633393020343953050, ; 64: 0x16aafa4c4434269a => android/text/method/KeyListener
	i64 1747499027921055994, ; 65: 0x18405d1b749330fa => android/os/BaseBundle
	i64 1778809883888113698, ; 66: 0x18af9a2a341ad822 => android/support/v4/widget/TextViewCompat
	i64 1785634721208897755, ; 67: 0x18c7d951784290db => crc643f46942d9dd1fff9/InnerGestureListener
	i64 1788895080043878561, ; 68: 0x18d36e98ea7598a1 => crc643f46942d9dd1fff9/PageExtensions_EmbeddedFragment
	i64 1831728799718484971, ; 69: 0x196b9ba37012abeb => java/io/IOException
	i64 1844760744016486967, ; 70: 0x1999e81f6ab02237 => android/text/format/DateFormat
	i64 1850333256545206711, ; 71: 0x19adb44b187801b7 => java/nio/channels/GatheringByteChannel
	i64 1853552035664219559, ; 72: 0x19b923c18277cda7 => android/animation/ValueAnimator
	i64 1862053586602749962, ; 73: 0x19d757df1632f00a => java/nio/IntBuffer
	i64 1877272793125324469, ; 74: 0x1a0d69a8bcbd86b5 => java/net/Proxy
	i64 1889680513433701850, ; 75: 0x1a397e6a3e318dda => crc64720bb2db43a66fe9/NavigationPageRenderer_Container
	i64 1941234859008890695, ; 76: 0x1af0a6d1b4d49747 => android/util/TypedValue
	i64 1963488338777594493, ; 77: 0x1b3fb63db975da7d => crc643f46942d9dd1fff9/AndroidActivity
	i64 2020579117396024084, ; 78: 0x1c0a8a0074f65b14 => crc643f46942d9dd1fff9/FormsSeekBar
	i64 2071261092404328256, ; 79: 0x1cbe98fd51d8f740 => android/animation/Animator$AnimatorPauseListener
	i64 2075451569264967998, ; 80: 0x1ccd7c34be90c13e => crc643f46942d9dd1fff9/AHorizontalScrollView
	i64 2091945087796016600, ; 81: 0x1d0814f947b475d8 => android/view/MenuInflater
	i64 2111352555338672611, ; 82: 0x1d4d07f6709329e3 => android/view/InputEvent
	i64 2157468975174833820, ; 83: 0x1df0de9a2738d69c => org/xmlpull/v1/XmlPullParserException
	i64 2164140653916027403, ; 84: 0x1e08927568a57a0b => java/io/InputStream
	i64 2167479295784889895, ; 85: 0x1e146eef8b45ae27 => crc643f46942d9dd1fff9/BaseCellView
	i64 2173847856803601638, ; 86: 0x1e2b0f1bb485dce6 => android/app/TimePickerDialog$OnTimeSetListener
	i64 2208930198539504994, ; 87: 0x1ea7b24fe9948d62 => android/view/View$MeasureSpec
	i64 2218962425769004144, ; 88: 0x1ecb5691d5e68c70 => crc643f46942d9dd1fff9/ButtonRenderer_ButtonClickListener
	i64 2226060781910726129, ; 89: 0x1ee48e7caa3795f1 => android/widget/AbsListView
	i64 2235559862443296045, ; 90: 0x1f064dd9b30dc52d => crc64720bb2db43a66fe9/MasterDetailContainer
	i64 2235818838715194246, ; 91: 0x1f0739634fbedb86 => crc643f46942d9dd1fff9/FormattedStringExtensions_TextDecorationSpan
	i64 2249437647992761784, ; 92: 0x1f379b9f70ffadb8 => android/support/v4/app/Fragment$SavedState
	i64 2251579126814213638, ; 93: 0x1f3f374955720606 => crc64ee486da937c010f4/FrameRenderer
	i64 2266689907793747123, ; 94: 0x1f74e67632025cb3 => java/net/HttpURLConnection
	i64 2270205244544766606, ; 95: 0x1f8163a45051d28e => android/view/SurfaceHolder
	i64 2272075417053404891, ; 96: 0x1f88088dc85d9edb => android/support/v4/app/Fragment
	i64 2297475277055093504, ; 97: 0x1fe24597891c6b00 => crc643f46942d9dd1fff9/DatePickerRenderer_TextFieldClickHandler
	i64 2319268360137032813, ; 98: 0x202fb24918c5446d => java/security/SecureRandom
	i64 2328580579298191329, ; 99: 0x2050c7b313f127e1 => crc643f46942d9dd1fff9/TimePickerRenderer_TimePickerListener
	i64 2338884776692466006, ; 100: 0x2075634ffd52c156 => crc643f46942d9dd1fff9/GenericMenuClickListener
	i64 2349580542494205303, ; 101: 0x209b630e06896577 => android/view/SubMenu
	i64 2357387754135176159, ; 102: 0x20b71fac231543df => java/io/File
	i64 2370947031269421496, ; 103: 0x20e74bc35c14b1b8 => crc643f46942d9dd1fff9/ActionSheetRenderer
	i64 2500320158304072592, ; 104: 0x22b2ebefcc767390 => com/xamarin/forms/platform/android/FormsViewGroup
	i64 2518050838411213616, ; 105: 0x22f1e9e575dffb30 => android/view/ViewTreeObserver$OnGlobalFocusChangeListener
	i64 2542726837267699812, ; 106: 0x2349949628319864 => android/view/Window
	i64 2600674482769555637, ; 107: 0x241773a9c1e6f0b5 => android/os/PowerManager
	i64 2603260641783996945, ; 108: 0x2420a3c2d34a6211 => android/view/inputmethod/InputMethodManager
	i64 2612367236048011930, ; 109: 0x2440fe290782c29a => android/support/v4/view/ViewPropertyAnimatorUpdateListener
	i64 2628651148550353663, ; 110: 0x247ad84adbc432ff => android/widget/RelativeLayout
	i64 2642473403067126434, ; 111: 0x24abf38f463bd2a2 => android/support/v4/graphics/drawable/DrawableCompat
	i64 2680455744999255925, ; 112: 0x2532e44c64d5ef75 => crc643f46942d9dd1fff9/WebViewRenderer_JavascriptResult
	i64 2750786935813534148, ; 113: 0x262cc224d1f371c4 => crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuElementView
	i64 2759418165303941179, ; 114: 0x264b6c3389b3983b => android/support/v4/widget/DrawerLayout$DrawerListener
	i64 2790924924737673178, ; 115: 0x26bb5b6e9dc5d7da => crc64720bb2db43a66fe9/TabbedPageRenderer
	i64 2858794456539017208, ; 116: 0x27ac7a6963dd2ff8 => android/view/CollapsibleActionView
	i64 2885364006830175112, ; 117: 0x280adf46e2cf7388 => android/content/IntentFilter
	i64 2886264758754891955, ; 118: 0x280e1281895058b3 => crc643f46942d9dd1fff9/EntryCellView
	i64 2909629563912767547, ; 119: 0x286114ac28fec83b => android/support/v4/internal/view/SupportMenu
	i64 2972252214977986258, ; 120: 0x293f8fa450a17ed2 => android/content/Intent
	i64 2974627915900642736, ; 121: 0x294800544a37e5b0 => android/support/v7/view/menu/MenuPresenter$Callback
	i64 3019520352056718750, ; 122: 0x29e77dc31867359e => crc643f46942d9dd1fff9/CellRenderer_RendererHolder
	i64 3071747017624329461, ; 123: 0x2aa109a3415d1cf5 => android/os/Build
	i64 3123616921480482077, ; 124: 0x2b59510a5b3e4d1d => android/support/v7/view/menu/MenuBuilder$Callback
	i64 3134477772531467104, ; 125: 0x2b7fe6ed4c188360 => android/support/v4/widget/SwipeRefreshLayout$OnRefreshListener
	i64 3141456359327928326, ; 126: 0x2b98b1ea27221006 => android/support/v7/app/ActionBar
	i64 3145165272272586806, ; 127: 0x2ba5df26bdb3c836 => android/widget/ScrollView
	i64 3170069843700641096, ; 128: 0x2bfe59ba22f46d48 => android/widget/DatePicker$OnDateChangedListener
	i64 3171452383522110633, ; 129: 0x2c034323c5e6bca9 => android/view/MenuItem
	i64 3203928003458989292, ; 130: 0x2c76a38b44197cec => android/support/v7/widget/AppCompatButton
	i64 3215454989042874703, ; 131: 0x2c9f9746bd28794f => android/os/StrictMode
	i64 3230266667917055639, ; 132: 0x2cd4366b76fb1697 => android/app/DatePickerDialog$OnDateSetListener
	i64 3277568047959927566, ; 133: 0x2d7c42c639d26b0e => java/nio/channels/Channel
	i64 3312753486604898190, ; 134: 0x2df943be8d858f8e => android/app/Dialog
	i64 3417087477007219705, ; 135: 0x2f6beef4b1737bf9 => crc643f46942d9dd1fff9/InnerScaleListener
	i64 3476617847597562063, ; 136: 0x303f6d8331d5f8cf => java/io/PrintWriter
	i64 3492966660860961054, ; 137: 0x307982abe8e6611e => android/widget/AdapterView
	i64 3519439894707874979, ; 138: 0x30d78feffc66aca3 => crc643f46942d9dd1fff9/ButtonRenderer
	i64 3530631042196079534, ; 139: 0x30ff523a0f1083ae => android/content/DialogInterface
	i64 3560635333444528101, ; 140: 0x3169eaf880aa67e5 => android/os/Parcelable$Creator
	i64 3601437625014002978, ; 141: 0x31fae0704fafa522 => java/nio/CharBuffer
	i64 3627720250460558063, ; 142: 0x32584058e93152ef => android/support/v7/view/menu/MenuView
	i64 3648679180818523925, ; 143: 0x32a2b662280d2715 => android/content/pm/PackageManager
	i64 3655313265754481969, ; 144: 0x32ba480c6c11a531 => crc643f46942d9dd1fff9/TextCellRenderer_TextCellView
	i64 3656396631051491790, ; 145: 0x32be215d0fc259ce => java/net/InetSocketAddress
	i64 3664445150084014760, ; 146: 0x32dab972eda922a8 => android/text/InputFilter
	i64 3668991680153232620, ; 147: 0x32eae07e7365a4ec => android/view/MenuItem$OnMenuItemClickListener
	i64 3852049679258842853, ; 148: 0x35753ac6356176e5 => android/view/SurfaceHolder$Callback
	i64 3852940616739286617, ; 149: 0x35786513c16b6e59 => android/text/method/NumberKeyListener
	i64 3880992763041431256, ; 150: 0x35dc0e5b08f23ed8 => android/widget/SpinnerAdapter
	i64 3936478700004404583, ; 151: 0x36a12e8573a76d67 => java/net/SocketAddress
	i64 3940353796168302121, ; 152: 0x36aef2e695f93e29 => android/graphics/Canvas
	i64 3957166361670620563, ; 153: 0x36eaadd708809593 => javax/security/cert/Certificate
	i64 3984029951916655269, ; 154: 0x374a1e220a8242a5 => crc643f46942d9dd1fff9/MasterDetailContainer
	i64 4023088702392249377, ; 155: 0x37d4e1dc0dfa2c21 => android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener
	i64 4032644632170534830, ; 156: 0x37f6d4ed55e917ae => android/text/GetChars
	i64 4074005787519580853, ; 157: 0x3889c6adc1fd7ab5 => android/view/animation/Interpolator
	i64 4118187536763839185, ; 158: 0x3926bdbedf3fe2d1 => crc643f46942d9dd1fff9/LabelRenderer
	i64 4130165489315611710, ; 159: 0x39514ba1463c043e => android/graphics/drawable/ColorDrawable
	i64 4134740746808114799, ; 160: 0x39618ccd6bd4be6f => crc643f46942d9dd1fff9/PickerRenderer_PickerListener
	i64 4200728372439161058, ; 161: 0x3a4bfc32c52418e2 => android/text/style/ForegroundColorSpan
	i64 4216519898928517408, ; 162: 0x3a8416820c001120 => android/os/IInterface
	i64 4265611053753673363, ; 163: 0x3b327ea738f7a693 => android/widget/TimePicker$OnTimeChangedListener
	i64 4300416241721128614, ; 164: 0x3bae25c98a1bb6a6 => android/content/DialogInterface$OnDismissListener
	i64 4305371449952891808, ; 165: 0x3bbfc085dc8cf3a0 => java/lang/Class
	i64 4318126174017245327, ; 166: 0x3bed10e0799d508f => crc64720bb2db43a66fe9/FormsViewPager
	i64 4328468547648071486, ; 167: 0x3c11cf35fc03a73e => android/net/Uri
	i64 4339653235409979808, ; 168: 0x3c398ba008fc89a0 => mono/android/app/TabEventDispatcher
	i64 4346110607894790856, ; 169: 0x3c507c923a2042c8 => java/security/KeyStore$ProtectionParameter
	i64 4358870849498544683, ; 170: 0x3c7dd1f17e2a7a2b => android/support/design/widget/TabLayout
	i64 4389665591213479465, ; 171: 0x3ceb39990708d629 => crc643f46942d9dd1fff9/FormsApplicationActivity
	i64 4395608689356084250, ; 172: 0x3d0056d064b0941a => android/support/v7/app/ActionBar$OnNavigationListener
	i64 4406641945990788791, ; 173: 0x3d278980a31df6b7 => android/content/BroadcastReceiver
	i64 4480257524133297879, ; 174: 0x3e2d127b143c7ed7 => java/net/ProxySelector
	i64 4547751580410723029, ; 175: 0x3f1cdbf7a51a3ad5 => android/content/res/Resources$Theme
	i64 4579702700296773090, ; 176: 0x3f8e5f5774161de2 => crc643f46942d9dd1fff9/FormsImageView
	i64 4590799101254748484, ; 177: 0x3fb5cb75a178c944 => javax/net/ssl/TrustManagerFactory
	i64 4613457707100087539, ; 178: 0x40064b5769fd24f3 => android/support/v4/widget/AutoSizeableTextView
	i64 4619814699388432583, ; 179: 0x401ce0fe052cf0c7 => crc643f46942d9dd1fff9/ProgressBarRenderer
	i64 4637822922516410769, ; 180: 0x405cdb6033c13191 => crc643f46942d9dd1fff9/VisualElementRenderer_1
	i64 4642866827801349258, ; 181: 0x406ec6c7ea8b4c8a => android/text/Spannable
	i64 4657718675205956216, ; 182: 0x40a38a751b5aa278 => android/view/ActionMode$Callback
	i64 4668430364331232817, ; 183: 0x40c998ae949c4e31 => android/view/LayoutInflater$Factory
	i64 4672418894112007217, ; 184: 0x40d7c43a895ea431 => android/webkit/WebSettings
	i64 4699966279102520286, ; 185: 0x4139a26dea385bde => crc643f46942d9dd1fff9/FormsWebChromeClient
	i64 4710732948243388904, ; 186: 0x415fe2a86bc699e8 => crc643f46942d9dd1fff9/ButtonRenderer_ButtonTouchListener
	i64 4721440782757463965, ; 187: 0x4185ed606c4d079d => android/view/Menu
	i64 4728550804089827080, ; 188: 0x419f2fe744296f08 => android/text/TextUtils
	i64 4729953409142968257, ; 189: 0x41a42b90b41d4fc1 => crc643f46942d9dd1fff9/ListViewAdapter
	i64 4740665257139828038, ; 190: 0x41ca39ef2adaf546 => android/widget/Switch
	i64 4756101769800025001, ; 191: 0x4201115c588983a9 => javax/net/SocketFactory
	i64 4821985032903410129, ; 192: 0x42eb21d6e67541d1 => android/support/design/widget/BottomNavigationView$OnNavigationItemSelectedListener
	i64 4822962236684240355, ; 193: 0x42ee9a99e2b005e3 => crc643f46942d9dd1fff9/Platform_DefaultRenderer
	i64 4857445411681683389, ; 194: 0x43691cddb72347bd => crc643f46942d9dd1fff9/EntryRenderer
	i64 4862236312959872851, ; 195: 0x437a222a57fa6f53 => android/support/v7/app/AppCompatActivity
	i64 4870422290221341992, ; 196: 0x43973744b2c99d28 => android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks
	i64 4901810576126404322, ; 197: 0x4406babf824466e2 => android/support/v4/view/ActionProvider$VisibilityListener
	i64 4919249705507088493, ; 198: 0x4444af8b3a31e86d => android/view/ContextMenu
	i64 4935725956100844684, ; 199: 0x447f389b4210ec8c => android/support/v4/widget/SwipeRefreshLayout$OnChildScrollUpCallback
	i64 5009561527993346848, ; 200: 0x458589aafc81ab20 => android/support/v4/widget/SwipeRefreshLayout
	i64 5136002664802311153, ; 201: 0x4746bf3641005bf1 => crc64720bb2db43a66fe9/MasterDetailPageRenderer
	i64 5207893280228753221, ; 202: 0x48462758842dbf45 => java/lang/annotation/Annotation
	i64 5214467817578676657, ; 203: 0x485d82da477bc1b1 => java/lang/Error
	i64 5227052456348271400, ; 204: 0x488a3883d2f8c328 => android/support/v4/app/ActivityCompat
	i64 5237142432736127056, ; 205: 0x48ae114b855ca850 => crc643f46942d9dd1fff9/TabbedRenderer
	i64 5251140270356514289, ; 206: 0x48dfcc41105945f1 => java/lang/AutoCloseable
	i64 5273367786484979320, ; 207: 0x492ec40ff36cd678 => android/text/InputFilter$LengthFilter
	i64 5295817366893944686, ; 208: 0x497e85d6350edf6e => mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor
	i64 5351646808883735257, ; 209: 0x4a44de6b1ede2ad9 => java/nio/FloatBuffer
	i64 5363761311252235107, ; 210: 0x4a6fe87e812c4363 => crc643f46942d9dd1fff9/GenericAnimatorListener
	i64 5407512276612009785, ; 211: 0x4b0b57c3ee05cf39 => android/view/SurfaceView
	i64 5450483254556749667, ; 212: 0x4ba401a46211ef63 => crc64720bb2db43a66fe9/CarouselPageRenderer
	i64 5517358870160988903, ; 213: 0x4c9198a9024bdae7 => android/text/NoCopySpan
	i64 5561158636972397423, ; 214: 0x4d2d3450e855d36f => crc643f46942d9dd1fff9/NavigationRenderer
	i64 5619483153547007314, ; 215: 0x4dfc6a27a4761552 => android/animation/Animator$AnimatorListener
	i64 5640220797240722407, ; 216: 0x4e4616ee924dc3e7 => android/view/ViewGroup$OnHierarchyChangeListener
	i64 5642493887972642468, ; 217: 0x4e4e2a4bbfec0ea4 => android/graphics/drawable/LayerDrawable
	i64 5642528231169355553, ; 218: 0x4e4e4987e5f66f21 => android/view/View$OnAttachStateChangeListener
	i64 5655204958643352635, ; 219: 0x4e7b52f283f6f43b => android/opengl/GLSurfaceView$Renderer
	i64 5705258333631364930, ; 220: 0x4f2d263a07ef3f42 => crc64720bb2db43a66fe9/NavigationPageRenderer_ClickListener
	i64 5706531890177548175, ; 221: 0x4f31ac8505789f8f => android/support/v7/widget/AppCompatImageButton
	i64 5793982059409158284, ; 222: 0x50685bfc3611b08c => java/net/URLConnection
	i64 5817908791863825879, ; 223: 0x50bd5d38baaa55d7 => android/support/v7/app/ActionBarDrawerToggle
	i64 5854524328054243249, ; 224: 0x513f72db968e3fb1 => java/security/cert/CertificateFactory
	i64 5856823971975629766, ; 225: 0x51479e5f29998bc6 => android/widget/LinearLayout$LayoutParams
	i64 5880236631793339455, ; 226: 0x519acc0fd1480c3f => android/content/pm/PackageInfo
	i64 5890385405214755341, ; 227: 0x51beda5143f88a0d => android/widget/FrameLayout
	i64 5902220174995442397, ; 228: 0x51e8e5fa54bf4add => android/view/accessibility/AccessibilityRecord
	i64 5916786898001085367, ; 229: 0x521ca655d30a43b7 => android/text/style/WrapTogetherSpan
	i64 5928119462157283979, ; 230: 0x5244e93e07f6f28b => android/widget/Adapter
	i64 5991054489085362647, ; 231: 0x53248050dbf141d7 => javax/security/cert/X509Certificate
	i64 6000768439507874839, ; 232: 0x5347031a303df417 => java/lang/Enum
	i64 6012758298688632601, ; 233: 0x53719bd0d19e3719 => android/text/method/DigitsKeyListener
	i64 6082559832693444876, ; 234: 0x546997f0e8c0910c => android/text/SpannableStringBuilder
	i64 6116679261601087867, ; 235: 0x54e2cf6180bb417b => android/widget/LinearLayout
	i64 6134801343243781071, ; 236: 0x552331516fa283cf => javax/microedition/khronos/opengles/GL
	i64 6160296053631453721, ; 237: 0x557dc49f43f18a19 => android/graphics/PorterDuff
	i64 6176491841567975617, ; 238: 0x55b74e9afec1e8c1 => crc643f46942d9dd1fff9/EditorRenderer
	i64 6189424520098966978, ; 239: 0x55e540cedc976dc2 => android/support/design/widget/BottomNavigationView$OnNavigationItemReselectedListener
	i64 6193589699106797389, ; 240: 0x55f40d042bc7774d => android/view/ActionMode
	i64 6338739168512203946, ; 241: 0x57f7b9b08f065caa => android/view/ViewTreeObserver$OnTouchModeChangeListener
	i64 6402346957078774570, ; 242: 0x58d9b4a2e97bc32a => crc643f46942d9dd1fff9/FormattedStringExtensions_LineHeightSpan
	i64 6411888867584788610, ; 243: 0x58fb9af413ac4882 => crc643f46942d9dd1fff9/OpenGLViewRenderer_Renderer
	i64 6435837332721058469, ; 244: 0x5950aff4a10942a5 => android/text/Layout
	i64 6511916058234084579, ; 245: 0x5a5ef92742345ce3 => android/support/v4/app/FragmentPagerAdapter
	i64 6632113080388054259, ; 246: 0x5c09ffb54ac06cf3 => crc643f46942d9dd1fff9/CarouselPageRenderer
	i64 6647905621810810593, ; 247: 0x5c421af0e05b0ee1 => android/support/v4/content/Loader$OnLoadCanceledListener
	i64 6740334783866200195, ; 248: 0x5d8a7ac62b8de083 => javax/net/ssl/SSLSession
	i64 6804602249961354267, ; 249: 0x5e6ecdb1aac5341b => android/view/Window$Callback
	i64 6821119016015783639, ; 250: 0x5ea97b9af04866d7 => crc643f46942d9dd1fff9/BoxRenderer
	i64 6828642768849235381, ; 251: 0x5ec4366b274c6db5 => android/text/style/MetricAffectingSpan
	i64 6887549445287282166, ; 252: 0x5f957dba8b4985f6 => android/view/Surface
	i64 6896370056959110385, ; 253: 0x5fb4d4073cb02cf1 => android/support/v7/app/ActionBar$TabListener
	i64 6920486630358402168, ; 254: 0x600a81ec8b5a4478 => crc643f46942d9dd1fff9/PageRenderer
	i64 7045375789571056070, ; 255: 0x61c633f3de8521c6 => java/lang/Readable
	i64 7045610246270173703, ; 256: 0x61c7093092c94207 => mono/android/app/DatePickerDialog_OnDateSetListenerImplementor
	i64 7094447612930813198, ; 257: 0x62748a84165bed0e => crc64720bb2db43a66fe9/NavigationPageRenderer_DrawerMultiplexedListener
	i64 7177952650586447618, ; 258: 0x639d35e7c0c75f02 => java/text/DecimalFormatSymbols
	i64 7225485130875172081, ; 259: 0x64461471bbae74f1 => crc643f46942d9dd1fff9/EntryCellEditText
	i64 7234103110495206036, ; 260: 0x6464b273799d7a94 => android/graphics/Bitmap$Config
	i64 7282188369651690282, ; 261: 0x650f87bd5091eb2a => android/os/Parcelable
	i64 7291810569935423650, ; 262: 0x6531b714667088a2 => android/os/Build$VERSION
	i64 7349164247998023060, ; 263: 0x65fd79f22dec4594 => java/io/Flushable
	i64 7359209775714103835, ; 264: 0x66212a4cdd05721b => android/content/pm/PackageItemInfo
	i64 7394638939512291408, ; 265: 0x669f08efdfe6c050 => java/lang/reflect/GenericDeclaration
	i64 7404595276730345374, ; 266: 0x66c2682c470c279e => mono/android/view/View_OnKeyListenerImplementor
	i64 7437796681088239247, ; 267: 0x67385cac9fd8068f => java/io/FileDescriptor
	i64 7442283332876516358, ; 268: 0x67484d42a5ea3c06 => crc643f46942d9dd1fff9/ScrollViewRenderer
	i64 7538647566659605431, ; 269: 0x689ea805399bd3b7 => android/view/WindowManager$LayoutParams
	i64 7620119821450638162, ; 270: 0x69c01a9abf7a7352 => java/io/InterruptedIOException
	i64 7643734333815795607, ; 271: 0x6a13ffe0dc8c2f97 => android/view/View$OnFocusChangeListener
	i64 7658195837123306865, ; 272: 0x6a476089fc1c2571 => java/lang/Character
	i64 7667728120009501178, ; 273: 0x6a693e198b70a9fa => android/support/v4/view/ActionProvider
	i64 7681872310366473403, ; 274: 0x6a9b7e2a7d4d8cbb => android/widget/ListAdapter
	i64 7725911356541090107, ; 275: 0x6b37f371f4c9b93b => mono/android/support/design/widget/TabLayout_OnTabSelectedListenerImplementor
	i64 7731510726439183081, ; 276: 0x6b4bd80ada87a2e9 => android/animation/ValueAnimator$AnimatorUpdateListener
	i64 7749032626649128185, ; 277: 0x6b8a181e28555cf9 => android/graphics/drawable/RippleDrawable
	i64 7885555305050563880, ; 278: 0x6d6f1ec53e3c6528 => mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor
	i64 7933543037734065265, ; 279: 0x6e199b5bee699471 => java/util/HashMap
	i64 7937197965565007714, ; 280: 0x6e26977f21749762 => crc643f46942d9dd1fff9/ObjectJavaBox_1
	i64 7949315060988846129, ; 281: 0x6e51a3ee41e72031 => android/content/res/TypedArray
	i64 7977746367831656039, ; 282: 0x6eb6a60dbac4c667 => android/widget/ProgressBar
	i64 7984385532120790879, ; 283: 0x6ece3c569fd3f75f => android/text/method/MetaKeyKeyListener
	i64 8021584804045241339, ; 284: 0x6f5264e10cc9bbfb => crc643f46942d9dd1fff9/PowerSaveModeBroadcastReceiver
	i64 8021886770833017422, ; 285: 0x6f5377842be84a4e => crc643f46942d9dd1fff9/BorderDrawable
	i64 8058145963905469793, ; 286: 0x6fd4490f6ed54d61 => android/view/ContextMenu$ContextMenuInfo
	i64 8101247977958317441, ; 287: 0x706d6a1d1b8e9d81 => android/support/v7/view/menu/SubMenuBuilder
	i64 8124459220754349226, ; 288: 0x70bfe09db535bcaa => crc643f46942d9dd1fff9/ViewRenderer_2
	i64 8190305621607579207, ; 289: 0x71a9cf9199cdfe47 => java/nio/channels/spi/AbstractInterruptibleChannel
	i64 8224466848856033106, ; 290: 0x72232d06210a4752 => android/support/v4/view/ViewPropertyAnimatorCompat
	i64 8362058396472415889, ; 291: 0x740bffceb8cf9691 => mono/android/content/DialogInterface_OnCancelListenerImplementor
	i64 8372779371615156560, ; 292: 0x7432167a43d6f950 => android/widget/SeekBar
	i64 8389281003085257017, ; 293: 0x746cb69fbdd45939 => android/opengl/GLSurfaceView
	i64 8395762569511998269, ; 294: 0x7483bd930648933d => android/media/VolumeShaper$Configuration
	i64 8406198746302890070, ; 295: 0x74a8d138c8b7c056 => android/support/v7/view/ActionMode
	i64 8416619862292774857, ; 296: 0x74cdd72bed753fc9 => java/lang/IllegalArgumentException
	i64 8427024478828076046, ; 297: 0x74f2ce1d7e119c0e => android/text/TextWatcher
	i64 8451791007131160668, ; 298: 0x754acb2437e4d05c => crc643f46942d9dd1fff9/ImageButtonRenderer
	i64 8462361838522003613, ; 299: 0x75705941b1ecf09d => android/os/IBinder
	i64 8479605575929030617, ; 300: 0x75ad9c582cabe7d9 => crc643f46942d9dd1fff9/FormsWebViewClient
	i64 8487642170263250902, ; 301: 0x75ca29959b2aa7d6 => android/content/ContextWrapper
	i64 8567118506271480671, ; 302: 0x76e484e412fc9b5f => android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher
	i64 8587172038193766563, ; 303: 0x772bc378d1b4e0a3 => java/lang/Runnable
	i64 8671513456598690950, ; 304: 0x7857678b8d95ac86 => crc643f46942d9dd1fff9/SearchBarRenderer
	i64 8712284566595978930, ; 305: 0x78e840a7561246b2 => android/view/MenuItem$OnActionExpandListener
	i64 8717832878576044787, ; 306: 0x78fbf6d062bf0af3 => android/view/View$OnCreateContextMenuListener
	i64 8722435519081898203, ; 307: 0x790c50e4232060db => android/app/PendingIntent
	i64 8742443272977515051, ; 308: 0x795365d65ad4022b => android/support/v7/graphics/drawable/DrawerArrowDrawable
	i64 8777167882493340178, ; 309: 0x79cec3af89fbaa12 => android/support/v4/view/ActionProvider$SubUiVisibilityListener
	i64 8784751650103882924, ; 310: 0x79e9b5150877f4ac => android/content/res/Configuration
	i64 8785370249272798009, ; 311: 0x79ebe7b1e030ab39 => android/view/LayoutInflater$Factory2
	i64 8844367584969910381, ; 312: 0x7abd8175851c686d => android/support/v7/widget/ScrollingTabContainerView
	i64 8858493623021718981, ; 313: 0x7aefb1040d45cdc5 => android/support/v7/app/ActionBar$Tab
	i64 8912750119361463117, ; 314: 0x7bb07303045c434d => crc64ee486da937c010f4/LabelRenderer
	i64 8950391188589719199, ; 315: 0x7c362d5d64ad2e9f => java/lang/Boolean
	i64 8972627133644507939, ; 316: 0x7c852cd6cae98b23 => android/view/LayoutInflater
	i64 8981516335682015417, ; 317: 0x7ca4c1856cb1d0b9 => android/graphics/Paint$Style
	i64 9000742728442691829, ; 318: 0x7ce90fd2d381c0f5 => java/io/Reader
	i64 9052904945156302472, ; 319: 0x7da26115516b2688 => android/graphics/Paint
	i64 9064634859678887533, ; 320: 0x7dcc0d60ddc86e6d => crc643f46942d9dd1fff9/ListViewRenderer
	i64 9090354662222454056, ; 321: 0x7e276d670c15dd28 => android/view/ViewTreeObserver$OnGlobalLayoutListener
	i64 9154019302997878316, ; 322: 0x7f099c0e5641e62c => javax/net/ssl/KeyManager
	i64 9187009981601112352, ; 323: 0x7f7ed0e7454d6120 => android/view/ViewGroup$MarginLayoutParams
	i64 9217569019755338609, ; 324: 0x7feb622fcb299b71 => java/security/Principal
	i64 9261475547774197607, ; 325: 0x80875ef0f90c1f67 => android/widget/ImageView
	i64 9266054422632426471, ; 326: 0x8097a3675a716be7 => android/text/SpannableStringInternal
	i64 9355021183435591253, ; 327: 0x81d3b63388eece55 => android/graphics/drawable/Drawable
	i64 9374080444557732201, ; 328: 0x82176c7f91cca969 => android/os/IBinder$DeathRecipient
	i64 9398076398640366642, ; 329: 0x826cacb100f10432 => mono/android/support/v4/widget/SwipeRefreshLayout_OnRefreshListenerImplementor
	i64 9478593896738967145, ; 330: 0x838abaede94fce69 => android/widget/Toast
	i64 9486165718443727475, ; 331: 0x83a5a17608539a73 => android/support/v4/view/TintableBackgroundView
	i64 9507464054666394215, ; 332: 0x83f14c2f5d2f7a67 => android/widget/AbsSeekBar
	i64 9508416549184848137, ; 333: 0x83f4ae79469bc109 => java/lang/ClassLoader
	i64 9567709261674488755, ; 334: 0x84c754e1b052a3b3 => android/support/v4/internal/view/SupportMenuItem
	i64 9592470133784501987, ; 335: 0x851f4cc37ac4dee3 => android/support/v7/widget/Toolbar$OnMenuItemClickListener
	i64 9594314988379616957, ; 336: 0x8525daa62992b6bd => android/widget/Checkable
	i64 9653796168998115956, ; 337: 0x85f92c77bb28da74 => android/view/accessibility/AccessibilityEvent
	i64 9656994348200431989, ; 338: 0x86048931da711175 => android/text/SpannableString
	i64 9667515047141612341, ; 339: 0x8629e9b6f59e9b35 => java/lang/Thread
	i64 9703710885882199699, ; 340: 0x86aa81a364197e93 => android/support/v4/content/Loader$OnLoadCompleteListener
	i64 9785570804745343508, ; 341: 0x87cd54ccfd479214 => java/net/URL
	i64 9800253854282402593, ; 342: 0x88017ef4dd27cb21 => android/view/ViewPropertyAnimator
	i64 9854108034008202699, ; 343: 0x88c0d30c3161bdcb => java/lang/NoClassDefFoundError
	i64 9866983915955550238, ; 344: 0x88ee91981305f81e => java/lang/SecurityException
	i64 9869939015140501507, ; 345: 0x88f9113db837e803 => android/app/Activity
	i64 9872329105174357725, ; 346: 0x89018f03ebaae6dd => crc643f46942d9dd1fff9/VisualElementTracker_AttachTracker
	i64 9903613304640537389, ; 347: 0x8970b3d437ee832d => java/io/Serializable
	i64 9942049212981248440, ; 348: 0x89f941157f3301b8 => java/lang/LinkageError
	i64 9977296435420958008, ; 349: 0x8a767a3efc098d38 => java/lang/NullPointerException
	i64 10026617930792121294, ; 350: 0x8b25b3e27f6d33ce => android/support/v7/app/ActionBar$OnMenuVisibilityListener
	i64 10042311964009466035, ; 351: 0x8b5d75865a7088b3 => crc643f46942d9dd1fff9/GroupedListViewAdapter
	i64 10083342998336719661, ; 352: 0x8bef3b087c484b2d => android/view/ScaleGestureDetector$SimpleOnScaleGestureListener
	i64 10092484235993399888, ; 353: 0x8c0fb4f0bb9dc250 => java/nio/channels/ReadableByteChannel
	i64 10266059374509936169, ; 354: 0x8e785e9bf4bbce29 => java/lang/Long
	i64 10369666936482144324, ; 355: 0x8fe875234c21a044 => android/widget/NumberPicker
	i64 10499957734077086001, ; 356: 0x91b757ed9047b931 => android/view/ViewGroup$LayoutParams
	i64 10541139640792710788, ; 357: 0x9249a6a7693cfe84 => javax/net/ssl/X509TrustManager
	i64 10556732314164660806, ; 358: 0x92810c1b96ac0a46 => android/view/WindowManager
	i64 10589642565195629679, ; 359: 0x92f5f7ce84d7846f => java/lang/UnsupportedOperationException
	i64 10630953461079745996, ; 360: 0x9388bbd8ff5e25cc => crc643f46942d9dd1fff9/ToolbarImageButton
	i64 10655658609895831411, ; 361: 0x93e0810cb2ac7773 => android/content/res/ColorStateList
	i64 10716225606646584894, ; 362: 0x94b7ae69891d563e => crc643f46942d9dd1fff9/ImageRenderer
	i64 10720317155847600942, ; 363: 0x94c637a791d27b2e => javax/microedition/khronos/opengles/GL10
	i64 10722894652849872693, ; 364: 0x94cf5fdfdb0d5f35 => java/lang/Short
	i64 10799644280525089146, ; 365: 0x95e00b411146e97a => android/view/View$OnLayoutChangeListener
	i64 10808978037618020601, ; 366: 0x96013441bd3890f9 => android/database/DataSetObserver
	i64 10822355177435899637, ; 367: 0x9630bab1d02d26f5 => android/support/v4/view/ViewPager
	i64 10876136888617769900, ; 368: 0x96efcce03e959bac => java/lang/Comparable
	i64 10907384891300504216, ; 369: 0x975ed0c4d26de298 => android/app/ActionBar$TabListener
	i64 10945866865468146969, ; 370: 0x97e787eba2f28519 => xamarin/android/net/OldAndroidSSLSocketFactory
	i64 10946785329059892859, ; 371: 0x97eacb421b128e7b => android/media/VolumeShaper
	i64 10974174721552763568, ; 372: 0x984c19c3fd394ab0 => android/support/v4/view/NestedScrollingParent
	i64 11005920483369566278, ; 373: 0x98bce25e25704046 => java/util/Random
	i64 11063973824915032316, ; 374: 0x998b21930647c8fc => android/support/v7/content/res/AppCompatResources
	i64 11112718717483603117, ; 375: 0x9a384ecbbc71d4ad => android/os/Handler
	i64 11172923279375061947, ; 376: 0x9b0e3286a1d7d3bb => java/nio/channels/WritableByteChannel
	i64 11193598785907768118, ; 377: 0x9b57a6ca2046bb36 => android/support/v4/app/FragmentActivity
	i64 11240308327273157113, ; 378: 0x9bfd98deb4fb51f9 => android/graphics/RectF
	i64 11258755641312530828, ; 379: 0x9c3f229ab55bd18c => android/support/v7/app/ActionBar$LayoutParams
	i64 11278579276077267548, ; 380: 0x9c85901859aafa5c => android/support/v4/view/ViewPropertyAnimatorListener
	i64 11291374328304676105, ; 381: 0x9cb305209890ad09 => android/view/GestureDetector
	i64 11348321151605279956, ; 382: 0x9d7d55f61e7c0cd4 => android/view/animation/Animation
	i64 11393831178655295976, ; 383: 0x9e1f05170284e9e8 => javax/net/ssl/SSLContext
	i64 11453358337200194823, ; 384: 0x9ef280b9a6138507 => java/lang/Iterable
	i64 11483835341420025363, ; 385: 0x9f5ec766286ad613 => crc643f46942d9dd1fff9/NavigationMenuRenderer
	i64 11535591933768018538, ; 386: 0xa016a7bede1aaa6a => android/widget/CompoundButton
	i64 11573301743732151818, ; 387: 0xa09ca09e3190560a => mono/java/lang/RunnableImplementor
	i64 11585998938245262039, ; 388: 0xa0c9bca62a296ad7 => mono/android/runtime/JavaArray
	i64 11660738493511124826, ; 389: 0xa1d343e0ec74475a => android/support/v4/app/LoaderManager$LoaderCallbacks
	i64 11712899692065226922, ; 390: 0xa28c94365b5480aa => java/util/ArrayList
	i64 11762375334785567978, ; 391: 0xa33c5a0c18b5ccea => crc64720bb2db43a66fe9/SwitchRenderer
	i64 11763058807128842702, ; 392: 0xa33ec7a966f1e1ce => java/security/cert/Certificate
	i64 11793353799764090647, ; 393: 0xa3aa68cc09711f17 => android/support/v7/widget/DecorToolbar
	i64 11805384242711821632, ; 394: 0xa3d5266bcfd4fd40 => java/nio/channels/SeekableByteChannel
	i64 11857615416441215172, ; 395: 0xa48eb6659c2c98c4 => mono/android/support/v4/view/ViewPager_OnPageChangeListenerImplementor
	i64 11917621648674401280, ; 396: 0xa563e5bf48be2c00 => android/support/v7/widget/SwitchCompat
	i64 11954228872253987625, ; 397: 0xa5e5f3d2b66adb29 => android/view/View
	i64 11957455915006268726, ; 398: 0xa5f16acd27579536 => crc64720bb2db43a66fe9/Platform_ModalContainer
	i64 11964861904226695339, ; 399: 0xa60bba82640938ab => android/view/animation/DecelerateInterpolator
	i64 12000757740207206752, ; 400: 0xa68b4194fc91f160 => crc643f46942d9dd1fff9/ListViewRenderer_Container
	i64 12016049636675011370, ; 401: 0xa6c1957b1579c32a => android/widget/EditText
	i64 12095812086181006791, ; 402: 0xa7dcf5018ab20dc7 => java/text/DecimalFormat
	i64 12204817298245236931, ; 403: 0xa96038ab3a7338c3 => android/animation/Animator
	i64 12228984007958404582, ; 404: 0xa9b61429ce4b1de6 => android/content/Context
	i64 12246361600639158634, ; 405: 0xa9f3d0fde514c96a => java/lang/ClassNotFoundException
	i64 12319111449616420196, ; 406: 0xaaf646980ed58d64 => android/content/ComponentCallbacks
	i64 12411076305208150055, ; 407: 0xac3d002494330827 => android/app/FragmentTransaction
	i64 12426529965699990912, ; 408: 0xac73e72a4c4b8580 => java/lang/IndexOutOfBoundsException
	i64 12448325200866762251, ; 409: 0xacc155d0ee34de0b => android/support/v7/app/ActionBarDrawerToggle$DelegateProvider
	i64 12458575303368155603, ; 410: 0xace5c03ae4b6a1d3 => android/content/res/Resources
	i64 12476375190645835422, ; 411: 0xad24fd221af1069e => android/os/Looper
	i64 12488842103917764438, ; 412: 0xad5147b98bf5df56 => java/lang/IllegalStateException
	i64 12498190180125277945, ; 413: 0xad727dc025a47ef9 => android/view/animation/AccelerateInterpolator
	i64 12512634090014917560, ; 414: 0xada5ce68fbc843b8 => android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator
	i64 12532121860257401396, ; 415: 0xadeb0a6f128cca34 => java/lang/Number
	i64 12562071772572039222, ; 416: 0xae5571b86f1e3836 => java/security/cert/X509Extension
	i64 12621068433101103456, ; 417: 0xaf270adee0e32160 => crc643f46942d9dd1fff9/PickerRenderer
	i64 12621328865392909801, ; 418: 0xaf27f7bb7f20dde9 => android/app/ActionBar
	i64 12636253712611178016, ; 419: 0xaf5cfdcd47e67620 => android/text/style/ParagraphStyle
	i64 12658804585597598720, ; 420: 0xafad1bb38da17c00 => javax/microedition/khronos/egl/EGLConfig
	i64 12787245097144369327, ; 421: 0xb1756baa872540af => android/text/style/CharacterStyle
	i64 12806567541869262104, ; 422: 0xb1ba1153c52a3518 => java/lang/Integer
	i64 12807185847019254324, ; 423: 0xb1bc43ac27fe3234 => android/view/accessibility/AccessibilityEventSource
	i64 12834769660475362759, ; 424: 0xb21e430132984dc7 => android/widget/Filter
	i64 12849974230675558933, ; 425: 0xb254477b10571215 => android/widget/ImageButton
	i64 12872258526589006205, ; 426: 0xb2a372ee0654b17d => android/app/Fragment
	i64 12882710959019299141, ; 427: 0xb2c8955c98609145 => java/net/SocketTimeoutException
	i64 12886242980442099241, ; 428: 0xb2d521b76a9f4e29 => mono/android/support/v4/view/ViewPager_OnAdapterChangeListenerImplementor
	i64 12892837192086809743, ; 429: 0xb2ec8f1df5476c8f => android/arch/lifecycle/LifecycleOwner
	i64 13046320909237610371, ; 430: 0xb50dd7be9cdbe783 => android/content/res/XmlResourceParser
	i64 13069688267367477916, ; 431: 0xb560dc3ba587729c => android/view/KeyEvent$Callback
	i64 13120818853233679472, ; 432: 0xb616833add3ddc70 => android/widget/AdapterView$OnItemClickListener
	i64 13156695805669800571, ; 433: 0xb695f920cad1fa7b => android/widget/SearchView$OnQueryTextListener
	i64 13173632165694986745, ; 434: 0xb6d224a865e8d9f9 => android/support/v4/content/ContextCompat
	i64 13191394589072141775, ; 435: 0xb7113f7cdda7adcf => android/app/AlertDialog$Builder
	i64 13210945690397914619, ; 436: 0xb756b51c5f2535fb => android/view/View$OnKeyListener
	i64 13252491226311317086, ; 437: 0xb7ea4e8e3d44565e => android/view/SurfaceHolder$Callback2
	i64 13291089739636035741, ; 438: 0xb8736fb2f0d8509d => android/content/ComponentName
	i64 13311117679692485447, ; 439: 0xb8ba97011d7e1347 => android/widget/HorizontalScrollView
	i64 13335777145830317192, ; 440: 0xb91232a87cfd1c88 => android/graphics/Point
	i64 13345600704636997934, ; 441: 0xb93519220217512e => crc64ee486da937c010f4/ImageRenderer
	i64 13402681668680117407, ; 442: 0xb9ffe3f79b516c9f => android/view/ViewManager
	i64 13402779434266666368, ; 443: 0xba003ce26e602580 => mono/android/TypeManager
	i64 13491848569179882038, ; 444: 0xbb3cacca71544236 => android/app/AlertDialog
	i64 13493236796125990997, ; 445: 0xbb419b603751d055 => android/graphics/Rect
	i64 13499562364224885079, ; 446: 0xbb5814724edb5157 => java/security/cert/X509Certificate
	i64 13501119006686247638, ; 447: 0xbb5d9c345fcefad6 => android/content/IntentSender
	i64 13521436991516546790, ; 448: 0xbba5cb4ddc2b96e6 => crc643f46942d9dd1fff9/PlatformRenderer
	i64 13533612233700058124, ; 449: 0xbbd10c9f5592a40c => android/support/v4/app/FragmentManager$OnBackStackChangedListener
	i64 13556576098032765635, ; 450: 0xbc22a222a5cb4ac3 => android/util/DisplayMetrics
	i64 13563797115429327528, ; 451: 0xbc3c499cc6a212a8 => android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener
	i64 13573588605631727023, ; 452: 0xbc5f12ebbdf805af => crc643f46942d9dd1fff9/EditorEditText
	i64 13627945243246589944, ; 453: 0xbd202ffeaa2ff7f8 => android/support/v4/view/ViewPager$OnPageChangeListener
	i64 13667817128403725814, ; 454: 0xbdadd7435980edf6 => android/content/DialogInterface$OnCancelListener
	i64 13679302106003776683, ; 455: 0xbdd6a4ca139ba4ab => crc643f46942d9dd1fff9/MasterDetailRenderer
	i64 13725745627141487475, ; 456: 0xbe7ba4ecff23bb73 => crc643f46942d9dd1fff9/CarouselPageAdapter
	i64 13770727111868296170, ; 457: 0xbf1b735909c02bea => java/io/StringWriter
	i64 13771213378118064341, ; 458: 0xbf1d2d9ab8d598d5 => crc643f46942d9dd1fff9/WebViewRenderer
	i64 13789203013919682202, ; 459: 0xbf5d1715346dae9a => java/lang/RuntimeException
	i64 13805562342397192842, ; 460: 0xbf9735ce2f182a8a => android/util/AttributeSet
	i64 13856868001051200059, ; 461: 0xc04d7c07b6224a3b => android/app/ActionBar$Tab
	i64 13877554026709814142, ; 462: 0xc096f9dc61548b7e => android/view/View$OnClickListener
	i64 13959986462581077347, ; 463: 0xc1bbd5b97b683563 => java/net/UnknownServiceException
	i64 13975325537152167595, ; 464: 0xc1f2548816666eab => android/graphics/Typeface
	i64 13983331087350257043, ; 465: 0xc20ec5897e305593 => android/arch/lifecycle/Lifecycle
	i64 13999780448409522890, ; 466: 0xc2493624d0e892ca => crc643f46942d9dd1fff9/StepperRenderer_StepperListener
	i64 14006488896635186732, ; 467: 0xc2610b712264ae2c => java/lang/reflect/AnnotatedElement
	i64 14008091590880237307, ; 468: 0xc266bd15778d96fb => android/os/Process
	i64 14019895060012318725, ; 469: 0xc290ac46c849c005 => android/widget/SearchView
	i64 14024183407882682596, ; 470: 0xc29fe88193c640e4 => android/webkit/WebChromeClient$FileChooserParams
	i64 14031640676547298208, ; 471: 0xc2ba66da3d8603a0 => java/nio/channels/FileChannel
	i64 14048987852729596032, ; 472: 0xc2f808046fb9b880 => android/graphics/ColorFilter
	i64 14083027673250518685, ; 473: 0xc370f70dc217d69d => android/support/v4/view/NestedScrollingChild
	i64 14146902927644867185, ; 474: 0xc453e5425a34ba71 => android/widget/CompoundButton$OnCheckedChangeListener
	i64 14160925941038085484, ; 475: 0xc485b71d9630756c => javax/net/ssl/KeyManagerFactory
	i64 14167891754637755728, ; 476: 0xc49e767c735e8550 => java/lang/Object
	i64 14180814796703042768, ; 477: 0xc4cc5feca7168cd0 => java/lang/ClassCastException
	i64 14199189514772486281, ; 478: 0xc50da7a216771889 => crc643f46942d9dd1fff9/SwitchCellView
	i64 14206023932851353817, ; 479: 0xc525ef800c4d78d9 => mono/android/runtime/OutputStreamAdapter
	i64 14208339614873898855, ; 480: 0xc52e2999c8ab4f67 => android/support/v7/view/menu/MenuBuilder
	i64 14257601591339809660, ; 481: 0xc5dd2d1b78da7b7c => java/nio/channels/InterruptibleChannel
	i64 14264700351198454638, ; 482: 0xc5f665644c92e36e => android/support/design/widget/TabLayout$Tab
	i64 14279287371309537477, ; 483: 0xc62a383594a058c5 => android/view/View$OnTouchListener
	i64 14286876703996837839, ; 484: 0xc6452eaacb88ffcf => crc643f46942d9dd1fff9/FormsTextView
	i64 14322010251493076923, ; 485: 0xc6c2007145bf6fbb => mono/android/support/design/widget/BottomNavigationView_OnNavigationItemReselectedListenerImplementor
	i64 14328901088261815086, ; 486: 0xc6da7b9f3b8dbb2e => android/view/ViewParent
	i64 14330110679548108979, ; 487: 0xc6dec7bd267f20b3 => android/support/v4/view/ViewPager$OnAdapterChangeListener
	i64 14336867079507269659, ; 488: 0xc6f6c8a61a05d81b => android/support/v7/app/AppCompatCallback
	i64 14345827976282778844, ; 489: 0xc7169e8977322cdc => android/support/v4/app/FragmentManager$BackStackEntry
	i64 14348802445188264590, ; 490: 0xc7212fccf9b3f28e => android/widget/ImageView$ScaleType
	i64 14361620789319229198, ; 491: 0xc74eba044a3cdf0e => android/os/Parcel
	i64 14450562110423246060, ; 492: 0xc88ab5ad547f24ec => android/graphics/drawable/BitmapDrawable
	i64 14501341618205132561, ; 493: 0xc93f1d5ecfb48711 => java/lang/Byte
	i64 14511787718764536802, ; 494: 0xc9643a0b20d623e2 => android/app/DatePickerDialog
	i64 14517395435871339070, ; 495: 0xc978263b82fd023e => java/lang/Cloneable
	i64 14580999150803139285, ; 496: 0xca5a1d7965e4bad5 => mono/android/view/View_OnLayoutChangeListenerImplementor
	i64 14586761301410096066, ; 497: 0xca6e961ea1f6a3c2 => android/support/v7/view/menu/MenuItemImpl
	i64 14625880858424029034, ; 498: 0xcaf99126458caf6a => android/support/v4/app/ActivityCompat$PermissionCompatDelegate
	i64 14640111878662023944, ; 499: 0xcb2c202fdfa06b08 => android/webkit/WebChromeClient
	i64 14649586819325063784, ; 500: 0xcb4dc998681d7268 => mono/android/view/View_OnClickListenerImplementor
	i64 14651980134247352019, ; 501: 0xcb564a4d75e4c6d3 => crc64dbeead12be5aee1d/MainActivity
	i64 14684559126920293129, ; 502: 0xcbca08b94b4deb09 => java/lang/CharSequence
	i64 14695071184467598033, ; 503: 0xcbef61626b451ad1 => crc648ebfd8ed4774273c/ScanEditorRenderer
	i64 14698069729433680220, ; 504: 0xcbfa088b92d0f95c => crc64720bb2db43a66fe9/ViewRenderer_2
	i64 14717452127296789712, ; 505: 0xcc3ee4bbbe579cd0 => android/widget/TextView$OnEditorActionListener
	i64 14764224993950000357, ; 506: 0xcce51068645564e5 => android/media/VolumeAutomation
	i64 14772158741961704719, ; 507: 0xcd01401c0c4f050f => crc643f46942d9dd1fff9/FormsAppCompatActivity
	i64 14779218249451183806, ; 508: 0xcd1a54b1b8821ebe => mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor
	i64 14830759644181035942, ; 509: 0xcdd17151d49bfba6 => android/content/res/AssetManager
	i64 14910139244831886973, ; 510: 0xceeb74a557d0ce7d => mono/android/support/design/widget/BottomNavigationView_OnNavigationItemSelectedListenerImplementor
	i64 14940408132235664607, ; 511: 0xcf56fe09e1439cdf => java/lang/Throwable
	i64 14948509518488371302, ; 512: 0xcf73c634db0b8066 => crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer_LongPressGestureListener
	i64 14959579543312699232, ; 513: 0xcf9b1a55dc5a8f60 => android/graphics/drawable/Drawable$Callback
	i64 15083815508423694298, ; 514: 0xd1547a49951f57da => crc64720bb2db43a66fe9/FragmentContainer
	i64 15108754265133970823, ; 515: 0xd1ad13f45bfa7587 => mono/android/content/DialogInterface_OnDismissListenerImplementor
	i64 15178898666151156562, ; 516: 0xd2a647ea65971b52 => javax/net/ssl/HostnameVerifier
	i64 15183122999177041308, ; 517: 0xd2b549ec9302d59c => org/xmlpull/v1/XmlPullParser
	i64 15185804375311197422, ; 518: 0xd2bed09f1aff24ee => android/os/StrictMode$VmPolicy$Builder
	i64 15223859190564664402, ; 519: 0xd34603463c2c3452 => android/text/Editable
	i64 15231680816999329454, ; 520: 0xd361cd008d606eae => crc643f46942d9dd1fff9/ScrollViewContainer
	i64 15274003662808366507, ; 521: 0xd3f82967fbb53dab => crc64720bb2db43a66fe9/PickerRenderer_PickerListener
	i64 15295416057057826855, ; 522: 0xd4443bdd84bcd827 => android/widget/AdapterView$OnItemSelectedListener
	i64 15316719531190525766, ; 523: 0xd48feb431ce61f46 => crc64720bb2db43a66fe9/FormsFragmentPagerAdapter_1
	i64 15322837277219517488, ; 524: 0xd4a5a751dbc87430 => android/support/v7/widget/Toolbar
	i64 15342747890592608016, ; 525: 0xd4ec63eac9256f10 => mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor
	i64 15367873893566575642, ; 526: 0xd545a7e23b08f41a => android/widget/AbsoluteLayout
	i64 15405141220038144642, ; 527: 0xd5ca0e51d719f282 => crc643f46942d9dd1fff9/OpenGLViewRenderer
	i64 15446304586598055563, ; 528: 0xd65c4c2ef8a9fe8b => android/webkit/WebResourceRequest
	i64 15633873768898914415, ; 529: 0xd8f6ad5c6a84686f => java/io/Writer
	i64 15645438581444444576, ; 530: 0xd91fc37f2a3001a0 => java/lang/Appendable
	i64 15646475415257129974, ; 531: 0xd923727dd948a3f6 => android/support/v4/app/TaskStackBuilder$SupportParentable
	i64 15657103049730837144, ; 532: 0xd9493444d2e44a98 => crc64ee486da937c010f4/ButtonRenderer
	i64 15708621257972649398, ; 533: 0xda003bce689c0db6 => android/support/v4/app/TaskStackBuilder
	i64 15754232915833045684, ; 534: 0xdaa2475e10fec2b4 => android/support/v4/content/Loader
	i64 15767615218119146656, ; 535: 0xdad1d2801f08fca0 => javax/net/ssl/SSLSessionContext
	i64 15773125449763329298, ; 536: 0xdae56606e6d11512 => mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor
	i64 15773716038598610423, ; 537: 0xdae77f2a148d4df7 => java/security/KeyStore$LoadStoreParameter
	i64 15795508579813667467, ; 538: 0xdb34eb5d7a6db28b => android/graphics/Paint$FontMetricsInt
	i64 15822621356783831935, ; 539: 0xdb953e4aca9c0b7f => mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor
	i64 15827905324826524828, ; 540: 0xdba8040878cc7c9c => android/app/TimePickerDialog
	i64 15844004444849296506, ; 541: 0xdbe13618f2f3d47a => android/widget/ListView
	i64 15848783781633547342, ; 542: 0xdbf230e1023d5c4e => android/support/v4/widget/DrawerLayout$LayoutParams
	i64 15888603495552893685, ; 543: 0xdc7fa8b2a175c2f5 => javax/net/ssl/TrustManager
	i64 15896143924811176167, ; 544: 0xdc9a72ada0da98e7 => java/net/SocketException
	i64 15949051304247903982, ; 545: 0xdd5669a8d62d46ee => java/nio/channels/ByteChannel
	i64 16002286839467779661, ; 546: 0xde138b18c462a64d => android/os/Environment
	i64 16003229482241506982, ; 547: 0xde16e46ce4103ea6 => android/graphics/Bitmap
	i64 16066423801151412293, ; 548: 0xdef76752d682d845 => android/runtime/XmlReaderPullParser
	i64 16101147842785907581, ; 549: 0xdf72c4a7cd4d137d => android/webkit/WebViewClient
	i64 16170603982710859185, ; 550: 0xe06986a590ff65b1 => android/view/ViewTreeObserver
	i64 16182470099411896328, ; 551: 0xe093aed127d38808 => android/view/animation/BaseInterpolator
	i64 16184636679460029152, ; 552: 0xe09b614f61f902e0 => crc643f46942d9dd1fff9/PageContainer
	i64 16190756894633167149, ; 553: 0xe0b11f9d0551092d => crc643f46942d9dd1fff9/SliderRenderer
	i64 16207444841424110295, ; 554: 0xe0ec693669d242d7 => android/view/ScaleGestureDetector
	i64 16210892175738935344, ; 555: 0xe0f8a88b7b141830 => android/support/v4/app/FragmentTransaction
	i64 16218544741485660249, ; 556: 0xe113d8834a084859 => android/os/Vibrator
	i64 16234405416196530497, ; 557: 0xe14c31b664126141 => android/support/v4/widget/TintableImageSourceView
	i64 16314168557433322311, ; 558: 0xe26791dde7a8fb47 => android/view/ContextThemeWrapper
	i64 16330840197502951594, ; 559: 0xe2a2cca297d560aa => android/support/v4/widget/DrawerLayout
	i64 16395504991077438774, ; 560: 0xe38888ec1a509536 => java/nio/ByteBuffer
	i64 16413651262945443612, ; 561: 0xe3c900dc43013f1c => android/content/DialogInterface$OnClickListener
	i64 16480206070542885578, ; 562: 0xe4b5741af3f1e2ca => android/view/SearchEvent
	i64 16520646694250929558, ; 563: 0xe54520a3668edd96 => crc64720bb2db43a66fe9/NavigationPageRenderer
	i64 16542847110558016359, ; 564: 0xe593ffcc9e686367 => android/app/Application
	i64 16543572318389959461, ; 565: 0xe596935f399e7b25 => java/lang/reflect/TypeVariable
	i64 16603717322881265010, ; 566: 0xe66c40ef55566d72 => mono/android/runtime/JavaObject
	i64 16618397473501528129, ; 567: 0xe6a06874404ec041 => android/graphics/Path
	i64 16723123314454325679, ; 568: 0xe814780d351a69af => mono/android/runtime/InputStreamAdapter
	i64 16732048506261937943, ; 569: 0xe8342d775c591f17 => android/graphics/PorterDuff$Mode
	i64 16735183474145407832, ; 570: 0xe83f50b3f36cb358 => android/text/style/UpdateLayout
	i64 16743839988290427945, ; 571: 0xe85e11c1b6081c29 => crc643f46942d9dd1fff9/DatePickerRenderer
	i64 16831059047218392927, ; 572: 0xe993ef075713af5f => android/support/v4/app/FragmentManager
	i64 16832017439803262409, ; 573: 0xe99756ae80a745c9 => android/view/ViewGroup
	i64 16886494691722586142, ; 574: 0xea58e17421a4e81e => android/support/v7/view/ActionMode$Callback
	i64 16956975321015960914, ; 575: 0xeb5347366a38c552 => android/arch/lifecycle/LifecycleObserver
	i64 16987790575813017173, ; 576: 0xebc0c18606103e55 => android/text/method/BaseKeyListener
	i64 17087082119009568903, ; 577: 0xed2182a7ef7e8887 => android/support/v4/app/ActionBarDrawerToggle
	i64 17125416866214736517, ; 578: 0xeda9b3e7cd367285 => java/io/OutputStream
	i64 17160619788918981836, ; 579: 0xee26c4c6f40e04cc => android/widget/Filter$FilterListener
	i64 17163176023095185573, ; 580: 0xee2fd9a89a1710a5 => android/graphics/Matrix
	i64 17248310304003843424, ; 581: 0xef5e4ed605dbe560 => crc643f46942d9dd1fff9/FormattedStringExtensions_FontSpan
	i64 17271699332400403176, ; 582: 0xefb167088f13d2e8 => crc64720bb2db43a66fe9/PickerRenderer
	i64 17296586735193580360, ; 583: 0xf009d1fe91f26348 => android/content/pm/ApplicationInfo
	i64 17308034145719428191, ; 584: 0xf0327d5a87f0245f => android/webkit/WebResourceError
	i64 17312589003384955623, ; 585: 0xf042abf8f91822e7 => android/view/KeyEvent
	i64 17335113368509546418, ; 586: 0xf092b1c36722ffb2 => crc643f46942d9dd1fff9/StepperRenderer
	i64 17447197338670049357, ; 587: 0xf220e58a5191a84d => com/xamarin/formsviewgroup/BuildConfig
	i64 17490083481060646178, ; 588: 0xf2b94242748c1d22 => java/util/Enumeration
	i64 17498018958444438720, ; 589: 0xf2d57388c321a4c0 => java/lang/Double
	i64 17499752140262191063, ; 590: 0xf2db9bda99b5afd7 => java/lang/ReflectiveOperationException
	i64 17519581955836770800, ; 591: 0xf3220ef752fe79f0 => java/security/KeyStore
	i64 17538811322615079868, ; 592: 0xf3665ff92b1223bc => crc643f46942d9dd1fff9/FormsEditText
	i64 17542023464739623563, ; 593: 0xf371c966495f528b => android/view/Display
	i64 17596506991874737020, ; 594: 0xf43359e0fa5f037c => crc64720bb2db43a66fe9/ButtonRenderer_ButtonClickListener
	i64 17605619666541934257, ; 595: 0xf453b9cee2dcf6b1 => java/net/Proxy$Type
	i64 17608877981747935975, ; 596: 0xf45f4d3a83487ae7 => java/nio/Buffer
	i64 17645817129531856090, ; 597: 0xf4e28930113fd4da => java/io/Closeable
	i64 17687065826521364603, ; 598: 0xf57514a8bcc1b87b => android/text/style/BackgroundColorSpan
	i64 17744382674255609899, ; 599: 0xf640b607499a002b => crc643f46942d9dd1fff9/SwitchRenderer
	i64 17745042697172967835, ; 600: 0xf6430e50d922619b => android/text/ParcelableSpan
	i64 17746158878128180549, ; 601: 0xf6470579fa798d45 => crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuAdapter
	i64 17749278089719554056, ; 602: 0xf6521a62055ba008 => android/widget/RelativeLayout$LayoutParams
	i64 17781986260136272809, ; 603: 0xf6c64e4a644ca3a9 => android/support/design/widget/BottomNavigationView
	i64 17786854109604896016, ; 604: 0xf6d79992eab25d10 => android/graphics/BitmapFactory
	i64 17788124045174641618, ; 605: 0xf6dc1c92d53813d2 => crc643f46942d9dd1fff9/CellAdapter
	i64 17800186900405514025, ; 606: 0xf706f7ad2e3b6f29 => android/util/SparseArray
	i64 17895748352441210017, ; 607: 0xf85a784f910a54a1 => android/widget/GridView
	i64 17903865051357062176, ; 608: 0xf8774e67ccab2420 => android/support/v4/view/PagerAdapter
	i64 17984345105063787081, ; 609: 0xf9953a96815cba49 => android/view/GestureDetector$OnGestureListener
	i64 17992660388602075186, ; 610: 0xf9b2c54b52de5832 => android/webkit/WebView
	i64 18018038416899488951, ; 611: 0xfa0cee79fca2bcb7 => java/text/Format
	i64 18028883106873553108, ; 612: 0xfa3375aa223d30d4 => mono/android/animation/AnimatorEventDispatcher
	i64 18060209084809406592, ; 613: 0xfaa2c079bd58e880 => android/view/GestureDetector$OnDoubleTapListener
	i64 18061550498792724772, ; 614: 0xfaa7847c0551d924 => crc643f46942d9dd1fff9/FrameRenderer_FrameDrawable
	i64 18125914252927385281, ; 615: 0xfb8c2efa52ed3ec1 => crc64720bb2db43a66fe9/ButtonRenderer
	i64 18147084215524795216, ; 616: 0xfbd764f257742350 => crc643f46942d9dd1fff9/ViewRenderer
	i64 18216578448169670053, ; 617: 0xfcce4995423095a5 => javax/net/ssl/SSLSocketFactory
	i64 18323076787180290332, ; 618: 0xfe48a5421416411c => android/widget/BaseAdapter
	i64 18384173819407763813, ; 619: 0xff21b4af6ad60965 => android/os/StrictMode$VmPolicy
	i64 18401512074820890716, ; 620: 0xff5f4dbc95c2b05c => java/lang/Float
	i64 18401692079723824300, ; 621: 0xff5ff1733e0ec4ac => java/util/Collection
	i64 18423750710588684965, ; 622: 0xffae4fa876fd3aa5 => android/support/v7/widget/CardView
	i64 18428032965843356101 ; 623: 0xffbd8658b64809c5 => android/widget/AbsoluteLayout$LayoutParams
], align 16

; java_type_names
@__java_type_names.0 = internal constant [54 x i8] c"crc643f46942d9dd1fff9/PageExtensions_EmbeddedFragment\00", align 16
@__java_type_names.1 = internal constant [61 x i8] c"crc643f46942d9dd1fff9/PageExtensions_EmbeddedSupportFragment\00", align 16
@__java_type_names.2 = internal constant [34 x i8] c"crc643f46942d9dd1fff9/CellAdapter\00", align 16
@__java_type_names.3 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/EntryCellEditText\00", align 16
@__java_type_names.4 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryCellView\00", align 16
@__java_type_names.5 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SwitchCellView\00", align 16
@__java_type_names.6 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/FormsAppCompatActivity\00", align 16
@__java_type_names.7 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ImageButtonRenderer\00", align 16
@__java_type_names.8 = internal constant [62 x i8] c"crc643f46942d9dd1fff9/GestureManager_TapAndPanGestureDetector\00", align 16
@__java_type_names.9 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/FormsApplicationActivity\00", align 16
@__java_type_names.10 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/AndroidActivity\00", align 16
@__java_type_names.11 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/BaseCellView\00", align 16
@__java_type_names.12 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/CellRenderer_RendererHolder\00", align 16
@__java_type_names.13 = internal constant [52 x i8] c"crc643f46942d9dd1fff9/TextCellRenderer_TextCellView\00", align 16
@__java_type_names.14 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer\00", align 16
@__java_type_names.15 = internal constant [82 x i8] c"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer_LongPressGestureListener\00", align 16
@__java_type_names.16 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/FormsWebViewClient\00", align 16
@__java_type_names.17 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/InnerGestureListener\00", align 16
@__java_type_names.18 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/InnerScaleListener\00", align 16
@__java_type_names.19 = internal constant [48 x i8] c"crc643f46942d9dd1fff9/NativeViewWrapperRenderer\00", align 16
@__java_type_names.20 = internal constant [53 x i8] c"crc643f46942d9dd1fff9/PowerSaveModeBroadcastReceiver\00", align 16
@__java_type_names.21 = internal constant [44 x i8] c"crc643f46942d9dd1fff9/AHorizontalScrollView\00", align 16
@__java_type_names.22 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/BorderDrawable\00", align 16
@__java_type_names.23 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer\00", align 16
@__java_type_names.24 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer_ButtonClickListener\00", align 16
@__java_type_names.25 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer_ButtonTouchListener\00", align 16
@__java_type_names.26 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/ConditionalFocusLayout\00", align 16
@__java_type_names.27 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FormsEditText\00", align 16
@__java_type_names.28 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryEditText\00", align 16
@__java_type_names.29 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/EditorEditText\00", align 16
@__java_type_names.30 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_FontSpan\00", align 16
@__java_type_names.31 = internal constant [67 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_TextDecorationSpan\00", align 16
@__java_type_names.32 = internal constant [63 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_LineHeightSpan\00", align 16
@__java_type_names.33 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/FormsImageView\00", align 16
@__java_type_names.34 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FormsTextView\00", align 16
@__java_type_names.35 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/FormsWebChromeClient\00", align 16
@__java_type_names.36 = internal constant [46 x i8] c"crc643f46942d9dd1fff9/GenericAnimatorListener\00", align 16
@__java_type_names.37 = internal constant [49 x i8] c"crc643f46942d9dd1fff9/LocalizedDigitsKeyListener\00", align 16
@__java_type_names.38 = internal constant [44 x i8] c"crc643f46942d9dd1fff9/MasterDetailContainer\00", align 16
@__java_type_names.39 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/PageContainer\00", align 16
@__java_type_names.40 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ScrollViewContainer\00", align 16
@__java_type_names.41 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/ToolbarButton\00", align 16
@__java_type_names.42 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/ToolbarImageButton\00", align 16
@__java_type_names.43 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/GenericMenuClickListener\00", align 16
@__java_type_names.44 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/ViewRenderer\00", align 16
@__java_type_names.45 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/ViewRenderer_2\00", align 16
@__java_type_names.46 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/Platform_DefaultRenderer\00", align 16
@__java_type_names.47 = internal constant [39 x i8] c"crc643f46942d9dd1fff9/PlatformRenderer\00", align 16
@__java_type_names.48 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ActionSheetRenderer\00", align 16
@__java_type_names.49 = internal constant [48 x i8] c"crc643f46942d9dd1fff9/ActivityIndicatorRenderer\00", align 16
@__java_type_names.50 = internal constant [34 x i8] c"crc643f46942d9dd1fff9/BoxRenderer\00", align 16
@__java_type_names.51 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/CarouselPageRenderer\00", align 16
@__java_type_names.52 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/DatePickerRenderer\00", align 16
@__java_type_names.53 = internal constant [63 x i8] c"crc643f46942d9dd1fff9/DatePickerRenderer_TextFieldClickHandler\00", align 16
@__java_type_names.54 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/EditorRenderer\00", align 16
@__java_type_names.55 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryRenderer\00", align 16
@__java_type_names.56 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FrameRenderer\00", align 16
@__java_type_names.57 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/FrameRenderer_FrameDrawable\00", align 16
@__java_type_names.58 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/ImageRenderer\00", align 16
@__java_type_names.59 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/LabelRenderer\00", align 16
@__java_type_names.60 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/ListViewAdapter\00", align 16
@__java_type_names.61 = internal constant [39 x i8] c"crc643f46942d9dd1fff9/ListViewRenderer\00", align 16
@__java_type_names.62 = internal constant [49 x i8] c"crc643f46942d9dd1fff9/ListViewRenderer_Container\00", align 16
@__java_type_names.63 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/MasterDetailRenderer\00", align 16
@__java_type_names.64 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer\00", align 16
@__java_type_names.65 = internal constant [61 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuElementView\00", align 16
@__java_type_names.66 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuAdapter\00", align 16
@__java_type_names.67 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/NavigationRenderer\00", align 16
@__java_type_names.68 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/ObjectJavaBox_1\00", align 16
@__java_type_names.69 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/CarouselPageAdapter\00", align 16
@__java_type_names.70 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/PageRenderer\00", align 16
@__java_type_names.71 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ProgressBarRenderer\00", align 16
@__java_type_names.72 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/ScrollViewRenderer\00", align 16
@__java_type_names.73 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/SearchBarRenderer\00", align 16
@__java_type_names.74 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SliderRenderer\00", align 16
@__java_type_names.75 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/StepperRenderer\00", align 16
@__java_type_names.76 = internal constant [54 x i8] c"crc643f46942d9dd1fff9/StepperRenderer_StepperListener\00", align 16
@__java_type_names.77 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SwitchRenderer\00", align 16
@__java_type_names.78 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/TabbedRenderer\00", align 16
@__java_type_names.79 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/TableViewModelRenderer\00", align 16
@__java_type_names.80 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/TableViewRenderer\00", align 16
@__java_type_names.81 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/TimePickerRenderer\00", align 16
@__java_type_names.82 = internal constant [60 x i8] c"crc643f46942d9dd1fff9/TimePickerRenderer_TimePickerListener\00", align 16
@__java_type_names.83 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/WebViewRenderer\00", align 16
@__java_type_names.84 = internal constant [55 x i8] c"crc643f46942d9dd1fff9/WebViewRenderer_JavascriptResult\00", align 16
@__java_type_names.85 = internal constant [46 x i8] c"crc643f46942d9dd1fff9/VisualElementRenderer_1\00", align 16
@__java_type_names.86 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/VisualElementTracker_AttachTracker\00", align 16
@__java_type_names.87 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/PickerRenderer\00", align 16
@__java_type_names.88 = internal constant [52 x i8] c"crc643f46942d9dd1fff9/PickerRenderer_PickerListener\00", align 16
@__java_type_names.89 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/OpenGLViewRenderer\00", align 16
@__java_type_names.90 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/OpenGLViewRenderer_Renderer\00", align 16
@__java_type_names.91 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/FormsSeekBar\00", align 16
@__java_type_names.92 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/GroupedListViewAdapter\00", align 16
@__java_type_names.93 = internal constant [37 x i8] c"crc64ee486da937c010f4/ButtonRenderer\00", align 16
@__java_type_names.94 = internal constant [36 x i8] c"crc64ee486da937c010f4/FrameRenderer\00", align 16
@__java_type_names.95 = internal constant [36 x i8] c"crc64ee486da937c010f4/LabelRenderer\00", align 16
@__java_type_names.96 = internal constant [36 x i8] c"crc64ee486da937c010f4/ImageRenderer\00", align 16
@__java_type_names.97 = internal constant [36 x i8] c"crc64720bb2db43a66fe9/FrameRenderer\00", align 16
@__java_type_names.98 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/FormsViewPager\00", align 16
@__java_type_names.99 = internal constant [40 x i8] c"crc64720bb2db43a66fe9/FragmentContainer\00", align 16
@__java_type_names.100 = internal constant [44 x i8] c"crc64720bb2db43a66fe9/MasterDetailContainer\00", align 16
@__java_type_names.101 = internal constant [46 x i8] c"crc64720bb2db43a66fe9/Platform_ModalContainer\00", align 16
@__java_type_names.102 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer\00", align 16
@__java_type_names.103 = internal constant [57 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer_ButtonClickListener\00", align 16
@__java_type_names.104 = internal constant [57 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer_ButtonTouchListener\00", align 16
@__java_type_names.105 = internal constant [47 x i8] c"crc64720bb2db43a66fe9/MasterDetailPageRenderer\00", align 16
@__java_type_names.106 = internal constant [45 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer\00", align 16
@__java_type_names.107 = internal constant [59 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_ClickListener\00", align 16
@__java_type_names.108 = internal constant [55 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_Container\00", align 16
@__java_type_names.109 = internal constant [71 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_DrawerMultiplexedListener\00", align 16
@__java_type_names.110 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/SwitchRenderer\00", align 16
@__java_type_names.111 = internal constant [41 x i8] c"crc64720bb2db43a66fe9/TabbedPageRenderer\00", align 16
@__java_type_names.112 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/PickerRenderer\00", align 16
@__java_type_names.113 = internal constant [52 x i8] c"crc64720bb2db43a66fe9/PickerRenderer_PickerListener\00", align 16
@__java_type_names.114 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/ViewRenderer_2\00", align 16
@__java_type_names.115 = internal constant [43 x i8] c"crc64720bb2db43a66fe9/CarouselPageRenderer\00", align 16
@__java_type_names.116 = internal constant [50 x i8] c"crc64720bb2db43a66fe9/FormsFragmentPagerAdapter_1\00", align 16
@__java_type_names.117 = internal constant [47 x i8] c"android/support/v4/widget/AutoSizeableTextView\00", align 16
@__java_type_names.118 = internal constant [50 x i8] c"android/support/v4/widget/TintableImageSourceView\00", align 16
@__java_type_names.119 = internal constant [41 x i8] c"android/support/v4/widget/TextViewCompat\00", align 16
@__java_type_names.120 = internal constant [39 x i8] c"android/support/v4/view/ActionProvider\00", align 16
@__java_type_names.121 = internal constant [63 x i8] c"android/support/v4/view/ActionProvider$SubUiVisibilityListener\00", align 16
@__java_type_names.122 = internal constant [79 x i8] c"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor\00", align 16
@__java_type_names.123 = internal constant [58 x i8] c"android/support/v4/view/ActionProvider$VisibilityListener\00", align 16
@__java_type_names.124 = internal constant [74 x i8] c"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor\00", align 16
@__java_type_names.125 = internal constant [45 x i8] c"android/support/v4/view/NestedScrollingChild\00", align 16
@__java_type_names.126 = internal constant [46 x i8] c"android/support/v4/view/NestedScrollingParent\00", align 16
@__java_type_names.127 = internal constant [47 x i8] c"android/support/v4/view/TintableBackgroundView\00", align 16
@__java_type_names.128 = internal constant [53 x i8] c"android/support/v4/view/ViewPropertyAnimatorListener\00", align 16
@__java_type_names.129 = internal constant [59 x i8] c"android/support/v4/view/ViewPropertyAnimatorUpdateListener\00", align 16
@__java_type_names.130 = internal constant [51 x i8] c"android/support/v4/view/ScaleGestureDetectorCompat\00", align 16
@__java_type_names.131 = internal constant [51 x i8] c"android/support/v4/view/ViewPropertyAnimatorCompat\00", align 16
@__java_type_names.132 = internal constant [45 x i8] c"android/support/v4/internal/view/SupportMenu\00", align 16
@__java_type_names.133 = internal constant [49 x i8] c"android/support/v4/internal/view/SupportMenuItem\00", align 16
@__java_type_names.134 = internal constant [52 x i8] c"android/support/v4/graphics/drawable/DrawableCompat\00", align 16
@__java_type_names.135 = internal constant [41 x i8] c"android/support/v4/content/ContextCompat\00", align 16
@__java_type_names.136 = internal constant [38 x i8] c"android/support/v4/app/ActivityCompat\00", align 16
@__java_type_names.137 = internal constant [73 x i8] c"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback\00", align 16
@__java_type_names.138 = internal constant [63 x i8] c"android/support/v4/app/ActivityCompat$PermissionCompatDelegate\00", align 16
@__java_type_names.139 = internal constant [77 x i8] c"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator\00", align 16
@__java_type_names.140 = internal constant [45 x i8] c"android/support/v4/app/SharedElementCallback\00", align 16
@__java_type_names.141 = internal constant [75 x i8] c"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener\00", align 16
@__java_type_names.142 = internal constant [33 x i8] c"android/arch/lifecycle/Lifecycle\00", align 16
@__java_type_names.143 = internal constant [39 x i8] c"android/arch/lifecycle/Lifecycle$State\00", align 16
@__java_type_names.144 = internal constant [41 x i8] c"android/arch/lifecycle/LifecycleObserver\00", align 16
@__java_type_names.145 = internal constant [38 x i8] c"android/arch/lifecycle/LifecycleOwner\00", align 16
@__java_type_names.146 = internal constant [45 x i8] c"android/support/v4/app/ActionBarDrawerToggle\00", align 16
@__java_type_names.147 = internal constant [37 x i8] c"android/support/v4/view/PagerAdapter\00", align 16
@__java_type_names.148 = internal constant [34 x i8] c"android/support/v4/view/ViewPager\00", align 16
@__java_type_names.149 = internal constant [58 x i8] c"android/support/v4/view/ViewPager$OnAdapterChangeListener\00", align 16
@__java_type_names.150 = internal constant [74 x i8] c"mono/android/support/v4/view/ViewPager_OnAdapterChangeListenerImplementor\00", align 16
@__java_type_names.151 = internal constant [55 x i8] c"android/support/v4/view/ViewPager$OnPageChangeListener\00", align 16
@__java_type_names.152 = internal constant [71 x i8] c"mono/android/support/v4/view/ViewPager_OnPageChangeListenerImplementor\00", align 16
@__java_type_names.153 = internal constant [50 x i8] c"android/support/v4/view/ViewPager$PageTransformer\00", align 16
@__java_type_names.154 = internal constant [45 x i8] c"android/support/v4/widget/SwipeRefreshLayout\00", align 16
@__java_type_names.155 = internal constant [69 x i8] c"android/support/v4/widget/SwipeRefreshLayout$OnChildScrollUpCallback\00", align 16
@__java_type_names.156 = internal constant [63 x i8] c"android/support/v4/widget/SwipeRefreshLayout$OnRefreshListener\00", align 16
@__java_type_names.157 = internal constant [79 x i8] c"mono/android/support/v4/widget/SwipeRefreshLayout_OnRefreshListenerImplementor\00", align 16
@__java_type_names.158 = internal constant [39 x i8] c"android/support/v4/widget/DrawerLayout\00", align 16
@__java_type_names.159 = internal constant [54 x i8] c"android/support/v4/widget/DrawerLayout$DrawerListener\00", align 16
@__java_type_names.160 = internal constant [70 x i8] c"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor\00", align 16
@__java_type_names.161 = internal constant [52 x i8] c"android/support/v4/widget/DrawerLayout$LayoutParams\00", align 16
@__java_type_names.162 = internal constant [35 x i8] c"android/support/v7/widget/CardView\00", align 16
@__java_type_names.163 = internal constant [57 x i8] c"android/support/v7/graphics/drawable/DrawerArrowDrawable\00", align 16
@__java_type_names.164 = internal constant [50 x i8] c"android/support/v7/content/res/AppCompatResources\00", align 16
@__java_type_names.165 = internal constant [35 x i8] c"android/support/v7/view/ActionMode\00", align 16
@__java_type_names.166 = internal constant [44 x i8] c"android/support/v7/view/ActionMode$Callback\00", align 16
@__java_type_names.167 = internal constant [52 x i8] c"android/support/v7/view/menu/MenuPresenter$Callback\00", align 16
@__java_type_names.168 = internal constant [43 x i8] c"android/support/v7/view/menu/MenuPresenter\00", align 16
@__java_type_names.169 = internal constant [38 x i8] c"android/support/v7/view/menu/MenuView\00", align 16
@__java_type_names.170 = internal constant [41 x i8] c"android/support/v7/view/menu/MenuBuilder\00", align 16
@__java_type_names.171 = internal constant [50 x i8] c"android/support/v7/view/menu/MenuBuilder$Callback\00", align 16
@__java_type_names.172 = internal constant [42 x i8] c"android/support/v7/view/menu/MenuItemImpl\00", align 16
@__java_type_names.173 = internal constant [44 x i8] c"android/support/v7/view/menu/SubMenuBuilder\00", align 16
@__java_type_names.174 = internal constant [34 x i8] c"android/support/v7/widget/Toolbar\00", align 16
@__java_type_names.175 = internal constant [67 x i8] c"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher\00", align 16
@__java_type_names.176 = internal constant [58 x i8] c"android/support/v7/widget/Toolbar$OnMenuItemClickListener\00", align 16
@__java_type_names.177 = internal constant [74 x i8] c"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor\00", align 16
@__java_type_names.178 = internal constant [42 x i8] c"android/support/v7/widget/AppCompatButton\00", align 16
@__java_type_names.179 = internal constant [47 x i8] c"android/support/v7/widget/AppCompatImageButton\00", align 16
@__java_type_names.180 = internal constant [39 x i8] c"android/support/v7/widget/DecorToolbar\00", align 16
@__java_type_names.181 = internal constant [52 x i8] c"android/support/v7/widget/ScrollingTabContainerView\00", align 16
@__java_type_names.182 = internal constant [75 x i8] c"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener\00", align 16
@__java_type_names.183 = internal constant [39 x i8] c"android/support/v7/widget/SwitchCompat\00", align 16
@__java_type_names.184 = internal constant [33 x i8] c"android/support/v7/app/ActionBar\00", align 16
@__java_type_names.185 = internal constant [46 x i8] c"android/support/v7/app/ActionBar$LayoutParams\00", align 16
@__java_type_names.186 = internal constant [58 x i8] c"android/support/v7/app/ActionBar$OnMenuVisibilityListener\00", align 16
@__java_type_names.187 = internal constant [74 x i8] c"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor\00", align 16
@__java_type_names.188 = internal constant [54 x i8] c"android/support/v7/app/ActionBar$OnNavigationListener\00", align 16
@__java_type_names.189 = internal constant [37 x i8] c"android/support/v7/app/ActionBar$Tab\00", align 16
@__java_type_names.190 = internal constant [45 x i8] c"android/support/v7/app/ActionBar$TabListener\00", align 16
@__java_type_names.191 = internal constant [45 x i8] c"android/support/v7/app/ActionBarDrawerToggle\00", align 16
@__java_type_names.192 = internal constant [54 x i8] c"android/support/v7/app/ActionBarDrawerToggle$Delegate\00", align 16
@__java_type_names.193 = internal constant [62 x i8] c"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider\00", align 16
@__java_type_names.194 = internal constant [41 x i8] c"android/support/v7/app/AppCompatActivity\00", align 16
@__java_type_names.195 = internal constant [41 x i8] c"android/support/v7/app/AppCompatDelegate\00", align 16
@__java_type_names.196 = internal constant [41 x i8] c"android/support/v7/app/AppCompatCallback\00", align 16
@__java_type_names.197 = internal constant [35 x i8] c"crc64dbeead12be5aee1d/MainActivity\00", align 16
@__java_type_names.198 = internal constant [41 x i8] c"crc648ebfd8ed4774273c/ScanEditorRenderer\00", align 16
@__java_type_names.199 = internal constant [47 x i8] c"xamarin/android/net/OldAndroidSSLSocketFactory\00", align 16
@__java_type_names.200 = internal constant [29 x i8] c"org/xmlpull/v1/XmlPullParser\00", align 16
@__java_type_names.201 = internal constant [38 x i8] c"org/xmlpull/v1/XmlPullParserException\00", align 16
@__java_type_names.202 = internal constant [32 x i8] c"javax/security/cert/Certificate\00", align 16
@__java_type_names.203 = internal constant [36 x i8] c"javax/security/cert/X509Certificate\00", align 16
@__java_type_names.204 = internal constant [24 x i8] c"javax/net/SocketFactory\00", align 16
@__java_type_names.205 = internal constant [33 x i8] c"javax/net/ssl/HttpsURLConnection\00", align 16
@__java_type_names.206 = internal constant [31 x i8] c"javax/net/ssl/HostnameVerifier\00", align 16
@__java_type_names.207 = internal constant [25 x i8] c"javax/net/ssl/KeyManager\00", align 16
@__java_type_names.208 = internal constant [25 x i8] c"javax/net/ssl/SSLSession\00", align 16
@__java_type_names.209 = internal constant [32 x i8] c"javax/net/ssl/SSLSessionContext\00", align 16
@__java_type_names.210 = internal constant [27 x i8] c"javax/net/ssl/TrustManager\00", align 16
@__java_type_names.211 = internal constant [31 x i8] c"javax/net/ssl/X509TrustManager\00", align 16
@__java_type_names.212 = internal constant [32 x i8] c"javax/net/ssl/KeyManagerFactory\00", align 16
@__java_type_names.213 = internal constant [25 x i8] c"javax/net/ssl/SSLContext\00", align 16
@__java_type_names.214 = internal constant [31 x i8] c"javax/net/ssl/SSLSocketFactory\00", align 16
@__java_type_names.215 = internal constant [34 x i8] c"javax/net/ssl/TrustManagerFactory\00", align 16
@__java_type_names.216 = internal constant [39 x i8] c"javax/microedition/khronos/opengles/GL\00", align 16
@__java_type_names.217 = internal constant [41 x i8] c"javax/microedition/khronos/opengles/GL10\00", align 16
@__java_type_names.218 = internal constant [41 x i8] c"javax/microedition/khronos/egl/EGLConfig\00", align 16
@__java_type_names.219 = internal constant [29 x i8] c"android/webkit/ValueCallback\00", align 16
@__java_type_names.220 = internal constant [34 x i8] c"android/webkit/WebResourceRequest\00", align 16
@__java_type_names.221 = internal constant [31 x i8] c"android/webkit/WebChromeClient\00", align 16
@__java_type_names.222 = internal constant [49 x i8] c"android/webkit/WebChromeClient$FileChooserParams\00", align 16
@__java_type_names.223 = internal constant [32 x i8] c"android/webkit/WebResourceError\00", align 16
@__java_type_names.224 = internal constant [27 x i8] c"android/webkit/WebSettings\00", align 16
@__java_type_names.225 = internal constant [23 x i8] c"android/webkit/WebView\00", align 16
@__java_type_names.226 = internal constant [29 x i8] c"android/webkit/WebViewClient\00", align 16
@__java_type_names.227 = internal constant [33 x i8] c"android/database/DataSetObserver\00", align 16
@__java_type_names.228 = internal constant [27 x i8] c"android/widget/AbsListView\00", align 16
@__java_type_names.229 = internal constant [27 x i8] c"android/widget/AdapterView\00", align 16
@__java_type_names.230 = internal constant [47 x i8] c"android/widget/AdapterView$OnItemClickListener\00", align 16
@__java_type_names.231 = internal constant [51 x i8] c"android/widget/AdapterView$OnItemLongClickListener\00", align 16
@__java_type_names.232 = internal constant [50 x i8] c"android/widget/AdapterView$OnItemSelectedListener\00", align 16
@__java_type_names.233 = internal constant [27 x i8] c"android/widget/BaseAdapter\00", align 16
@__java_type_names.234 = internal constant [26 x i8] c"android/widget/DatePicker\00", align 16
@__java_type_names.235 = internal constant [48 x i8] c"android/widget/DatePicker$OnDateChangedListener\00", align 16
@__java_type_names.236 = internal constant [24 x i8] c"android/widget/TextView\00", align 16
@__java_type_names.237 = internal constant [47 x i8] c"android/widget/TextView$OnEditorActionListener\00", align 16
@__java_type_names.238 = internal constant [30 x i8] c"android/widget/AbsoluteLayout\00", align 16
@__java_type_names.239 = internal constant [43 x i8] c"android/widget/AbsoluteLayout$LayoutParams\00", align 16
@__java_type_names.240 = internal constant [26 x i8] c"android/widget/AbsSeekBar\00", align 16
@__java_type_names.241 = internal constant [22 x i8] c"android/widget/Button\00", align 16
@__java_type_names.242 = internal constant [30 x i8] c"android/widget/CompoundButton\00", align 16
@__java_type_names.243 = internal constant [54 x i8] c"android/widget/CompoundButton$OnCheckedChangeListener\00", align 16
@__java_type_names.244 = internal constant [24 x i8] c"android/widget/EditText\00", align 16
@__java_type_names.245 = internal constant [22 x i8] c"android/widget/Filter\00", align 16
@__java_type_names.246 = internal constant [37 x i8] c"android/widget/Filter$FilterListener\00", align 16
@__java_type_names.247 = internal constant [27 x i8] c"android/widget/FrameLayout\00", align 16
@__java_type_names.248 = internal constant [24 x i8] c"android/widget/GridView\00", align 16
@__java_type_names.249 = internal constant [36 x i8] c"android/widget/HorizontalScrollView\00", align 16
@__java_type_names.250 = internal constant [23 x i8] c"android/widget/Adapter\00", align 16
@__java_type_names.251 = internal constant [25 x i8] c"android/widget/Checkable\00", align 16
@__java_type_names.252 = internal constant [27 x i8] c"android/widget/ListAdapter\00", align 16
@__java_type_names.253 = internal constant [27 x i8] c"android/widget/ImageButton\00", align 16
@__java_type_names.254 = internal constant [25 x i8] c"android/widget/ImageView\00", align 16
@__java_type_names.255 = internal constant [35 x i8] c"android/widget/ImageView$ScaleType\00", align 16
@__java_type_names.256 = internal constant [30 x i8] c"android/widget/SectionIndexer\00", align 16
@__java_type_names.257 = internal constant [30 x i8] c"android/widget/SpinnerAdapter\00", align 16
@__java_type_names.258 = internal constant [28 x i8] c"android/widget/LinearLayout\00", align 16
@__java_type_names.259 = internal constant [41 x i8] c"android/widget/LinearLayout$LayoutParams\00", align 16
@__java_type_names.260 = internal constant [24 x i8] c"android/widget/ListView\00", align 16
@__java_type_names.261 = internal constant [28 x i8] c"android/widget/NumberPicker\00", align 16
@__java_type_names.262 = internal constant [27 x i8] c"android/widget/ProgressBar\00", align 16
@__java_type_names.263 = internal constant [30 x i8] c"android/widget/RelativeLayout\00", align 16
@__java_type_names.264 = internal constant [43 x i8] c"android/widget/RelativeLayout$LayoutParams\00", align 16
@__java_type_names.265 = internal constant [26 x i8] c"android/widget/ScrollView\00", align 16
@__java_type_names.266 = internal constant [26 x i8] c"android/widget/SearchView\00", align 16
@__java_type_names.267 = internal constant [46 x i8] c"android/widget/SearchView$OnQueryTextListener\00", align 16
@__java_type_names.268 = internal constant [23 x i8] c"android/widget/SeekBar\00", align 16
@__java_type_names.269 = internal constant [47 x i8] c"android/widget/SeekBar$OnSeekBarChangeListener\00", align 16
@__java_type_names.270 = internal constant [22 x i8] c"android/widget/Switch\00", align 16
@__java_type_names.271 = internal constant [26 x i8] c"android/widget/TimePicker\00", align 16
@__java_type_names.272 = internal constant [48 x i8] c"android/widget/TimePicker$OnTimeChangedListener\00", align 16
@__java_type_names.273 = internal constant [21 x i8] c"android/widget/Toast\00", align 16
@__java_type_names.274 = internal constant [18 x i8] c"android/view/View\00", align 16
@__java_type_names.275 = internal constant [30 x i8] c"android/view/View$MeasureSpec\00", align 16
@__java_type_names.276 = internal constant [46 x i8] c"android/view/View$OnAttachStateChangeListener\00", align 16
@__java_type_names.277 = internal constant [34 x i8] c"android/view/View$OnClickListener\00", align 16
@__java_type_names.278 = internal constant [50 x i8] c"mono/android/view/View_OnClickListenerImplementor\00", align 16
@__java_type_names.279 = internal constant [46 x i8] c"android/view/View$OnCreateContextMenuListener\00", align 16
@__java_type_names.280 = internal constant [40 x i8] c"android/view/View$OnFocusChangeListener\00", align 16
@__java_type_names.281 = internal constant [32 x i8] c"android/view/View$OnKeyListener\00", align 16
@__java_type_names.282 = internal constant [48 x i8] c"mono/android/view/View_OnKeyListenerImplementor\00", align 16
@__java_type_names.283 = internal constant [41 x i8] c"android/view/View$OnLayoutChangeListener\00", align 16
@__java_type_names.284 = internal constant [57 x i8] c"mono/android/view/View_OnLayoutChangeListenerImplementor\00", align 16
@__java_type_names.285 = internal constant [34 x i8] c"android/view/View$OnTouchListener\00", align 16
@__java_type_names.286 = internal constant [22 x i8] c"android/view/KeyEvent\00", align 16
@__java_type_names.287 = internal constant [31 x i8] c"android/view/KeyEvent$Callback\00", align 16
@__java_type_names.288 = internal constant [28 x i8] c"android/view/LayoutInflater\00", align 16
@__java_type_names.289 = internal constant [36 x i8] c"android/view/LayoutInflater$Factory\00", align 16
@__java_type_names.290 = internal constant [37 x i8] c"android/view/LayoutInflater$Factory2\00", align 16
@__java_type_names.291 = internal constant [25 x i8] c"android/view/MotionEvent\00", align 16
@__java_type_names.292 = internal constant [30 x i8] c"android/view/ViewTreeObserver\00", align 16
@__java_type_names.293 = internal constant [58 x i8] c"android/view/ViewTreeObserver$OnGlobalFocusChangeListener\00", align 16
@__java_type_names.294 = internal constant [53 x i8] c"android/view/ViewTreeObserver$OnGlobalLayoutListener\00", align 16
@__java_type_names.295 = internal constant [48 x i8] c"android/view/ViewTreeObserver$OnPreDrawListener\00", align 16
@__java_type_names.296 = internal constant [56 x i8] c"android/view/ViewTreeObserver$OnTouchModeChangeListener\00", align 16
@__java_type_names.297 = internal constant [20 x i8] c"android/view/Window\00", align 16
@__java_type_names.298 = internal constant [29 x i8] c"android/view/Window$Callback\00", align 16
@__java_type_names.299 = internal constant [24 x i8] c"android/view/ActionMode\00", align 16
@__java_type_names.300 = internal constant [33 x i8] c"android/view/ActionMode$Callback\00", align 16
@__java_type_names.301 = internal constant [28 x i8] c"android/view/ActionProvider\00", align 16
@__java_type_names.302 = internal constant [33 x i8] c"android/view/ContextThemeWrapper\00", align 16
@__java_type_names.303 = internal constant [21 x i8] c"android/view/Display\00", align 16
@__java_type_names.304 = internal constant [29 x i8] c"android/view/GestureDetector\00", align 16
@__java_type_names.305 = internal constant [49 x i8] c"android/view/GestureDetector$OnDoubleTapListener\00", align 16
@__java_type_names.306 = internal constant [47 x i8] c"android/view/GestureDetector$OnGestureListener\00", align 16
@__java_type_names.307 = internal constant [35 x i8] c"android/view/CollapsibleActionView\00", align 16
@__java_type_names.308 = internal constant [41 x i8] c"android/view/ContextMenu$ContextMenuInfo\00", align 16
@__java_type_names.309 = internal constant [25 x i8] c"android/view/ContextMenu\00", align 16
@__java_type_names.310 = internal constant [18 x i8] c"android/view/Menu\00", align 16
@__java_type_names.311 = internal constant [45 x i8] c"android/view/MenuItem$OnActionExpandListener\00", align 16
@__java_type_names.312 = internal constant [46 x i8] c"android/view/MenuItem$OnMenuItemClickListener\00", align 16
@__java_type_names.313 = internal constant [22 x i8] c"android/view/MenuItem\00", align 16
@__java_type_names.314 = internal constant [24 x i8] c"android/view/InputEvent\00", align 16
@__java_type_names.315 = internal constant [21 x i8] c"android/view/SubMenu\00", align 16
@__java_type_names.316 = internal constant [36 x i8] c"android/view/SurfaceHolder$Callback\00", align 16
@__java_type_names.317 = internal constant [37 x i8] c"android/view/SurfaceHolder$Callback2\00", align 16
@__java_type_names.318 = internal constant [27 x i8] c"android/view/SurfaceHolder\00", align 16
@__java_type_names.319 = internal constant [25 x i8] c"android/view/ViewManager\00", align 16
@__java_type_names.320 = internal constant [24 x i8] c"android/view/ViewParent\00", align 16
@__java_type_names.321 = internal constant [40 x i8] c"android/view/WindowManager$LayoutParams\00", align 16
@__java_type_names.322 = internal constant [27 x i8] c"android/view/WindowManager\00", align 16
@__java_type_names.323 = internal constant [26 x i8] c"android/view/MenuInflater\00", align 16
@__java_type_names.324 = internal constant [34 x i8] c"android/view/ScaleGestureDetector\00", align 16
@__java_type_names.325 = internal constant [57 x i8] c"android/view/ScaleGestureDetector$OnScaleGestureListener\00", align 16
@__java_type_names.326 = internal constant [63 x i8] c"android/view/ScaleGestureDetector$SimpleOnScaleGestureListener\00", align 16
@__java_type_names.327 = internal constant [25 x i8] c"android/view/SearchEvent\00", align 16
@__java_type_names.328 = internal constant [21 x i8] c"android/view/Surface\00", align 16
@__java_type_names.329 = internal constant [25 x i8] c"android/view/SurfaceView\00", align 16
@__java_type_names.330 = internal constant [23 x i8] c"android/view/ViewGroup\00", align 16
@__java_type_names.331 = internal constant [36 x i8] c"android/view/ViewGroup$LayoutParams\00", align 16
@__java_type_names.332 = internal constant [42 x i8] c"android/view/ViewGroup$MarginLayoutParams\00", align 16
@__java_type_names.333 = internal constant [49 x i8] c"android/view/ViewGroup$OnHierarchyChangeListener\00", align 16
@__java_type_names.334 = internal constant [34 x i8] c"android/view/ViewPropertyAnimator\00", align 16
@__java_type_names.335 = internal constant [46 x i8] c"android/view/animation/AccelerateInterpolator\00", align 16
@__java_type_names.336 = internal constant [33 x i8] c"android/view/animation/Animation\00", align 16
@__java_type_names.337 = internal constant [40 x i8] c"android/view/animation/BaseInterpolator\00", align 16
@__java_type_names.338 = internal constant [46 x i8] c"android/view/animation/DecelerateInterpolator\00", align 16
@__java_type_names.339 = internal constant [36 x i8] c"android/view/animation/Interpolator\00", align 16
@__java_type_names.340 = internal constant [44 x i8] c"android/view/inputmethod/InputMethodManager\00", align 16
@__java_type_names.341 = internal constant [46 x i8] c"android/view/accessibility/AccessibilityEvent\00", align 16
@__java_type_names.342 = internal constant [47 x i8] c"android/view/accessibility/AccessibilityRecord\00", align 16
@__java_type_names.343 = internal constant [52 x i8] c"android/view/accessibility/AccessibilityEventSource\00", align 16
@__java_type_names.344 = internal constant [28 x i8] c"android/util/DisplayMetrics\00", align 16
@__java_type_names.345 = internal constant [26 x i8] c"android/util/AttributeSet\00", align 16
@__java_type_names.346 = internal constant [25 x i8] c"android/util/SparseArray\00", align 16
@__java_type_names.347 = internal constant [24 x i8] c"android/util/TypedValue\00", align 16
@__java_type_names.348 = internal constant [22 x i8] c"android/text/Editable\00", align 16
@__java_type_names.349 = internal constant [22 x i8] c"android/text/GetChars\00", align 16
@__java_type_names.350 = internal constant [38 x i8] c"android/text/InputFilter$LengthFilter\00", align 16
@__java_type_names.351 = internal constant [25 x i8] c"android/text/InputFilter\00", align 16
@__java_type_names.352 = internal constant [24 x i8] c"android/text/NoCopySpan\00", align 16
@__java_type_names.353 = internal constant [28 x i8] c"android/text/ParcelableSpan\00", align 16
@__java_type_names.354 = internal constant [23 x i8] c"android/text/Spannable\00", align 16
@__java_type_names.355 = internal constant [21 x i8] c"android/text/Spanned\00", align 16
@__java_type_names.356 = internal constant [25 x i8] c"android/text/TextWatcher\00", align 16
@__java_type_names.357 = internal constant [20 x i8] c"android/text/Layout\00", align 16
@__java_type_names.358 = internal constant [29 x i8] c"android/text/SpannableString\00", align 16
@__java_type_names.359 = internal constant [36 x i8] c"android/text/SpannableStringBuilder\00", align 16
@__java_type_names.360 = internal constant [37 x i8] c"android/text/SpannableStringInternal\00", align 16
@__java_type_names.361 = internal constant [23 x i8] c"android/text/TextPaint\00", align 16
@__java_type_names.362 = internal constant [23 x i8] c"android/text/TextUtils\00", align 16
@__java_type_names.363 = internal constant [34 x i8] c"android/text/TextUtils$TruncateAt\00", align 16
@__java_type_names.364 = internal constant [39 x i8] c"android/text/style/BackgroundColorSpan\00", align 16
@__java_type_names.365 = internal constant [34 x i8] c"android/text/style/CharacterStyle\00", align 16
@__java_type_names.366 = internal constant [39 x i8] c"android/text/style/ForegroundColorSpan\00", align 16
@__java_type_names.367 = internal constant [34 x i8] c"android/text/style/LineHeightSpan\00", align 16
@__java_type_names.368 = internal constant [34 x i8] c"android/text/style/ParagraphStyle\00", align 16
@__java_type_names.369 = internal constant [36 x i8] c"android/text/style/UpdateAppearance\00", align 16
@__java_type_names.370 = internal constant [32 x i8] c"android/text/style/UpdateLayout\00", align 16
@__java_type_names.371 = internal constant [36 x i8] c"android/text/style/WrapTogetherSpan\00", align 16
@__java_type_names.372 = internal constant [39 x i8] c"android/text/style/MetricAffectingSpan\00", align 16
@__java_type_names.373 = internal constant [36 x i8] c"android/text/method/BaseKeyListener\00", align 16
@__java_type_names.374 = internal constant [38 x i8] c"android/text/method/DigitsKeyListener\00", align 16
@__java_type_names.375 = internal constant [32 x i8] c"android/text/method/KeyListener\00", align 16
@__java_type_names.376 = internal constant [39 x i8] c"android/text/method/MetaKeyKeyListener\00", align 16
@__java_type_names.377 = internal constant [38 x i8] c"android/text/method/NumberKeyListener\00", align 16
@__java_type_names.378 = internal constant [31 x i8] c"android/text/format/DateFormat\00", align 16
@__java_type_names.379 = internal constant [29 x i8] c"android/opengl/GLSurfaceView\00", align 16
@__java_type_names.380 = internal constant [38 x i8] c"android/opengl/GLSurfaceView$Renderer\00", align 16
@__java_type_names.381 = internal constant [19 x i8] c"android/os/Handler\00", align 16
@__java_type_names.382 = internal constant [24 x i8] c"android/os/PowerManager\00", align 16
@__java_type_names.383 = internal constant [20 x i8] c"android/os/Vibrator\00", align 16
@__java_type_names.384 = internal constant [22 x i8] c"android/os/BaseBundle\00", align 16
@__java_type_names.385 = internal constant [17 x i8] c"android/os/Build\00", align 16
@__java_type_names.386 = internal constant [25 x i8] c"android/os/Build$VERSION\00", align 16
@__java_type_names.387 = internal constant [18 x i8] c"android/os/Bundle\00", align 16
@__java_type_names.388 = internal constant [23 x i8] c"android/os/Environment\00", align 16
@__java_type_names.389 = internal constant [34 x i8] c"android/os/IBinder$DeathRecipient\00", align 16
@__java_type_names.390 = internal constant [19 x i8] c"android/os/IBinder\00", align 16
@__java_type_names.391 = internal constant [22 x i8] c"android/os/IInterface\00", align 16
@__java_type_names.392 = internal constant [30 x i8] c"android/os/Parcelable$Creator\00", align 16
@__java_type_names.393 = internal constant [22 x i8] c"android/os/Parcelable\00", align 16
@__java_type_names.394 = internal constant [18 x i8] c"android/os/Looper\00", align 16
@__java_type_names.395 = internal constant [18 x i8] c"android/os/Parcel\00", align 16
@__java_type_names.396 = internal constant [19 x i8] c"android/os/Process\00", align 16
@__java_type_names.397 = internal constant [22 x i8] c"android/os/StrictMode\00", align 16
@__java_type_names.398 = internal constant [31 x i8] c"android/os/StrictMode$VmPolicy\00", align 16
@__java_type_names.399 = internal constant [39 x i8] c"android/os/StrictMode$VmPolicy$Builder\00", align 16
@__java_type_names.400 = internal constant [16 x i8] c"android/net/Uri\00", align 16
@__java_type_names.401 = internal constant [26 x i8] c"android/media/MediaPlayer\00", align 16
@__java_type_names.402 = internal constant [31 x i8] c"android/media/VolumeAutomation\00", align 16
@__java_type_names.403 = internal constant [27 x i8] c"android/media/VolumeShaper\00", align 16
@__java_type_names.404 = internal constant [41 x i8] c"android/media/VolumeShaper$Configuration\00", align 16
@__java_type_names.405 = internal constant [24 x i8] c"android/graphics/Bitmap\00", align 16
@__java_type_names.406 = internal constant [31 x i8] c"android/graphics/Bitmap$Config\00", align 16
@__java_type_names.407 = internal constant [24 x i8] c"android/graphics/Canvas\00", align 16
@__java_type_names.408 = internal constant [31 x i8] c"android/graphics/BitmapFactory\00", align 16
@__java_type_names.409 = internal constant [29 x i8] c"android/graphics/ColorFilter\00", align 16
@__java_type_names.410 = internal constant [24 x i8] c"android/graphics/Matrix\00", align 16
@__java_type_names.411 = internal constant [23 x i8] c"android/graphics/Paint\00", align 16
@__java_type_names.412 = internal constant [38 x i8] c"android/graphics/Paint$FontMetricsInt\00", align 16
@__java_type_names.413 = internal constant [29 x i8] c"android/graphics/Paint$Style\00", align 16
@__java_type_names.414 = internal constant [22 x i8] c"android/graphics/Path\00", align 16
@__java_type_names.415 = internal constant [32 x i8] c"android/graphics/Path$Direction\00", align 16
@__java_type_names.416 = internal constant [23 x i8] c"android/graphics/Point\00", align 16
@__java_type_names.417 = internal constant [28 x i8] c"android/graphics/PorterDuff\00", align 16
@__java_type_names.418 = internal constant [33 x i8] c"android/graphics/PorterDuff$Mode\00", align 16
@__java_type_names.419 = internal constant [22 x i8] c"android/graphics/Rect\00", align 16
@__java_type_names.420 = internal constant [23 x i8] c"android/graphics/RectF\00", align 16
@__java_type_names.421 = internal constant [26 x i8] c"android/graphics/Typeface\00", align 16
@__java_type_names.422 = internal constant [35 x i8] c"android/graphics/drawable/Drawable\00", align 16
@__java_type_names.423 = internal constant [44 x i8] c"android/graphics/drawable/Drawable$Callback\00", align 16
@__java_type_names.424 = internal constant [40 x i8] c"android/graphics/drawable/LayerDrawable\00", align 16
@__java_type_names.425 = internal constant [41 x i8] c"android/graphics/drawable/BitmapDrawable\00", align 16
@__java_type_names.426 = internal constant [40 x i8] c"android/graphics/drawable/ColorDrawable\00", align 16
@__java_type_names.427 = internal constant [43 x i8] c"android/graphics/drawable/GradientDrawable\00", align 16
@__java_type_names.428 = internal constant [41 x i8] c"android/graphics/drawable/RippleDrawable\00", align 16
@__java_type_names.429 = internal constant [27 x i8] c"android/animation/Animator\00", align 16
@__java_type_names.430 = internal constant [44 x i8] c"android/animation/Animator$AnimatorListener\00", align 16
@__java_type_names.431 = internal constant [49 x i8] c"android/animation/Animator$AnimatorPauseListener\00", align 16
@__java_type_names.432 = internal constant [47 x i8] c"mono/android/animation/AnimatorEventDispatcher\00", align 16
@__java_type_names.433 = internal constant [32 x i8] c"android/animation/ValueAnimator\00", align 16
@__java_type_names.434 = internal constant [55 x i8] c"android/animation/ValueAnimator$AnimatorUpdateListener\00", align 16
@__java_type_names.435 = internal constant [71 x i8] c"mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor\00", align 16
@__java_type_names.436 = internal constant [42 x i8] c"android/animation/AnimatorListenerAdapter\00", align 16
@__java_type_names.437 = internal constant [35 x i8] c"android/animation/TimeInterpolator\00", align 16
@__java_type_names.438 = internal constant [22 x i8] c"android/app/ActionBar\00", align 16
@__java_type_names.439 = internal constant [26 x i8] c"android/app/ActionBar$Tab\00", align 16
@__java_type_names.440 = internal constant [34 x i8] c"android/app/ActionBar$TabListener\00", align 16
@__java_type_names.441 = internal constant [36 x i8] c"mono/android/app/TabEventDispatcher\00", align 16
@__java_type_names.442 = internal constant [21 x i8] c"android/app/Activity\00", align 16
@__java_type_names.443 = internal constant [24 x i8] c"android/app/AlertDialog\00", align 16
@__java_type_names.444 = internal constant [32 x i8] c"android/app/AlertDialog$Builder\00", align 16
@__java_type_names.445 = internal constant [24 x i8] c"android/app/Application\00", align 16
@__java_type_names.446 = internal constant [29 x i8] c"android/app/DatePickerDialog\00", align 16
@__java_type_names.447 = internal constant [47 x i8] c"android/app/DatePickerDialog$OnDateSetListener\00", align 16
@__java_type_names.448 = internal constant [63 x i8] c"mono/android/app/DatePickerDialog_OnDateSetListenerImplementor\00", align 16
@__java_type_names.449 = internal constant [19 x i8] c"android/app/Dialog\00", align 16
@__java_type_names.450 = internal constant [29 x i8] c"android/app/TimePickerDialog\00", align 16
@__java_type_names.451 = internal constant [47 x i8] c"android/app/TimePickerDialog$OnTimeSetListener\00", align 16
@__java_type_names.452 = internal constant [21 x i8] c"android/app/Fragment\00", align 16
@__java_type_names.453 = internal constant [32 x i8] c"android/app/FragmentTransaction\00", align 16
@__java_type_names.454 = internal constant [26 x i8] c"android/app/PendingIntent\00", align 16
@__java_type_names.455 = internal constant [24 x i8] c"android/content/Context\00", align 16
@__java_type_names.456 = internal constant [23 x i8] c"android/content/Intent\00", align 16
@__java_type_names.457 = internal constant [34 x i8] c"android/content/BroadcastReceiver\00", align 16
@__java_type_names.458 = internal constant [30 x i8] c"android/content/ComponentName\00", align 16
@__java_type_names.459 = internal constant [31 x i8] c"android/content/ContextWrapper\00", align 16
@__java_type_names.460 = internal constant [35 x i8] c"android/content/ComponentCallbacks\00", align 16
@__java_type_names.461 = internal constant [36 x i8] c"android/content/ComponentCallbacks2\00", align 16
@__java_type_names.462 = internal constant [49 x i8] c"android/content/DialogInterface$OnCancelListener\00", align 16
@__java_type_names.463 = internal constant [65 x i8] c"mono/android/content/DialogInterface_OnCancelListenerImplementor\00", align 16
@__java_type_names.464 = internal constant [48 x i8] c"android/content/DialogInterface$OnClickListener\00", align 16
@__java_type_names.465 = internal constant [64 x i8] c"mono/android/content/DialogInterface_OnClickListenerImplementor\00", align 16
@__java_type_names.466 = internal constant [50 x i8] c"android/content/DialogInterface$OnDismissListener\00", align 16
@__java_type_names.467 = internal constant [66 x i8] c"mono/android/content/DialogInterface_OnDismissListenerImplementor\00", align 16
@__java_type_names.468 = internal constant [32 x i8] c"android/content/DialogInterface\00", align 16
@__java_type_names.469 = internal constant [29 x i8] c"android/content/IntentFilter\00", align 16
@__java_type_names.470 = internal constant [29 x i8] c"android/content/IntentSender\00", align 16
@__java_type_names.471 = internal constant [35 x i8] c"android/content/pm/ApplicationInfo\00", align 16
@__java_type_names.472 = internal constant [31 x i8] c"android/content/pm/PackageInfo\00", align 16
@__java_type_names.473 = internal constant [35 x i8] c"android/content/pm/PackageItemInfo\00", align 16
@__java_type_names.474 = internal constant [34 x i8] c"android/content/pm/PackageManager\00", align 16
@__java_type_names.475 = internal constant [38 x i8] c"android/content/res/XmlResourceParser\00", align 16
@__java_type_names.476 = internal constant [33 x i8] c"android/content/res/AssetManager\00", align 16
@__java_type_names.477 = internal constant [35 x i8] c"android/content/res/ColorStateList\00", align 16
@__java_type_names.478 = internal constant [34 x i8] c"android/content/res/Configuration\00", align 16
@__java_type_names.479 = internal constant [30 x i8] c"android/content/res/Resources\00", align 16
@__java_type_names.480 = internal constant [36 x i8] c"android/content/res/Resources$Theme\00", align 16
@__java_type_names.481 = internal constant [31 x i8] c"android/content/res/TypedArray\00", align 16
@__java_type_names.482 = internal constant [40 x i8] c"mono/android/runtime/InputStreamAdapter\00", align 16
@__java_type_names.483 = internal constant [31 x i8] c"mono/android/runtime/JavaArray\00", align 16
@__java_type_names.484 = internal constant [21 x i8] c"java/util/Collection\00", align 16
@__java_type_names.485 = internal constant [18 x i8] c"java/util/HashMap\00", align 16
@__java_type_names.486 = internal constant [20 x i8] c"java/util/ArrayList\00", align 16
@__java_type_names.487 = internal constant [32 x i8] c"mono/android/runtime/JavaObject\00", align 16
@__java_type_names.488 = internal constant [35 x i8] c"android/runtime/JavaProxyThrowable\00", align 16
@__java_type_names.489 = internal constant [18 x i8] c"java/util/HashSet\00", align 16
@__java_type_names.490 = internal constant [41 x i8] c"mono/android/runtime/OutputStreamAdapter\00", align 16
@__java_type_names.491 = internal constant [36 x i8] c"android/runtime/XmlReaderPullParser\00", align 16
@__java_type_names.492 = internal constant [24 x i8] c"java/text/DecimalFormat\00", align 16
@__java_type_names.493 = internal constant [31 x i8] c"java/text/DecimalFormatSymbols\00", align 16
@__java_type_names.494 = internal constant [23 x i8] c"java/text/NumberFormat\00", align 16
@__java_type_names.495 = internal constant [17 x i8] c"java/text/Format\00", align 16
@__java_type_names.496 = internal constant [26 x i8] c"java/net/ConnectException\00", align 16
@__java_type_names.497 = internal constant [27 x i8] c"java/net/HttpURLConnection\00", align 16
@__java_type_names.498 = internal constant [27 x i8] c"java/net/InetSocketAddress\00", align 16
@__java_type_names.499 = internal constant [27 x i8] c"java/net/ProtocolException\00", align 16
@__java_type_names.500 = internal constant [15 x i8] c"java/net/Proxy\00", align 1
@__java_type_names.501 = internal constant [20 x i8] c"java/net/Proxy$Type\00", align 16
@__java_type_names.502 = internal constant [23 x i8] c"java/net/ProxySelector\00", align 16
@__java_type_names.503 = internal constant [23 x i8] c"java/net/SocketAddress\00", align 16
@__java_type_names.504 = internal constant [25 x i8] c"java/net/SocketException\00", align 16
@__java_type_names.505 = internal constant [32 x i8] c"java/net/SocketTimeoutException\00", align 16
@__java_type_names.506 = internal constant [33 x i8] c"java/net/UnknownServiceException\00", align 16
@__java_type_names.507 = internal constant [13 x i8] c"java/net/URI\00", align 1
@__java_type_names.508 = internal constant [13 x i8] c"java/net/URL\00", align 1
@__java_type_names.509 = internal constant [23 x i8] c"java/net/URLConnection\00", align 16
@__java_type_names.510 = internal constant [22 x i8] c"java/util/Enumeration\00", align 16
@__java_type_names.511 = internal constant [19 x i8] c"java/util/Iterator\00", align 16
@__java_type_names.512 = internal constant [17 x i8] c"java/util/Random\00", align 16
@__java_type_names.513 = internal constant [24 x i8] c"java/security/Principal\00", align 16
@__java_type_names.514 = internal constant [23 x i8] c"java/security/KeyStore\00", align 16
@__java_type_names.515 = internal constant [42 x i8] c"java/security/KeyStore$LoadStoreParameter\00", align 16
@__java_type_names.516 = internal constant [43 x i8] c"java/security/KeyStore$ProtectionParameter\00", align 16
@__java_type_names.517 = internal constant [27 x i8] c"java/security/SecureRandom\00", align 16
@__java_type_names.518 = internal constant [31 x i8] c"java/security/cert/Certificate\00", align 16
@__java_type_names.519 = internal constant [38 x i8] c"java/security/cert/CertificateFactory\00", align 16
@__java_type_names.520 = internal constant [33 x i8] c"java/security/cert/X509Extension\00", align 16
@__java_type_names.521 = internal constant [35 x i8] c"java/security/cert/X509Certificate\00", align 16
@__java_type_names.522 = internal constant [16 x i8] c"java/nio/Buffer\00", align 16
@__java_type_names.523 = internal constant [20 x i8] c"java/nio/CharBuffer\00", align 16
@__java_type_names.524 = internal constant [20 x i8] c"java/nio/ByteBuffer\00", align 16
@__java_type_names.525 = internal constant [21 x i8] c"java/nio/FloatBuffer\00", align 16
@__java_type_names.526 = internal constant [19 x i8] c"java/nio/IntBuffer\00", align 16
@__java_type_names.527 = internal constant [30 x i8] c"java/nio/channels/FileChannel\00", align 16
@__java_type_names.528 = internal constant [30 x i8] c"java/nio/channels/ByteChannel\00", align 16
@__java_type_names.529 = internal constant [26 x i8] c"java/nio/channels/Channel\00", align 16
@__java_type_names.530 = internal constant [39 x i8] c"java/nio/channels/GatheringByteChannel\00", align 16
@__java_type_names.531 = internal constant [39 x i8] c"java/nio/channels/InterruptibleChannel\00", align 16
@__java_type_names.532 = internal constant [38 x i8] c"java/nio/channels/ReadableByteChannel\00", align 16
@__java_type_names.533 = internal constant [40 x i8] c"java/nio/channels/ScatteringByteChannel\00", align 16
@__java_type_names.534 = internal constant [38 x i8] c"java/nio/channels/SeekableByteChannel\00", align 16
@__java_type_names.535 = internal constant [38 x i8] c"java/nio/channels/WritableByteChannel\00", align 16
@__java_type_names.536 = internal constant [51 x i8] c"java/nio/channels/spi/AbstractInterruptibleChannel\00", align 16
@__java_type_names.537 = internal constant [18 x i8] c"java/lang/Boolean\00", align 16
@__java_type_names.538 = internal constant [15 x i8] c"java/lang/Byte\00", align 1
@__java_type_names.539 = internal constant [20 x i8] c"java/lang/Character\00", align 16
@__java_type_names.540 = internal constant [16 x i8] c"java/lang/Class\00", align 16
@__java_type_names.541 = internal constant [33 x i8] c"java/lang/ClassNotFoundException\00", align 16
@__java_type_names.542 = internal constant [17 x i8] c"java/lang/Double\00", align 16
@__java_type_names.543 = internal constant [20 x i8] c"java/lang/Exception\00", align 16
@__java_type_names.544 = internal constant [16 x i8] c"java/lang/Float\00", align 16
@__java_type_names.545 = internal constant [23 x i8] c"java/lang/CharSequence\00", align 16
@__java_type_names.546 = internal constant [18 x i8] c"java/lang/Integer\00", align 16
@__java_type_names.547 = internal constant [15 x i8] c"java/lang/Long\00", align 1
@__java_type_names.548 = internal constant [17 x i8] c"java/lang/Object\00", align 16
@__java_type_names.549 = internal constant [27 x i8] c"java/lang/RuntimeException\00", align 16
@__java_type_names.550 = internal constant [16 x i8] c"java/lang/Short\00", align 16
@__java_type_names.551 = internal constant [17 x i8] c"java/lang/String\00", align 16
@__java_type_names.552 = internal constant [17 x i8] c"java/lang/Thread\00", align 16
@__java_type_names.553 = internal constant [35 x i8] c"mono/java/lang/RunnableImplementor\00", align 16
@__java_type_names.554 = internal constant [20 x i8] c"java/lang/Throwable\00", align 16
@__java_type_names.555 = internal constant [29 x i8] c"java/lang/ClassCastException\00", align 16
@__java_type_names.556 = internal constant [22 x i8] c"java/lang/ClassLoader\00", align 16
@__java_type_names.557 = internal constant [15 x i8] c"java/lang/Enum\00", align 1
@__java_type_names.558 = internal constant [16 x i8] c"java/lang/Error\00", align 16
@__java_type_names.559 = internal constant [21 x i8] c"java/lang/Appendable\00", align 16
@__java_type_names.560 = internal constant [24 x i8] c"java/lang/AutoCloseable\00", align 16
@__java_type_names.561 = internal constant [20 x i8] c"java/lang/Cloneable\00", align 16
@__java_type_names.562 = internal constant [21 x i8] c"java/lang/Comparable\00", align 16
@__java_type_names.563 = internal constant [19 x i8] c"java/lang/Iterable\00", align 16
@__java_type_names.564 = internal constant [35 x i8] c"java/lang/IllegalArgumentException\00", align 16
@__java_type_names.565 = internal constant [32 x i8] c"java/lang/IllegalStateException\00", align 16
@__java_type_names.566 = internal constant [36 x i8] c"java/lang/IndexOutOfBoundsException\00", align 16
@__java_type_names.567 = internal constant [19 x i8] c"java/lang/Readable\00", align 16
@__java_type_names.568 = internal constant [19 x i8] c"java/lang/Runnable\00", align 16
@__java_type_names.569 = internal constant [23 x i8] c"java/lang/LinkageError\00", align 16
@__java_type_names.570 = internal constant [31 x i8] c"java/lang/NoClassDefFoundError\00", align 16
@__java_type_names.571 = internal constant [31 x i8] c"java/lang/NullPointerException\00", align 16
@__java_type_names.572 = internal constant [17 x i8] c"java/lang/Number\00", align 16
@__java_type_names.573 = internal constant [39 x i8] c"java/lang/ReflectiveOperationException\00", align 16
@__java_type_names.574 = internal constant [28 x i8] c"java/lang/SecurityException\00", align 16
@__java_type_names.575 = internal constant [40 x i8] c"java/lang/UnsupportedOperationException\00", align 16
@__java_type_names.576 = internal constant [32 x i8] c"java/lang/annotation/Annotation\00", align 16
@__java_type_names.577 = internal constant [35 x i8] c"java/lang/reflect/AnnotatedElement\00", align 16
@__java_type_names.578 = internal constant [37 x i8] c"java/lang/reflect/GenericDeclaration\00", align 16
@__java_type_names.579 = internal constant [23 x i8] c"java/lang/reflect/Type\00", align 16
@__java_type_names.580 = internal constant [31 x i8] c"java/lang/reflect/TypeVariable\00", align 16
@__java_type_names.581 = internal constant [13 x i8] c"java/io/File\00", align 1
@__java_type_names.582 = internal constant [23 x i8] c"java/io/FileDescriptor\00", align 16
@__java_type_names.583 = internal constant [24 x i8] c"java/io/FileInputStream\00", align 16
@__java_type_names.584 = internal constant [18 x i8] c"java/io/Closeable\00", align 16
@__java_type_names.585 = internal constant [18 x i8] c"java/io/Flushable\00", align 16
@__java_type_names.586 = internal constant [20 x i8] c"java/io/InputStream\00", align 16
@__java_type_names.587 = internal constant [31 x i8] c"java/io/InterruptedIOException\00", align 16
@__java_type_names.588 = internal constant [20 x i8] c"java/io/IOException\00", align 16
@__java_type_names.589 = internal constant [21 x i8] c"java/io/Serializable\00", align 16
@__java_type_names.590 = internal constant [21 x i8] c"java/io/OutputStream\00", align 16
@__java_type_names.591 = internal constant [20 x i8] c"java/io/PrintWriter\00", align 16
@__java_type_names.592 = internal constant [15 x i8] c"java/io/Reader\00", align 1
@__java_type_names.593 = internal constant [21 x i8] c"java/io/StringWriter\00", align 16
@__java_type_names.594 = internal constant [15 x i8] c"java/io/Writer\00", align 1
@__java_type_names.595 = internal constant [25 x i8] c"mono/android/TypeManager\00", align 16
@__java_type_names.596 = internal constant [40 x i8] c"android/support/v4/app/FragmentActivity\00", align 16
@__java_type_names.597 = internal constant [32 x i8] c"android/support/v4/app/Fragment\00", align 16
@__java_type_names.598 = internal constant [43 x i8] c"android/support/v4/app/Fragment$SavedState\00", align 16
@__java_type_names.599 = internal constant [39 x i8] c"android/support/v4/app/FragmentManager\00", align 16
@__java_type_names.600 = internal constant [54 x i8] c"android/support/v4/app/FragmentManager$BackStackEntry\00", align 16
@__java_type_names.601 = internal constant [66 x i8] c"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks\00", align 16
@__java_type_names.602 = internal constant [66 x i8] c"android/support/v4/app/FragmentManager$OnBackStackChangedListener\00", align 16
@__java_type_names.603 = internal constant [82 x i8] c"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor\00", align 16
@__java_type_names.604 = internal constant [44 x i8] c"android/support/v4/app/FragmentPagerAdapter\00", align 16
@__java_type_names.605 = internal constant [43 x i8] c"android/support/v4/app/FragmentTransaction\00", align 16
@__java_type_names.606 = internal constant [37 x i8] c"android/support/v4/app/LoaderManager\00", align 16
@__java_type_names.607 = internal constant [53 x i8] c"android/support/v4/app/LoaderManager$LoaderCallbacks\00", align 16
@__java_type_names.608 = internal constant [40 x i8] c"android/support/design/widget/TabLayout\00", align 16
@__java_type_names.609 = internal constant [62 x i8] c"android/support/design/widget/TabLayout$OnTabSelectedListener\00", align 16
@__java_type_names.610 = internal constant [78 x i8] c"mono/android/support/design/widget/TabLayout_OnTabSelectedListenerImplementor\00", align 16
@__java_type_names.611 = internal constant [44 x i8] c"android/support/design/widget/TabLayout$Tab\00", align 16
@__java_type_names.612 = internal constant [51 x i8] c"android/support/design/widget/BottomNavigationView\00", align 16
@__java_type_names.613 = internal constant [86 x i8] c"android/support/design/widget/BottomNavigationView$OnNavigationItemReselectedListener\00", align 16
@__java_type_names.614 = internal constant [102 x i8] c"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemReselectedListenerImplementor\00", align 16
@__java_type_names.615 = internal constant [84 x i8] c"android/support/design/widget/BottomNavigationView$OnNavigationItemSelectedListener\00", align 16
@__java_type_names.616 = internal constant [100 x i8] c"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemSelectedListenerImplementor\00", align 16
@__java_type_names.617 = internal constant [34 x i8] c"android/support/v4/content/Loader\00", align 16
@__java_type_names.618 = internal constant [57 x i8] c"android/support/v4/content/Loader$OnLoadCanceledListener\00", align 16
@__java_type_names.619 = internal constant [57 x i8] c"android/support/v4/content/Loader$OnLoadCompleteListener\00", align 16
@__java_type_names.620 = internal constant [40 x i8] c"android/support/v4/app/TaskStackBuilder\00", align 16
@__java_type_names.621 = internal constant [58 x i8] c"android/support/v4/app/TaskStackBuilder$SupportParentable\00", align 16
@__java_type_names.622 = internal constant [50 x i8] c"com/xamarin/forms/platform/android/FormsViewGroup\00", align 16
@__java_type_names.623 = internal constant [39 x i8] c"com/xamarin/formsviewgroup/BuildConfig\00", align 16

@java_type_names = local_unnamed_addr constant [624 x i8*] [
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.0, i32 0, i32 0),
	i8* getelementptr inbounds ([61 x i8], [61 x i8]* @__java_type_names.1, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.2, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.3, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.4, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.5, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.6, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.7, i32 0, i32 0),
	i8* getelementptr inbounds ([62 x i8], [62 x i8]* @__java_type_names.8, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.9, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.10, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.11, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.12, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.13, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.14, i32 0, i32 0),
	i8* getelementptr inbounds ([82 x i8], [82 x i8]* @__java_type_names.15, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.16, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.17, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.18, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.19, i32 0, i32 0),
	i8* getelementptr inbounds ([53 x i8], [53 x i8]* @__java_type_names.20, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.21, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.22, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.23, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.24, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.25, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.26, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.27, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.28, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.29, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.30, i32 0, i32 0),
	i8* getelementptr inbounds ([67 x i8], [67 x i8]* @__java_type_names.31, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.32, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.33, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.34, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.35, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.36, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.37, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.38, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.39, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.40, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.41, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.42, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.43, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.44, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.45, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.46, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.47, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.48, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.49, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.50, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.51, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.52, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.53, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.54, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.55, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.56, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.57, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.58, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.59, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.60, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.61, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.62, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.63, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.64, i32 0, i32 0),
	i8* getelementptr inbounds ([61 x i8], [61 x i8]* @__java_type_names.65, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.66, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.67, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.68, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.69, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.70, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.71, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.72, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.73, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.74, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.75, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.76, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.77, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.78, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.79, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.80, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.81, i32 0, i32 0),
	i8* getelementptr inbounds ([60 x i8], [60 x i8]* @__java_type_names.82, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.83, i32 0, i32 0),
	i8* getelementptr inbounds ([55 x i8], [55 x i8]* @__java_type_names.84, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.85, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.86, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.87, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.88, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.89, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.90, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.91, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.92, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.93, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.94, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.95, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.96, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.97, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.98, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.99, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.100, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.101, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.102, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.103, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.104, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.105, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.106, i32 0, i32 0),
	i8* getelementptr inbounds ([59 x i8], [59 x i8]* @__java_type_names.107, i32 0, i32 0),
	i8* getelementptr inbounds ([55 x i8], [55 x i8]* @__java_type_names.108, i32 0, i32 0),
	i8* getelementptr inbounds ([71 x i8], [71 x i8]* @__java_type_names.109, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.110, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.111, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.112, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.113, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.114, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.115, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.116, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.117, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.118, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.119, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.120, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.121, i32 0, i32 0),
	i8* getelementptr inbounds ([79 x i8], [79 x i8]* @__java_type_names.122, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.123, i32 0, i32 0),
	i8* getelementptr inbounds ([74 x i8], [74 x i8]* @__java_type_names.124, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.125, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.126, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.127, i32 0, i32 0),
	i8* getelementptr inbounds ([53 x i8], [53 x i8]* @__java_type_names.128, i32 0, i32 0),
	i8* getelementptr inbounds ([59 x i8], [59 x i8]* @__java_type_names.129, i32 0, i32 0),
	i8* getelementptr inbounds ([51 x i8], [51 x i8]* @__java_type_names.130, i32 0, i32 0),
	i8* getelementptr inbounds ([51 x i8], [51 x i8]* @__java_type_names.131, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.132, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.133, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.134, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.135, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.136, i32 0, i32 0),
	i8* getelementptr inbounds ([73 x i8], [73 x i8]* @__java_type_names.137, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.138, i32 0, i32 0),
	i8* getelementptr inbounds ([77 x i8], [77 x i8]* @__java_type_names.139, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.140, i32 0, i32 0),
	i8* getelementptr inbounds ([75 x i8], [75 x i8]* @__java_type_names.141, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.142, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.143, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.144, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.145, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.146, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.147, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.148, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.149, i32 0, i32 0),
	i8* getelementptr inbounds ([74 x i8], [74 x i8]* @__java_type_names.150, i32 0, i32 0),
	i8* getelementptr inbounds ([55 x i8], [55 x i8]* @__java_type_names.151, i32 0, i32 0),
	i8* getelementptr inbounds ([71 x i8], [71 x i8]* @__java_type_names.152, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.153, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.154, i32 0, i32 0),
	i8* getelementptr inbounds ([69 x i8], [69 x i8]* @__java_type_names.155, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.156, i32 0, i32 0),
	i8* getelementptr inbounds ([79 x i8], [79 x i8]* @__java_type_names.157, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.158, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.159, i32 0, i32 0),
	i8* getelementptr inbounds ([70 x i8], [70 x i8]* @__java_type_names.160, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.161, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.162, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.163, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.164, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.165, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.166, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.167, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.168, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.169, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.170, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.171, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.172, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.173, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.174, i32 0, i32 0),
	i8* getelementptr inbounds ([67 x i8], [67 x i8]* @__java_type_names.175, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.176, i32 0, i32 0),
	i8* getelementptr inbounds ([74 x i8], [74 x i8]* @__java_type_names.177, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.178, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.179, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.180, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.181, i32 0, i32 0),
	i8* getelementptr inbounds ([75 x i8], [75 x i8]* @__java_type_names.182, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.183, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.184, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.185, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.186, i32 0, i32 0),
	i8* getelementptr inbounds ([74 x i8], [74 x i8]* @__java_type_names.187, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.188, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.189, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.190, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.191, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.192, i32 0, i32 0),
	i8* getelementptr inbounds ([62 x i8], [62 x i8]* @__java_type_names.193, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.194, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.195, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.196, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.197, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.198, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.199, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.200, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.201, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.202, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.203, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.204, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.205, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.206, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.207, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.208, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.209, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.210, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.211, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.212, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.213, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.214, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.215, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.216, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.217, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.218, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.219, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.220, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.221, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.222, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.223, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.224, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.225, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.226, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.227, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.228, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.229, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.230, i32 0, i32 0),
	i8* getelementptr inbounds ([51 x i8], [51 x i8]* @__java_type_names.231, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.232, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.233, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.234, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.235, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.236, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.237, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.238, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.239, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.240, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.241, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.242, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.243, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.244, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.245, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.246, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.247, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.248, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.249, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.250, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.251, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.252, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.253, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.254, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.255, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.256, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.257, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.258, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.259, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.260, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.261, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.262, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.263, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.264, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.265, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.266, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.267, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.268, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.269, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.270, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.271, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.272, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.273, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.274, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.275, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.276, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.277, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.278, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.279, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.280, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.281, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.282, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.283, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.284, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.285, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.286, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.287, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.288, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.289, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.290, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.291, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.292, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.293, i32 0, i32 0),
	i8* getelementptr inbounds ([53 x i8], [53 x i8]* @__java_type_names.294, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.295, i32 0, i32 0),
	i8* getelementptr inbounds ([56 x i8], [56 x i8]* @__java_type_names.296, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.297, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.298, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.299, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.300, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.301, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.302, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.303, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.304, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.305, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.306, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.307, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.308, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.309, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.310, i32 0, i32 0),
	i8* getelementptr inbounds ([45 x i8], [45 x i8]* @__java_type_names.311, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.312, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.313, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.314, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.315, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.316, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.317, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.318, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.319, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.320, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.321, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.322, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.323, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.324, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.325, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.326, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.327, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.328, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.329, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.330, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.331, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.332, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.333, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.334, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.335, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.336, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.337, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.338, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.339, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.340, i32 0, i32 0),
	i8* getelementptr inbounds ([46 x i8], [46 x i8]* @__java_type_names.341, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.342, i32 0, i32 0),
	i8* getelementptr inbounds ([52 x i8], [52 x i8]* @__java_type_names.343, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.344, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.345, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.346, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.347, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.348, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.349, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.350, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.351, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.352, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.353, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.354, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.355, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.356, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.357, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.358, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.359, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.360, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.361, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.362, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.363, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.364, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.365, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.366, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.367, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.368, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.369, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.370, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.371, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.372, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.373, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.374, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.375, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.376, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.377, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.378, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.379, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.380, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.381, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.382, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.383, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.384, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.385, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.386, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.387, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.388, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.389, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.390, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.391, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.392, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.393, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.394, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.395, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.396, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.397, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.398, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.399, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.400, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.401, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.402, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.403, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.404, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.405, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.406, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.407, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.408, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.409, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.410, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.411, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.412, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.413, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.414, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.415, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.416, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.417, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.418, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.419, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.420, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.421, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.422, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.423, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.424, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.425, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.426, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.427, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.428, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.429, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.430, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.431, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.432, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.433, i32 0, i32 0),
	i8* getelementptr inbounds ([55 x i8], [55 x i8]* @__java_type_names.434, i32 0, i32 0),
	i8* getelementptr inbounds ([71 x i8], [71 x i8]* @__java_type_names.435, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.436, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.437, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.438, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.439, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.440, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.441, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.442, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.443, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.444, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.445, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.446, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.447, i32 0, i32 0),
	i8* getelementptr inbounds ([63 x i8], [63 x i8]* @__java_type_names.448, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.449, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.450, i32 0, i32 0),
	i8* getelementptr inbounds ([47 x i8], [47 x i8]* @__java_type_names.451, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.452, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.453, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.454, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.455, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.456, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.457, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.458, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.459, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.460, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.461, i32 0, i32 0),
	i8* getelementptr inbounds ([49 x i8], [49 x i8]* @__java_type_names.462, i32 0, i32 0),
	i8* getelementptr inbounds ([65 x i8], [65 x i8]* @__java_type_names.463, i32 0, i32 0),
	i8* getelementptr inbounds ([48 x i8], [48 x i8]* @__java_type_names.464, i32 0, i32 0),
	i8* getelementptr inbounds ([64 x i8], [64 x i8]* @__java_type_names.465, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.466, i32 0, i32 0),
	i8* getelementptr inbounds ([66 x i8], [66 x i8]* @__java_type_names.467, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.468, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.469, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.470, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.471, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.472, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.473, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.474, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.475, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.476, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.477, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.478, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.479, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.480, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.481, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.482, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.483, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.484, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.485, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.486, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.487, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.488, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.489, i32 0, i32 0),
	i8* getelementptr inbounds ([41 x i8], [41 x i8]* @__java_type_names.490, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.491, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.492, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.493, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.494, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.495, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.496, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.497, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.498, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.499, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.500, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.501, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.502, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.503, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.504, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.505, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.506, i32 0, i32 0),
	i8* getelementptr inbounds ([13 x i8], [13 x i8]* @__java_type_names.507, i32 0, i32 0),
	i8* getelementptr inbounds ([13 x i8], [13 x i8]* @__java_type_names.508, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.509, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.510, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.511, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.512, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.513, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.514, i32 0, i32 0),
	i8* getelementptr inbounds ([42 x i8], [42 x i8]* @__java_type_names.515, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.516, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.517, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.518, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.519, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.520, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.521, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.522, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.523, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.524, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.525, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.526, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.527, i32 0, i32 0),
	i8* getelementptr inbounds ([30 x i8], [30 x i8]* @__java_type_names.528, i32 0, i32 0),
	i8* getelementptr inbounds ([26 x i8], [26 x i8]* @__java_type_names.529, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.530, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.531, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.532, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.533, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.534, i32 0, i32 0),
	i8* getelementptr inbounds ([38 x i8], [38 x i8]* @__java_type_names.535, i32 0, i32 0),
	i8* getelementptr inbounds ([51 x i8], [51 x i8]* @__java_type_names.536, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.537, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.538, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.539, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.540, i32 0, i32 0),
	i8* getelementptr inbounds ([33 x i8], [33 x i8]* @__java_type_names.541, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.542, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.543, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.544, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.545, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.546, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.547, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.548, i32 0, i32 0),
	i8* getelementptr inbounds ([27 x i8], [27 x i8]* @__java_type_names.549, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.550, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.551, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.552, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.553, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.554, i32 0, i32 0),
	i8* getelementptr inbounds ([29 x i8], [29 x i8]* @__java_type_names.555, i32 0, i32 0),
	i8* getelementptr inbounds ([22 x i8], [22 x i8]* @__java_type_names.556, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.557, i32 0, i32 0),
	i8* getelementptr inbounds ([16 x i8], [16 x i8]* @__java_type_names.558, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.559, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.560, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.561, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.562, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.563, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.564, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.565, i32 0, i32 0),
	i8* getelementptr inbounds ([36 x i8], [36 x i8]* @__java_type_names.566, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.567, i32 0, i32 0),
	i8* getelementptr inbounds ([19 x i8], [19 x i8]* @__java_type_names.568, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.569, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.570, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.571, i32 0, i32 0),
	i8* getelementptr inbounds ([17 x i8], [17 x i8]* @__java_type_names.572, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.573, i32 0, i32 0),
	i8* getelementptr inbounds ([28 x i8], [28 x i8]* @__java_type_names.574, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.575, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.576, i32 0, i32 0),
	i8* getelementptr inbounds ([35 x i8], [35 x i8]* @__java_type_names.577, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.578, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.579, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.580, i32 0, i32 0),
	i8* getelementptr inbounds ([13 x i8], [13 x i8]* @__java_type_names.581, i32 0, i32 0),
	i8* getelementptr inbounds ([23 x i8], [23 x i8]* @__java_type_names.582, i32 0, i32 0),
	i8* getelementptr inbounds ([24 x i8], [24 x i8]* @__java_type_names.583, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.584, i32 0, i32 0),
	i8* getelementptr inbounds ([18 x i8], [18 x i8]* @__java_type_names.585, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.586, i32 0, i32 0),
	i8* getelementptr inbounds ([31 x i8], [31 x i8]* @__java_type_names.587, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.588, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.589, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.590, i32 0, i32 0),
	i8* getelementptr inbounds ([20 x i8], [20 x i8]* @__java_type_names.591, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.592, i32 0, i32 0),
	i8* getelementptr inbounds ([21 x i8], [21 x i8]* @__java_type_names.593, i32 0, i32 0),
	i8* getelementptr inbounds ([15 x i8], [15 x i8]* @__java_type_names.594, i32 0, i32 0),
	i8* getelementptr inbounds ([25 x i8], [25 x i8]* @__java_type_names.595, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.596, i32 0, i32 0),
	i8* getelementptr inbounds ([32 x i8], [32 x i8]* @__java_type_names.597, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.598, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.599, i32 0, i32 0),
	i8* getelementptr inbounds ([54 x i8], [54 x i8]* @__java_type_names.600, i32 0, i32 0),
	i8* getelementptr inbounds ([66 x i8], [66 x i8]* @__java_type_names.601, i32 0, i32 0),
	i8* getelementptr inbounds ([66 x i8], [66 x i8]* @__java_type_names.602, i32 0, i32 0),
	i8* getelementptr inbounds ([82 x i8], [82 x i8]* @__java_type_names.603, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.604, i32 0, i32 0),
	i8* getelementptr inbounds ([43 x i8], [43 x i8]* @__java_type_names.605, i32 0, i32 0),
	i8* getelementptr inbounds ([37 x i8], [37 x i8]* @__java_type_names.606, i32 0, i32 0),
	i8* getelementptr inbounds ([53 x i8], [53 x i8]* @__java_type_names.607, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.608, i32 0, i32 0),
	i8* getelementptr inbounds ([62 x i8], [62 x i8]* @__java_type_names.609, i32 0, i32 0),
	i8* getelementptr inbounds ([78 x i8], [78 x i8]* @__java_type_names.610, i32 0, i32 0),
	i8* getelementptr inbounds ([44 x i8], [44 x i8]* @__java_type_names.611, i32 0, i32 0),
	i8* getelementptr inbounds ([51 x i8], [51 x i8]* @__java_type_names.612, i32 0, i32 0),
	i8* getelementptr inbounds ([86 x i8], [86 x i8]* @__java_type_names.613, i32 0, i32 0),
	i8* getelementptr inbounds ([102 x i8], [102 x i8]* @__java_type_names.614, i32 0, i32 0),
	i8* getelementptr inbounds ([84 x i8], [84 x i8]* @__java_type_names.615, i32 0, i32 0),
	i8* getelementptr inbounds ([100 x i8], [100 x i8]* @__java_type_names.616, i32 0, i32 0),
	i8* getelementptr inbounds ([34 x i8], [34 x i8]* @__java_type_names.617, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.618, i32 0, i32 0),
	i8* getelementptr inbounds ([57 x i8], [57 x i8]* @__java_type_names.619, i32 0, i32 0),
	i8* getelementptr inbounds ([40 x i8], [40 x i8]* @__java_type_names.620, i32 0, i32 0),
	i8* getelementptr inbounds ([58 x i8], [58 x i8]* @__java_type_names.621, i32 0, i32 0),
	i8* getelementptr inbounds ([50 x i8], [50 x i8]* @__java_type_names.622, i32 0, i32 0),
	i8* getelementptr inbounds ([39 x i8], [39 x i8]* @__java_type_names.623, i32 0, i32 0)
], align 16

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
