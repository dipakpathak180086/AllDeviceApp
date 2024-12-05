; ModuleID = 'obj\Release\81\android\typemaps.armeabi-v7a.ll'
source_filename = "obj\Release\81\android\typemaps.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
		i32 388; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554453, ; type_token_id
		i32 535; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 197; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 278; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 241; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554461, ; type_token_id
		i32 208; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 540; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 435; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 16; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554479, ; type_token_id
		i32 401; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 198; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554482, ; type_token_id
		i32 296; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554486, ; type_token_id
		i32 178; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554495, ; type_token_id
		i32 488; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554496, ; type_token_id
		i32 115; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554498, ; type_token_id
		i32 403; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554499, ; type_token_id
		i32 412; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554500, ; type_token_id
		i32 257; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554502, ; type_token_id
		i32 457; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554504, ; type_token_id
		i32 399; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554505, ; type_token_id
		i32 600; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554508, ; type_token_id
		i32 364; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554509, ; type_token_id
		i32 110; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554510, ; type_token_id
		i32 103; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554511, ; type_token_id
		i32 496; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554518, ; type_token_id
		i32 569; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554519, ; type_token_id
		i32 169; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554521, ; type_token_id
		i32 113; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554522, ; type_token_id
		i32 13; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554524, ; type_token_id
		i32 60; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554525, ; type_token_id
		i32 302; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554533, ; type_token_id
		i32 71; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554536, ; type_token_id
		i32 114; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554537, ; type_token_id
		i32 324; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554539, ; type_token_id
		i32 452; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554541, ; type_token_id
		i32 229; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554542, ; type_token_id
		i32 91; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554543, ; type_token_id
		i32 511; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554544, ; type_token_id
		i32 483; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554545, ; type_token_id
		i32 543; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554546, ; type_token_id
		i32 334; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554547, ; type_token_id
		i32 396; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554549, ; type_token_id
		i32 338; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554551, ; type_token_id
		i32 157; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554552, ; type_token_id
		i32 58; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554553, ; type_token_id
		i32 498; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554554, ; type_token_id
		i32 234; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554555, ; type_token_id
		i32 89; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554556, ; type_token_id
		i32 505; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554557, ; type_token_id
		i32 544; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554558, ; type_token_id
		i32 497; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554559, ; type_token_id
		i32 329; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554560, ; type_token_id
		i32 240; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554561, ; type_token_id
		i32 19; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554562, ; type_token_id
		i32 35; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554563, ; type_token_id
		i32 84; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554564, ; type_token_id
		i32 565; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554565, ; type_token_id
		i32 368; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554566, ; type_token_id
		i32 101; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554567, ; type_token_id
		i32 174; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554568, ; type_token_id
		i32 77; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554569, ; type_token_id
		i32 78; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554570, ; type_token_id
		i32 262; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554571, ; type_token_id
		i32 318; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554576, ; type_token_id
		i32 289; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554579, ; type_token_id
		i32 52; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554583, ; type_token_id
		i32 227; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554585, ; type_token_id
		i32 352; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554589, ; type_token_id
		i32 50; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554595, ; type_token_id
		i32 18; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554597, ; type_token_id
		i32 56; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554599, ; type_token_id
		i32 502; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554601, ; type_token_id
		i32 612; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554602, ; type_token_id
		i32 495; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554603, ; type_token_id
		i32 617; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554604, ; type_token_id
		i32 492; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554606, ; type_token_id
		i32 94; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554608, ; type_token_id
		i32 441; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554609, ; type_token_id
		i32 542; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554610, ; type_token_id
		i32 258; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554611, ; type_token_id
		i32 132; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554612, ; type_token_id
		i32 454; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554613, ; type_token_id
		i32 63; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554614, ; type_token_id
		i32 343; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554615, ; type_token_id
		i32 75; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554616, ; type_token_id
		i32 341; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554622, ; type_token_id
		i32 345; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554624, ; type_token_id
		i32 395; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554630, ; type_token_id
		i32 141; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554634, ; type_token_id
		i32 3; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554636, ; type_token_id
		i32 391; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554637, ; type_token_id
		i32 515; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554645, ; type_token_id
		i32 6; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554646, ; type_token_id
		i32 603; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554649, ; type_token_id
		i32 358; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554650, ; type_token_id
		i32 195; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554651, ; type_token_id
		i32 118; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554658, ; type_token_id
		i32 613; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554666, ; type_token_id
		i32 312; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554668, ; type_token_id
		i32 537; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554674, ; type_token_id
		i32 42; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554676, ; type_token_id
		i32 480; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554677, ; type_token_id
		i32 333; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554683, ; type_token_id
		i32 512; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554684, ; type_token_id
		i32 117; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554685, ; type_token_id
		i32 87; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554689, ; type_token_id
		i32 406; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554690, ; type_token_id
		i32 123; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554692, ; type_token_id
		i32 547; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554701, ; type_token_id
		i32 210; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554707, ; type_token_id
		i32 73; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554708, ; type_token_id
		i32 346; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554710, ; type_token_id
		i32 88; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554711, ; type_token_id
		i32 47; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554712, ; type_token_id
		i32 294; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554718, ; type_token_id
		i32 374; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554729, ; type_token_id
		i32 283; java_map_index
	}
], align 4; end of 'module0_managed_to_java' array


; module1_managed_to_java
@module1_managed_to_java = internal constant [25 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 599; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 432; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 340; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 425; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 226; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 337; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554445, ; type_token_id
		i32 533; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 264; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 478; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 390; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 319; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 427; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554462, ; type_token_id
		i32 506; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 151; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 304; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 209; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 389; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554469, ; type_token_id
		i32 51; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554470, ; type_token_id
		i32 109; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554471, ; type_token_id
		i32 622; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554473, ; type_token_id
		i32 238; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554475, ; type_token_id
		i32 365; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554477, ; type_token_id
		i32 255; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554478, ; type_token_id
		i32 578; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554480, ; type_token_id
		i32 573; java_map_index
	}
], align 4; end of 'module1_managed_to_java' array


; module1_managed_to_java_duplicates
@module1_managed_to_java_duplicates = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 425; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 578; java_map_index
	}
], align 4; end of 'module1_managed_to_java_duplicates' array


; module2_managed_to_java
@module2_managed_to_java = internal constant [4 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 623; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 458; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 85; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 428; java_map_index
	}
], align 4; end of 'module2_managed_to_java' array


; module2_managed_to_java_duplicates
@module2_managed_to_java_duplicates = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 623; java_map_index
	}
], align 4; end of 'module2_managed_to_java_duplicates' array


; module3_managed_to_java
@module3_managed_to_java = internal constant [16 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 184; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 433; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 336; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 353; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 280; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 133; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 220; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 510; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554458, ; type_token_id
		i32 407; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 532; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554462, ; type_token_id
		i32 414; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 581; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 615; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 189; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554473, ; type_token_id
		i32 472; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554474, ; type_token_id
		i32 555; java_map_index
	}
], align 4; end of 'module3_managed_to_java' array


; module3_managed_to_java_duplicates
@module3_managed_to_java_duplicates = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 433; java_map_index
	}
], align 4; end of 'module3_managed_to_java_duplicates' array


; module4_managed_to_java
@module4_managed_to_java = internal constant [1 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 287; java_map_index
	}
], align 4; end of 'module4_managed_to_java' array


; module5_managed_to_java
@module5_managed_to_java = internal constant [34 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 356; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 459; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 303; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 445; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 55; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 181; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554445, ; type_token_id
		i32 491; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554446, ; type_token_id
		i32 49; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 385; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 423; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 119; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554451, ; type_token_id
		i32 131; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 582; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554455, ; type_token_id
		i32 618; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554457, ; type_token_id
		i32 224; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554460, ; type_token_id
		i32 242; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554461, ; type_token_id
		i32 436; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554463, ; type_token_id
		i32 156; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554464, ; type_token_id
		i32 59; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554465, ; type_token_id
		i32 26; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554466, ; type_token_id
		i32 29; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554467, ; type_token_id
		i32 574; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554468, ; type_token_id
		i32 461; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554470, ; type_token_id
		i32 7; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554472, ; type_token_id
		i32 462; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554474, ; type_token_id
		i32 217; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554475, ; type_token_id
		i32 21; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554478, ; type_token_id
		i32 604; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554482, ; type_token_id
		i32 36; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554484, ; type_token_id
		i32 549; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554486, ; type_token_id
		i32 236; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554487, ; type_token_id
		i32 430; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554488, ; type_token_id
		i32 145; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554491, ; type_token_id
		i32 125; java_map_index
	}
], align 4; end of 'module5_managed_to_java' array


; module5_managed_to_java_duplicates
@module5_managed_to_java_duplicates = internal constant [4 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 303; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554476, ; type_token_id
		i32 21; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554481, ; type_token_id
		i32 574; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554489, ; type_token_id
		i32 145; java_map_index
	}
], align 4; end of 'module5_managed_to_java_duplicates' array


; module6_managed_to_java
@module6_managed_to_java = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 108; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 520; java_map_index
	}
], align 4; end of 'module6_managed_to_java' array


; module7_managed_to_java
@module7_managed_to_java = internal constant [397 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554597, ; type_token_id
		i32 494; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554598, ; type_token_id
		i32 344; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554600, ; type_token_id
		i32 371; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554602, ; type_token_id
		i32 187; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554604, ; type_token_id
		i32 43; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554606, ; type_token_id
		i32 528; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554608, ; type_token_id
		i32 490; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554610, ; type_token_id
		i32 400; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554612, ; type_token_id
		i32 205; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554614, ; type_token_id
		i32 479; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554616, ; type_token_id
		i32 22; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554618, ; type_token_id
		i32 136; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554620, ; type_token_id
		i32 548; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554622, ; type_token_id
		i32 168; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554623, ; type_token_id
		i32 199; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554624, ; type_token_id
		i32 572; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554626, ; type_token_id
		i32 601; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554627, ; type_token_id
		i32 32; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554629, ; type_token_id
		i32 177; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554631, ; type_token_id
		i32 286; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554643, ; type_token_id
		i32 561; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554645, ; type_token_id
		i32 410; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554648, ; type_token_id
		i32 534; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554649, ; type_token_id
		i32 317; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554651, ; type_token_id
		i32 460; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554653, ; type_token_id
		i32 375; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554655, ; type_token_id
		i32 554; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554656, ; type_token_id
		i32 402; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554657, ; type_token_id
		i32 160; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554659, ; type_token_id
		i32 508; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554662, ; type_token_id
		i32 313; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554663, ; type_token_id
		i32 307; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554665, ; type_token_id
		i32 172; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554667, ; type_token_id
		i32 297; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554670, ; type_token_id
		i32 386; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554671, ; type_token_id
		i32 39; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554672, ; type_token_id
		i32 122; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554674, ; type_token_id
		i32 408; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554675, ; type_token_id
		i32 170; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554677, ; type_token_id
		i32 164; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554678, ; type_token_id
		i32 275; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554679, ; type_token_id
		i32 330; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554685, ; type_token_id
		i32 233; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554687, ; type_token_id
		i32 263; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554688, ; type_token_id
		i32 621; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554691, ; type_token_id
		i32 158; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554692, ; type_token_id
		i32 96; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554693, ; type_token_id
		i32 393; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554696, ; type_token_id
		i32 267; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554697, ; type_token_id
		i32 45; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554698, ; type_token_id
		i32 150; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554699, ; type_token_id
		i32 404; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554701, ; type_token_id
		i32 411; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554703, ; type_token_id
		i32 8; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554705, ; type_token_id
		i32 398; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554706, ; type_token_id
		i32 557; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554707, ; type_token_id
		i32 382; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554708, ; type_token_id
		i32 93; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554710, ; type_token_id
		i32 322; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554713, ; type_token_id
		i32 282; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554714, ; type_token_id
		i32 218; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554715, ; type_token_id
		i32 443; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554716, ; type_token_id
		i32 38; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554718, ; type_token_id
		i32 223; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554719, ; type_token_id
		i32 116; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554720, ; type_token_id
		i32 292; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554721, ; type_token_id
		i32 424; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554722, ; type_token_id
		i32 359; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554723, ; type_token_id
		i32 387; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554725, ; type_token_id
		i32 469; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554726, ; type_token_id
		i32 193; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554728, ; type_token_id
		i32 360; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554729, ; type_token_id
		i32 315; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554730, ; type_token_id
		i32 376; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554732, ; type_token_id
		i32 570; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554734, ; type_token_id
		i32 253; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554735, ; type_token_id
		i32 415; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554736, ; type_token_id
		i32 216; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554738, ; type_token_id
		i32 277; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554740, ; type_token_id
		i32 593; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554741, ; type_token_id
		i32 148; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554743, ; type_token_id
		i32 486; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554745, ; type_token_id
		i32 409; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554748, ; type_token_id
		i32 426; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554749, ; type_token_id
		i32 361; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554752, ; type_token_id
		i32 475; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554753, ; type_token_id
		i32 259; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554762, ; type_token_id
		i32 23; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554763, ; type_token_id
		i32 152; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554765, ; type_token_id
		i32 513; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554766, ; type_token_id
		i32 80; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554768, ; type_token_id
		i32 556; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554770, ; type_token_id
		i32 405; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554771, ; type_token_id
		i32 98; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554772, ; type_token_id
		i32 74; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554774, ; type_token_id
		i32 608; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554776, ; type_token_id
		i32 524; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554778, ; type_token_id
		i32 173; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554780, ; type_token_id
		i32 539; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554781, ; type_token_id
		i32 191; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554783, ; type_token_id
		i32 429; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554784, ; type_token_id
		i32 468; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554788, ; type_token_id
		i32 519; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554790, ; type_token_id
		i32 311; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554792, ; type_token_id
		i32 243; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554795, ; type_token_id
		i32 587; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554796, ; type_token_id
		i32 163; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554798, ; type_token_id
		i32 107; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554801, ; type_token_id
		i32 194; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554803, ; type_token_id
		i32 378; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554805, ; type_token_id
		i32 563; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554807, ; type_token_id
		i32 611; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554810, ; type_token_id
		i32 46; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554812, ; type_token_id
		i32 610; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554814, ; type_token_id
		i32 476; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554817, ; type_token_id
		i32 439; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554819, ; type_token_id
		i32 182; java_map_index
	}, 
	; 117
	%struct.TypeMapModuleEntry {
		i32 33554821, ; type_token_id
		i32 597; java_map_index
	}, 
	; 118
	%struct.TypeMapModuleEntry {
		i32 33554823, ; type_token_id
		i32 470; java_map_index
	}, 
	; 119
	%struct.TypeMapModuleEntry {
		i32 33554825, ; type_token_id
		i32 437; java_map_index
	}, 
	; 120
	%struct.TypeMapModuleEntry {
		i32 33554827, ; type_token_id
		i32 215; java_map_index
	}, 
	; 121
	%struct.TypeMapModuleEntry {
		i32 33554829, ; type_token_id
		i32 82; java_map_index
	}, 
	; 122
	%struct.TypeMapModuleEntry {
		i32 33554831, ; type_token_id
		i32 237; java_map_index
	}, 
	; 123
	%struct.TypeMapModuleEntry {
		i32 33554832, ; type_token_id
		i32 471; java_map_index
	}, 
	; 124
	%struct.TypeMapModuleEntry {
		i32 33554840, ; type_token_id
		i32 266; java_map_index
	}, 
	; 125
	%struct.TypeMapModuleEntry {
		i32 33554845, ; type_token_id
		i32 463; java_map_index
	}, 
	; 126
	%struct.TypeMapModuleEntry {
		i32 33554846, ; type_token_id
		i32 606; java_map_index
	}, 
	; 127
	%struct.TypeMapModuleEntry {
		i32 33554848, ; type_token_id
		i32 487; java_map_index
	}, 
	; 128
	%struct.TypeMapModuleEntry {
		i32 33554850, ; type_token_id
		i32 284; java_map_index
	}, 
	; 129
	%struct.TypeMapModuleEntry {
		i32 33554853, ; type_token_id
		i32 451; java_map_index
	}, 
	; 130
	%struct.TypeMapModuleEntry {
		i32 33554855, ; type_token_id
		i32 590; java_map_index
	}, 
	; 131
	%struct.TypeMapModuleEntry {
		i32 33554858, ; type_token_id
		i32 12; java_map_index
	}, 
	; 132
	%struct.TypeMapModuleEntry {
		i32 33554859, ; type_token_id
		i32 57; java_map_index
	}, 
	; 133
	%struct.TypeMapModuleEntry {
		i32 33554860, ; type_token_id
		i32 79; java_map_index
	}, 
	; 134
	%struct.TypeMapModuleEntry {
		i32 33554861, ; type_token_id
		i32 44; java_map_index
	}, 
	; 135
	%struct.TypeMapModuleEntry {
		i32 33554864, ; type_token_id
		i32 477; java_map_index
	}, 
	; 136
	%struct.TypeMapModuleEntry {
		i32 33554869, ; type_token_id
		i32 219; java_map_index
	}, 
	; 137
	%struct.TypeMapModuleEntry {
		i32 33554870, ; type_token_id
		i32 321; java_map_index
	}, 
	; 138
	%struct.TypeMapModuleEntry {
		i32 33554872, ; type_token_id
		i32 551; java_map_index
	}, 
	; 139
	%struct.TypeMapModuleEntry {
		i32 33554874, ; type_token_id
		i32 456; java_map_index
	}, 
	; 140
	%struct.TypeMapModuleEntry {
		i32 33554875, ; type_token_id
		i32 580; java_map_index
	}, 
	; 141
	%struct.TypeMapModuleEntry {
		i32 33554877, ; type_token_id
		i32 467; java_map_index
	}, 
	; 142
	%struct.TypeMapModuleEntry {
		i32 33554881, ; type_token_id
		i32 517; java_map_index
	}, 
	; 143
	%struct.TypeMapModuleEntry {
		i32 33554882, ; type_token_id
		i32 310; java_map_index
	}, 
	; 144
	%struct.TypeMapModuleEntry {
		i32 33554886, ; type_token_id
		i32 41; java_map_index
	}, 
	; 145
	%struct.TypeMapModuleEntry {
		i32 33554889, ; type_token_id
		i32 17; java_map_index
	}, 
	; 146
	%struct.TypeMapModuleEntry {
		i32 33554890, ; type_token_id
		i32 440; java_map_index
	}, 
	; 147
	%struct.TypeMapModuleEntry {
		i32 33554892, ; type_token_id
		i32 589; java_map_index
	}, 
	; 148
	%struct.TypeMapModuleEntry {
		i32 33554893, ; type_token_id
		i32 363; java_map_index
	}, 
	; 149
	%struct.TypeMapModuleEntry {
		i32 33554894, ; type_token_id
		i32 485; java_map_index
	}, 
	; 150
	%struct.TypeMapModuleEntry {
		i32 33554897, ; type_token_id
		i32 24; java_map_index
	}, 
	; 151
	%struct.TypeMapModuleEntry {
		i32 33554900, ; type_token_id
		i32 162; java_map_index
	}, 
	; 152
	%struct.TypeMapModuleEntry {
		i32 33554901, ; type_token_id
		i32 560; java_map_index
	}, 
	; 153
	%struct.TypeMapModuleEntry {
		i32 33554903, ; type_token_id
		i32 527; java_map_index
	}, 
	; 154
	%struct.TypeMapModuleEntry {
		i32 33554906, ; type_token_id
		i32 299; java_map_index
	}, 
	; 155
	%struct.TypeMapModuleEntry {
		i32 33554908, ; type_token_id
		i32 418; java_map_index
	}, 
	; 156
	%struct.TypeMapModuleEntry {
		i32 33554911, ; type_token_id
		i32 276; java_map_index
	}, 
	; 157
	%struct.TypeMapModuleEntry {
		i32 33554914, ; type_token_id
		i32 605; java_map_index
	}, 
	; 158
	%struct.TypeMapModuleEntry {
		i32 33554916, ; type_token_id
		i32 270; java_map_index
	}, 
	; 159
	%struct.TypeMapModuleEntry {
		i32 33554918, ; type_token_id
		i32 453; java_map_index
	}, 
	; 160
	%struct.TypeMapModuleEntry {
		i32 33554920, ; type_token_id
		i32 521; java_map_index
	}, 
	; 161
	%struct.TypeMapModuleEntry {
		i32 33554922, ; type_token_id
		i32 222; java_map_index
	}, 
	; 162
	%struct.TypeMapModuleEntry {
		i32 33554925, ; type_token_id
		i32 147; java_map_index
	}, 
	; 163
	%struct.TypeMapModuleEntry {
		i32 33554926, ; type_token_id
		i32 146; java_map_index
	}, 
	; 164
	%struct.TypeMapModuleEntry {
		i32 33554927, ; type_token_id
		i32 595; java_map_index
	}, 
	; 165
	%struct.TypeMapModuleEntry {
		i32 33554928, ; type_token_id
		i32 614; java_map_index
	}, 
	; 166
	%struct.TypeMapModuleEntry {
		i32 33554929, ; type_token_id
		i32 53; java_map_index
	}, 
	; 167
	%struct.TypeMapModuleEntry {
		i32 33554931, ; type_token_id
		i32 295; java_map_index
	}, 
	; 168
	%struct.TypeMapModuleEntry {
		i32 33554932, ; type_token_id
		i32 4; java_map_index
	}, 
	; 169
	%struct.TypeMapModuleEntry {
		i32 33554934, ; type_token_id
		i32 434; java_map_index
	}, 
	; 170
	%struct.TypeMapModuleEntry {
		i32 33554936, ; type_token_id
		i32 417; java_map_index
	}, 
	; 171
	%struct.TypeMapModuleEntry {
		i32 33554938, ; type_token_id
		i32 450; java_map_index
	}, 
	; 172
	%struct.TypeMapModuleEntry {
		i32 33554940, ; type_token_id
		i32 501; java_map_index
	}, 
	; 173
	%struct.TypeMapModuleEntry {
		i32 33554942, ; type_token_id
		i32 525; java_map_index
	}, 
	; 174
	%struct.TypeMapModuleEntry {
		i32 33554944, ; type_token_id
		i32 153; java_map_index
	}, 
	; 175
	%struct.TypeMapModuleEntry {
		i32 33554946, ; type_token_id
		i32 449; java_map_index
	}, 
	; 176
	%struct.TypeMapModuleEntry {
		i32 33554947, ; type_token_id
		i32 105; java_map_index
	}, 
	; 177
	%struct.TypeMapModuleEntry {
		i32 33554949, ; type_token_id
		i32 564; java_map_index
	}, 
	; 178
	%struct.TypeMapModuleEntry {
		i32 33554951, ; type_token_id
		i32 529; java_map_index
	}, 
	; 179
	%struct.TypeMapModuleEntry {
		i32 33554953, ; type_token_id
		i32 421; java_map_index
	}, 
	; 180
	%struct.TypeMapModuleEntry {
		i32 33554954, ; type_token_id
		i32 70; java_map_index
	}, 
	; 181
	%struct.TypeMapModuleEntry {
		i32 33554955, ; type_token_id
		i32 248; java_map_index
	}, 
	; 182
	%struct.TypeMapModuleEntry {
		i32 33554958, ; type_token_id
		i32 244; java_map_index
	}, 
	; 183
	%struct.TypeMapModuleEntry {
		i32 33554959, ; type_token_id
		i32 290; java_map_index
	}, 
	; 184
	%struct.TypeMapModuleEntry {
		i32 33554960, ; type_token_id
		i32 190; java_map_index
	}, 
	; 185
	%struct.TypeMapModuleEntry {
		i32 33554961, ; type_token_id
		i32 271; java_map_index
	}, 
	; 186
	%struct.TypeMapModuleEntry {
		i32 33554962, ; type_token_id
		i32 422; java_map_index
	}, 
	; 187
	%struct.TypeMapModuleEntry {
		i32 33554963, ; type_token_id
		i32 526; java_map_index
	}, 
	; 188
	%struct.TypeMapModuleEntry {
		i32 33554965, ; type_token_id
		i32 99; java_map_index
	}, 
	; 189
	%struct.TypeMapModuleEntry {
		i32 33554966, ; type_token_id
		i32 328; java_map_index
	}, 
	; 190
	%struct.TypeMapModuleEntry {
		i32 33554967, ; type_token_id
		i32 126; java_map_index
	}, 
	; 191
	%struct.TypeMapModuleEntry {
		i32 33554969, ; type_token_id
		i32 465; java_map_index
	}, 
	; 192
	%struct.TypeMapModuleEntry {
		i32 33554971, ; type_token_id
		i32 268; java_map_index
	}, 
	; 193
	%struct.TypeMapModuleEntry {
		i32 33554973, ; type_token_id
		i32 316; java_map_index
	}, 
	; 194
	%struct.TypeMapModuleEntry {
		i32 33554975, ; type_token_id
		i32 609; java_map_index
	}, 
	; 195
	%struct.TypeMapModuleEntry {
		i32 33554977, ; type_token_id
		i32 598; java_map_index
	}, 
	; 196
	%struct.TypeMapModuleEntry {
		i32 33554978, ; type_token_id
		i32 83; java_map_index
	}, 
	; 197
	%struct.TypeMapModuleEntry {
		i32 33554980, ; type_token_id
		i32 370; java_map_index
	}, 
	; 198
	%struct.TypeMapModuleEntry {
		i32 33554981, ; type_token_id
		i32 616; java_map_index
	}, 
	; 199
	%struct.TypeMapModuleEntry {
		i32 33554982, ; type_token_id
		i32 251; java_map_index
	}, 
	; 200
	%struct.TypeMapModuleEntry {
		i32 33554983, ; type_token_id
		i32 588; java_map_index
	}, 
	; 201
	%struct.TypeMapModuleEntry {
		i32 33554986, ; type_token_id
		i32 546; java_map_index
	}, 
	; 202
	%struct.TypeMapModuleEntry {
		i32 33554988, ; type_token_id
		i32 509; java_map_index
	}, 
	; 203
	%struct.TypeMapModuleEntry {
		i32 33554989, ; type_token_id
		i32 111; java_map_index
	}, 
	; 204
	%struct.TypeMapModuleEntry {
		i32 33554991, ; type_token_id
		i32 482; java_map_index
	}, 
	; 205
	%struct.TypeMapModuleEntry {
		i32 33554992, ; type_token_id
		i32 34; java_map_index
	}, 
	; 206
	%struct.TypeMapModuleEntry {
		i32 33554994, ; type_token_id
		i32 538; java_map_index
	}, 
	; 207
	%struct.TypeMapModuleEntry {
		i32 33554995, ; type_token_id
		i32 135; java_map_index
	}, 
	; 208
	%struct.TypeMapModuleEntry {
		i32 33554996, ; type_token_id
		i32 576; java_map_index
	}, 
	; 209
	%struct.TypeMapModuleEntry {
		i32 33554999, ; type_token_id
		i32 140; java_map_index
	}, 
	; 210
	%struct.TypeMapModuleEntry {
		i32 33555003, ; type_token_id
		i32 552; java_map_index
	}, 
	; 211
	%struct.TypeMapModuleEntry {
		i32 33555005, ; type_token_id
		i32 252; java_map_index
	}, 
	; 212
	%struct.TypeMapModuleEntry {
		i32 33555006, ; type_token_id
		i32 201; java_map_index
	}, 
	; 213
	%struct.TypeMapModuleEntry {
		i32 33555007, ; type_token_id
		i32 499; java_map_index
	}, 
	; 214
	%struct.TypeMapModuleEntry {
		i32 33555008, ; type_token_id
		i32 522; java_map_index
	}, 
	; 215
	%struct.TypeMapModuleEntry {
		i32 33555010, ; type_token_id
		i32 332; java_map_index
	}, 
	; 216
	%struct.TypeMapModuleEntry {
		i32 33555011, ; type_token_id
		i32 466; java_map_index
	}, 
	; 217
	%struct.TypeMapModuleEntry {
		i32 33555012, ; type_token_id
		i32 273; java_map_index
	}, 
	; 218
	%struct.TypeMapModuleEntry {
		i32 33555013, ; type_token_id
		i32 619; java_map_index
	}, 
	; 219
	%struct.TypeMapModuleEntry {
		i32 33555014, ; type_token_id
		i32 204; java_map_index
	}, 
	; 220
	%struct.TypeMapModuleEntry {
		i32 33555015, ; type_token_id
		i32 568; java_map_index
	}, 
	; 221
	%struct.TypeMapModuleEntry {
		i32 33555016, ; type_token_id
		i32 214; java_map_index
	}, 
	; 222
	%struct.TypeMapModuleEntry {
		i32 33555017, ; type_token_id
		i32 558; java_map_index
	}, 
	; 223
	%struct.TypeMapModuleEntry {
		i32 33555019, ; type_token_id
		i32 413; java_map_index
	}, 
	; 224
	%struct.TypeMapModuleEntry {
		i32 33555020, ; type_token_id
		i32 536; java_map_index
	}, 
	; 225
	%struct.TypeMapModuleEntry {
		i32 33555022, ; type_token_id
		i32 420; java_map_index
	}, 
	; 226
	%struct.TypeMapModuleEntry {
		i32 33555023, ; type_token_id
		i32 342; java_map_index
	}, 
	; 227
	%struct.TypeMapModuleEntry {
		i32 33555024, ; type_token_id
		i32 90; java_map_index
	}, 
	; 228
	%struct.TypeMapModuleEntry {
		i32 33555026, ; type_token_id
		i32 308; java_map_index
	}, 
	; 229
	%struct.TypeMapModuleEntry {
		i32 33555027, ; type_token_id
		i32 583; java_map_index
	}, 
	; 230
	%struct.TypeMapModuleEntry {
		i32 33555029, ; type_token_id
		i32 48; java_map_index
	}, 
	; 231
	%struct.TypeMapModuleEntry {
		i32 33555030, ; type_token_id
		i32 0; java_map_index
	}, 
	; 232
	%struct.TypeMapModuleEntry {
		i32 33555032, ; type_token_id
		i32 130; java_map_index
	}, 
	; 233
	%struct.TypeMapModuleEntry {
		i32 33555034, ; type_token_id
		i32 383; java_map_index
	}, 
	; 234
	%struct.TypeMapModuleEntry {
		i32 33555035, ; type_token_id
		i32 185; java_map_index
	}, 
	; 235
	%struct.TypeMapModuleEntry {
		i32 33555036, ; type_token_id
		i32 464; java_map_index
	}, 
	; 236
	%struct.TypeMapModuleEntry {
		i32 33555039, ; type_token_id
		i32 167; java_map_index
	}, 
	; 237
	%struct.TypeMapModuleEntry {
		i32 33555044, ; type_token_id
		i32 339; java_map_index
	}, 
	; 238
	%struct.TypeMapModuleEntry {
		i32 33555046, ; type_token_id
		i32 62; java_map_index
	}, 
	; 239
	%struct.TypeMapModuleEntry {
		i32 33555049, ; type_token_id
		i32 202; java_map_index
	}, 
	; 240
	%struct.TypeMapModuleEntry {
		i32 33555051, ; type_token_id
		i32 489; java_map_index
	}, 
	; 241
	%struct.TypeMapModuleEntry {
		i32 33555053, ; type_token_id
		i32 503; java_map_index
	}, 
	; 242
	%struct.TypeMapModuleEntry {
		i32 33555055, ; type_token_id
		i32 596; java_map_index
	}, 
	; 243
	%struct.TypeMapModuleEntry {
		i32 33555056, ; type_token_id
		i32 305; java_map_index
	}, 
	; 244
	%struct.TypeMapModuleEntry {
		i32 33555057, ; type_token_id
		i32 239; java_map_index
	}, 
	; 245
	%struct.TypeMapModuleEntry {
		i32 33555058, ; type_token_id
		i32 323; java_map_index
	}, 
	; 246
	%struct.TypeMapModuleEntry {
		i32 33555059, ; type_token_id
		i32 349; java_map_index
	}, 
	; 247
	%struct.TypeMapModuleEntry {
		i32 33555060, ; type_token_id
		i32 186; java_map_index
	}, 
	; 248
	%struct.TypeMapModuleEntry {
		i32 33555062, ; type_token_id
		i32 381; java_map_index
	}, 
	; 249
	%struct.TypeMapModuleEntry {
		i32 33555064, ; type_token_id
		i32 15; java_map_index
	}, 
	; 250
	%struct.TypeMapModuleEntry {
		i32 33555065, ; type_token_id
		i32 579; java_map_index
	}, 
	; 251
	%struct.TypeMapModuleEntry {
		i32 33555074, ; type_token_id
		i32 106; java_map_index
	}, 
	; 252
	%struct.TypeMapModuleEntry {
		i32 33555075, ; type_token_id
		i32 566; java_map_index
	}, 
	; 253
	%struct.TypeMapModuleEntry {
		i32 33555081, ; type_token_id
		i32 473; java_map_index
	}, 
	; 254
	%struct.TypeMapModuleEntry {
		i32 33555082, ; type_token_id
		i32 245; java_map_index
	}, 
	; 255
	%struct.TypeMapModuleEntry {
		i32 33555084, ; type_token_id
		i32 362; java_map_index
	}, 
	; 256
	%struct.TypeMapModuleEntry {
		i32 33555087, ; type_token_id
		i32 585; java_map_index
	}, 
	; 257
	%struct.TypeMapModuleEntry {
		i32 33555088, ; type_token_id
		i32 309; java_map_index
	}, 
	; 258
	%struct.TypeMapModuleEntry {
		i32 33555090, ; type_token_id
		i32 301; java_map_index
	}, 
	; 259
	%struct.TypeMapModuleEntry {
		i32 33555092, ; type_token_id
		i32 206; java_map_index
	}, 
	; 260
	%struct.TypeMapModuleEntry {
		i32 33555094, ; type_token_id
		i32 575; java_map_index
	}, 
	; 261
	%struct.TypeMapModuleEntry {
		i32 33555095, ; type_token_id
		i32 372; java_map_index
	}, 
	; 262
	%struct.TypeMapModuleEntry {
		i32 33555097, ; type_token_id
		i32 584; java_map_index
	}, 
	; 263
	%struct.TypeMapModuleEntry {
		i32 33555099, ; type_token_id
		i32 392; java_map_index
	}, 
	; 264
	%struct.TypeMapModuleEntry {
		i32 33555101, ; type_token_id
		i32 221; java_map_index
	}, 
	; 265
	%struct.TypeMapModuleEntry {
		i32 33555102, ; type_token_id
		i32 438; java_map_index
	}, 
	; 266
	%struct.TypeMapModuleEntry {
		i32 33555105, ; type_token_id
		i32 567; java_map_index
	}, 
	; 267
	%struct.TypeMapModuleEntry {
		i32 33555106, ; type_token_id
		i32 92; java_map_index
	}, 
	; 268
	%struct.TypeMapModuleEntry {
		i32 33555108, ; type_token_id
		i32 300; java_map_index
	}, 
	; 269
	%struct.TypeMapModuleEntry {
		i32 33555109, ; type_token_id
		i32 314; java_map_index
	}, 
	; 270
	%struct.TypeMapModuleEntry {
		i32 33555111, ; type_token_id
		i32 350; java_map_index
	}, 
	; 271
	%struct.TypeMapModuleEntry {
		i32 33555112, ; type_token_id
		i32 326; java_map_index
	}, 
	; 272
	%struct.TypeMapModuleEntry {
		i32 33555114, ; type_token_id
		i32 211; java_map_index
	}, 
	; 273
	%struct.TypeMapModuleEntry {
		i32 33555117, ; type_token_id
		i32 431; java_map_index
	}, 
	; 274
	%struct.TypeMapModuleEntry {
		i32 33555119, ; type_token_id
		i32 10; java_map_index
	}, 
	; 275
	%struct.TypeMapModuleEntry {
		i32 33555120, ; type_token_id
		i32 394; java_map_index
	}, 
	; 276
	%struct.TypeMapModuleEntry {
		i32 33555123, ; type_token_id
		i32 550; java_map_index
	}, 
	; 277
	%struct.TypeMapModuleEntry {
		i32 33555124, ; type_token_id
		i32 134; java_map_index
	}, 
	; 278
	%struct.TypeMapModuleEntry {
		i32 33555125, ; type_token_id
		i32 274; java_map_index
	}, 
	; 279
	%struct.TypeMapModuleEntry {
		i32 33555126, ; type_token_id
		i32 335; java_map_index
	}, 
	; 280
	%struct.TypeMapModuleEntry {
		i32 33555129, ; type_token_id
		i32 161; java_map_index
	}, 
	; 281
	%struct.TypeMapModuleEntry {
		i32 33555130, ; type_token_id
		i32 367; java_map_index
	}, 
	; 282
	%struct.TypeMapModuleEntry {
		i32 33555131, ; type_token_id
		i32 545; java_map_index
	}, 
	; 283
	%struct.TypeMapModuleEntry {
		i32 33555153, ; type_token_id
		i32 571; java_map_index
	}, 
	; 284
	%struct.TypeMapModuleEntry {
		i32 33555155, ; type_token_id
		i32 447; java_map_index
	}, 
	; 285
	%struct.TypeMapModuleEntry {
		i32 33555157, ; type_token_id
		i32 200; java_map_index
	}, 
	; 286
	%struct.TypeMapModuleEntry {
		i32 33555159, ; type_token_id
		i32 228; java_map_index
	}, 
	; 287
	%struct.TypeMapModuleEntry {
		i32 33555168, ; type_token_id
		i32 112; java_map_index
	}, 
	; 288
	%struct.TypeMapModuleEntry {
		i32 33555170, ; type_token_id
		i32 518; java_map_index
	}, 
	; 289
	%struct.TypeMapModuleEntry {
		i32 33555172, ; type_token_id
		i32 507; java_map_index
	}, 
	; 290
	%struct.TypeMapModuleEntry {
		i32 33555173, ; type_token_id
		i32 607; java_map_index
	}, 
	; 291
	%struct.TypeMapModuleEntry {
		i32 33555189, ; type_token_id
		i32 86; java_map_index
	}, 
	; 292
	%struct.TypeMapModuleEntry {
		i32 33555202, ; type_token_id
		i32 69; java_map_index
	}, 
	; 293
	%struct.TypeMapModuleEntry {
		i32 33555203, ; type_token_id
		i32 28; java_map_index
	}, 
	; 294
	%struct.TypeMapModuleEntry {
		i32 33555204, ; type_token_id
		i32 128; java_map_index
	}, 
	; 295
	%struct.TypeMapModuleEntry {
		i32 33555205, ; type_token_id
		i32 384; java_map_index
	}, 
	; 296
	%struct.TypeMapModuleEntry {
		i32 33555207, ; type_token_id
		i32 446; java_map_index
	}, 
	; 297
	%struct.TypeMapModuleEntry {
		i32 33555209, ; type_token_id
		i32 67; java_map_index
	}, 
	; 298
	%struct.TypeMapModuleEntry {
		i32 33555211, ; type_token_id
		i32 213; java_map_index
	}, 
	; 299
	%struct.TypeMapModuleEntry {
		i32 33555213, ; type_token_id
		i32 516; java_map_index
	}, 
	; 300
	%struct.TypeMapModuleEntry {
		i32 33555214, ; type_token_id
		i32 530; java_map_index
	}, 
	; 301
	%struct.TypeMapModuleEntry {
		i32 33555215, ; type_token_id
		i32 481; java_map_index
	}, 
	; 302
	%struct.TypeMapModuleEntry {
		i32 33555216, ; type_token_id
		i32 348; java_map_index
	}, 
	; 303
	%struct.TypeMapModuleEntry {
		i32 33555217, ; type_token_id
		i32 416; java_map_index
	}, 
	; 304
	%struct.TypeMapModuleEntry {
		i32 33555219, ; type_token_id
		i32 159; java_map_index
	}, 
	; 305
	%struct.TypeMapModuleEntry {
		i32 33555221, ; type_token_id
		i32 369; java_map_index
	}, 
	; 306
	%struct.TypeMapModuleEntry {
		i32 33555222, ; type_token_id
		i32 192; java_map_index
	}, 
	; 307
	%struct.TypeMapModuleEntry {
		i32 33555223, ; type_token_id
		i32 347; java_map_index
	}, 
	; 308
	%struct.TypeMapModuleEntry {
		i32 33555224, ; type_token_id
		i32 54; java_map_index
	}, 
	; 309
	%struct.TypeMapModuleEntry {
		i32 33555225, ; type_token_id
		i32 104; java_map_index
	}, 
	; 310
	%struct.TypeMapModuleEntry {
		i32 33555226, ; type_token_id
		i32 500; java_map_index
	}, 
	; 311
	%struct.TypeMapModuleEntry {
		i32 33555228, ; type_token_id
		i32 175; java_map_index
	}, 
	; 312
	%struct.TypeMapModuleEntry {
		i32 33555230, ; type_token_id
		i32 66; java_map_index
	}, 
	; 313
	%struct.TypeMapModuleEntry {
		i32 33555232, ; type_token_id
		i32 269; java_map_index
	}, 
	; 314
	%struct.TypeMapModuleEntry {
		i32 33555233, ; type_token_id
		i32 250; java_map_index
	}, 
	; 315
	%struct.TypeMapModuleEntry {
		i32 33555235, ; type_token_id
		i32 562; java_map_index
	}, 
	; 316
	%struct.TypeMapModuleEntry {
		i32 33555236, ; type_token_id
		i32 64; java_map_index
	}, 
	; 317
	%struct.TypeMapModuleEntry {
		i32 33555238, ; type_token_id
		i32 165; java_map_index
	}, 
	; 318
	%struct.TypeMapModuleEntry {
		i32 33555240, ; type_token_id
		i32 327; java_map_index
	}, 
	; 319
	%struct.TypeMapModuleEntry {
		i32 33555241, ; type_token_id
		i32 9; java_map_index
	}, 
	; 320
	%struct.TypeMapModuleEntry {
		i32 33555243, ; type_token_id
		i32 279; java_map_index
	}, 
	; 321
	%struct.TypeMapModuleEntry {
		i32 33555244, ; type_token_id
		i32 320; java_map_index
	}, 
	; 322
	%struct.TypeMapModuleEntry {
		i32 33555246, ; type_token_id
		i32 380; java_map_index
	}, 
	; 323
	%struct.TypeMapModuleEntry {
		i32 33555248, ; type_token_id
		i32 592; java_map_index
	}, 
	; 324
	%struct.TypeMapModuleEntry {
		i32 33555249, ; type_token_id
		i32 11; java_map_index
	}, 
	; 325
	%struct.TypeMapModuleEntry {
		i32 33555252, ; type_token_id
		i32 139; java_map_index
	}, 
	; 326
	%struct.TypeMapModuleEntry {
		i32 33555255, ; type_token_id
		i32 293; java_map_index
	}, 
	; 327
	%struct.TypeMapModuleEntry {
		i32 33555257, ; type_token_id
		i32 30; java_map_index
	}, 
	; 328
	%struct.TypeMapModuleEntry {
		i32 33555259, ; type_token_id
		i32 95; java_map_index
	}, 
	; 329
	%struct.TypeMapModuleEntry {
		i32 33555261, ; type_token_id
		i32 246; java_map_index
	}, 
	; 330
	%struct.TypeMapModuleEntry {
		i32 33555263, ; type_token_id
		i32 33; java_map_index
	}, 
	; 331
	%struct.TypeMapModuleEntry {
		i32 33555265, ; type_token_id
		i32 155; java_map_index
	}, 
	; 332
	%struct.TypeMapModuleEntry {
		i32 33555267, ; type_token_id
		i32 291; java_map_index
	}, 
	; 333
	%struct.TypeMapModuleEntry {
		i32 33555269, ; type_token_id
		i32 377; java_map_index
	}, 
	; 334
	%struct.TypeMapModuleEntry {
		i32 33555271, ; type_token_id
		i32 247; java_map_index
	}, 
	; 335
	%struct.TypeMapModuleEntry {
		i32 33555273, ; type_token_id
		i32 20; java_map_index
	}, 
	; 336
	%struct.TypeMapModuleEntry {
		i32 33555275, ; type_token_id
		i32 37; java_map_index
	}, 
	; 337
	%struct.TypeMapModuleEntry {
		i32 33555277, ; type_token_id
		i32 231; java_map_index
	}, 
	; 338
	%struct.TypeMapModuleEntry {
		i32 33555279, ; type_token_id
		i32 306; java_map_index
	}, 
	; 339
	%struct.TypeMapModuleEntry {
		i32 33555280, ; type_token_id
		i32 261; java_map_index
	}, 
	; 340
	%struct.TypeMapModuleEntry {
		i32 33555281, ; type_token_id
		i32 265; java_map_index
	}, 
	; 341
	%struct.TypeMapModuleEntry {
		i32 33555282, ; type_token_id
		i32 553; java_map_index
	}, 
	; 342
	%struct.TypeMapModuleEntry {
		i32 33555283, ; type_token_id
		i32 179; java_map_index
	}, 
	; 343
	%struct.TypeMapModuleEntry {
		i32 33555284, ; type_token_id
		i32 523; java_map_index
	}, 
	; 344
	%struct.TypeMapModuleEntry {
		i32 33555285, ; type_token_id
		i32 442; java_map_index
	}, 
	; 345
	%struct.TypeMapModuleEntry {
		i32 33555286, ; type_token_id
		i32 419; java_map_index
	}, 
	; 346
	%struct.TypeMapModuleEntry {
		i32 33555287, ; type_token_id
		i32 120; java_map_index
	}, 
	; 347
	%struct.TypeMapModuleEntry {
		i32 33555288, ; type_token_id
		i32 124; java_map_index
	}, 
	; 348
	%struct.TypeMapModuleEntry {
		i32 33555289, ; type_token_id
		i32 65; java_map_index
	}, 
	; 349
	%struct.TypeMapModuleEntry {
		i32 33555290, ; type_token_id
		i32 1; java_map_index
	}, 
	; 350
	%struct.TypeMapModuleEntry {
		i32 33555291, ; type_token_id
		i32 254; java_map_index
	}, 
	; 351
	%struct.TypeMapModuleEntry {
		i32 33555292, ; type_token_id
		i32 137; java_map_index
	}, 
	; 352
	%struct.TypeMapModuleEntry {
		i32 33555293, ; type_token_id
		i32 514; java_map_index
	}, 
	; 353
	%struct.TypeMapModuleEntry {
		i32 33555295, ; type_token_id
		i32 127; java_map_index
	}, 
	; 354
	%struct.TypeMapModuleEntry {
		i32 33555296, ; type_token_id
		i32 61; java_map_index
	}, 
	; 355
	%struct.TypeMapModuleEntry {
		i32 33555297, ; type_token_id
		i32 196; java_map_index
	}, 
	; 356
	%struct.TypeMapModuleEntry {
		i32 33555298, ; type_token_id
		i32 203; java_map_index
	}, 
	; 357
	%struct.TypeMapModuleEntry {
		i32 33555299, ; type_token_id
		i32 68; java_map_index
	}, 
	; 358
	%struct.TypeMapModuleEntry {
		i32 33555301, ; type_token_id
		i32 357; java_map_index
	}, 
	; 359
	%struct.TypeMapModuleEntry {
		i32 33555303, ; type_token_id
		i32 577; java_map_index
	}, 
	; 360
	%struct.TypeMapModuleEntry {
		i32 33555304, ; type_token_id
		i32 183; java_map_index
	}, 
	; 361
	%struct.TypeMapModuleEntry {
		i32 33555306, ; type_token_id
		i32 2; java_map_index
	}, 
	; 362
	%struct.TypeMapModuleEntry {
		i32 33555310, ; type_token_id
		i32 176; java_map_index
	}, 
	; 363
	%struct.TypeMapModuleEntry {
		i32 33555312, ; type_token_id
		i32 207; java_map_index
	}, 
	; 364
	%struct.TypeMapModuleEntry {
		i32 33555314, ; type_token_id
		i32 354; java_map_index
	}, 
	; 365
	%struct.TypeMapModuleEntry {
		i32 33555316, ; type_token_id
		i32 31; java_map_index
	}, 
	; 366
	%struct.TypeMapModuleEntry {
		i32 33555317, ; type_token_id
		i32 97; java_map_index
	}, 
	; 367
	%struct.TypeMapModuleEntry {
		i32 33555318, ; type_token_id
		i32 256; java_map_index
	}, 
	; 368
	%struct.TypeMapModuleEntry {
		i32 33555319, ; type_token_id
		i32 149; java_map_index
	}, 
	; 369
	%struct.TypeMapModuleEntry {
		i32 33555321, ; type_token_id
		i32 281; java_map_index
	}, 
	; 370
	%struct.TypeMapModuleEntry {
		i32 33555323, ; type_token_id
		i32 72; java_map_index
	}, 
	; 371
	%struct.TypeMapModuleEntry {
		i32 33555324, ; type_token_id
		i32 586; java_map_index
	}, 
	; 372
	%struct.TypeMapModuleEntry {
		i32 33555325, ; type_token_id
		i32 129; java_map_index
	}, 
	; 373
	%struct.TypeMapModuleEntry {
		i32 33555326, ; type_token_id
		i32 493; java_map_index
	}, 
	; 374
	%struct.TypeMapModuleEntry {
		i32 33555328, ; type_token_id
		i32 40; java_map_index
	}, 
	; 375
	%struct.TypeMapModuleEntry {
		i32 33555329, ; type_token_id
		i32 212; java_map_index
	}, 
	; 376
	%struct.TypeMapModuleEntry {
		i32 33555330, ; type_token_id
		i32 366; java_map_index
	}, 
	; 377
	%struct.TypeMapModuleEntry {
		i32 33555331, ; type_token_id
		i32 166; java_map_index
	}, 
	; 378
	%struct.TypeMapModuleEntry {
		i32 33555333, ; type_token_id
		i32 76; java_map_index
	}, 
	; 379
	%struct.TypeMapModuleEntry {
		i32 33555335, ; type_token_id
		i32 5; java_map_index
	}, 
	; 380
	%struct.TypeMapModuleEntry {
		i32 33555337, ; type_token_id
		i32 351; java_map_index
	}, 
	; 381
	%struct.TypeMapModuleEntry {
		i32 33555339, ; type_token_id
		i32 27; java_map_index
	}, 
	; 382
	%struct.TypeMapModuleEntry {
		i32 33555341, ; type_token_id
		i32 235; java_map_index
	}, 
	; 383
	%struct.TypeMapModuleEntry {
		i32 33555342, ; type_token_id
		i32 154; java_map_index
	}, 
	; 384
	%struct.TypeMapModuleEntry {
		i32 33555343, ; type_token_id
		i32 379; java_map_index
	}, 
	; 385
	%struct.TypeMapModuleEntry {
		i32 33555344, ; type_token_id
		i32 620; java_map_index
	}, 
	; 386
	%struct.TypeMapModuleEntry {
		i32 33555346, ; type_token_id
		i32 474; java_map_index
	}, 
	; 387
	%struct.TypeMapModuleEntry {
		i32 33555348, ; type_token_id
		i32 559; java_map_index
	}, 
	; 388
	%struct.TypeMapModuleEntry {
		i32 33555350, ; type_token_id
		i32 397; java_map_index
	}, 
	; 389
	%struct.TypeMapModuleEntry {
		i32 33555351, ; type_token_id
		i32 602; java_map_index
	}, 
	; 390
	%struct.TypeMapModuleEntry {
		i32 33555352, ; type_token_id
		i32 102; java_map_index
	}, 
	; 391
	%struct.TypeMapModuleEntry {
		i32 33555354, ; type_token_id
		i32 298; java_map_index
	}, 
	; 392
	%struct.TypeMapModuleEntry {
		i32 33555356, ; type_token_id
		i32 121; java_map_index
	}, 
	; 393
	%struct.TypeMapModuleEntry {
		i32 33555357, ; type_token_id
		i32 591; java_map_index
	}, 
	; 394
	%struct.TypeMapModuleEntry {
		i32 33555359, ; type_token_id
		i32 455; java_map_index
	}, 
	; 395
	%struct.TypeMapModuleEntry {
		i32 33555360, ; type_token_id
		i32 594; java_map_index
	}, 
	; 396
	%struct.TypeMapModuleEntry {
		i32 33555383, ; type_token_id
		i32 448; java_map_index
	}
], align 4; end of 'module7_managed_to_java' array


; module7_managed_to_java_duplicates
@module7_managed_to_java_duplicates = internal constant [199 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554599, ; type_token_id
		i32 344; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554603, ; type_token_id
		i32 187; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554605, ; type_token_id
		i32 43; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554607, ; type_token_id
		i32 528; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554609, ; type_token_id
		i32 490; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554611, ; type_token_id
		i32 400; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554613, ; type_token_id
		i32 205; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554615, ; type_token_id
		i32 479; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554617, ; type_token_id
		i32 22; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554619, ; type_token_id
		i32 136; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554621, ; type_token_id
		i32 548; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554625, ; type_token_id
		i32 572; java_map_index
	}, 
	; 12
	%struct.TypeMapModuleEntry {
		i32 33554628, ; type_token_id
		i32 32; java_map_index
	}, 
	; 13
	%struct.TypeMapModuleEntry {
		i32 33554630, ; type_token_id
		i32 177; java_map_index
	}, 
	; 14
	%struct.TypeMapModuleEntry {
		i32 33554632, ; type_token_id
		i32 286; java_map_index
	}, 
	; 15
	%struct.TypeMapModuleEntry {
		i32 33554644, ; type_token_id
		i32 561; java_map_index
	}, 
	; 16
	%struct.TypeMapModuleEntry {
		i32 33554646, ; type_token_id
		i32 410; java_map_index
	}, 
	; 17
	%struct.TypeMapModuleEntry {
		i32 33554650, ; type_token_id
		i32 317; java_map_index
	}, 
	; 18
	%struct.TypeMapModuleEntry {
		i32 33554652, ; type_token_id
		i32 460; java_map_index
	}, 
	; 19
	%struct.TypeMapModuleEntry {
		i32 33554654, ; type_token_id
		i32 375; java_map_index
	}, 
	; 20
	%struct.TypeMapModuleEntry {
		i32 33554658, ; type_token_id
		i32 160; java_map_index
	}, 
	; 21
	%struct.TypeMapModuleEntry {
		i32 33554661, ; type_token_id
		i32 508; java_map_index
	}, 
	; 22
	%struct.TypeMapModuleEntry {
		i32 33554664, ; type_token_id
		i32 307; java_map_index
	}, 
	; 23
	%struct.TypeMapModuleEntry {
		i32 33554666, ; type_token_id
		i32 172; java_map_index
	}, 
	; 24
	%struct.TypeMapModuleEntry {
		i32 33554668, ; type_token_id
		i32 297; java_map_index
	}, 
	; 25
	%struct.TypeMapModuleEntry {
		i32 33554669, ; type_token_id
		i32 313; java_map_index
	}, 
	; 26
	%struct.TypeMapModuleEntry {
		i32 33554673, ; type_token_id
		i32 122; java_map_index
	}, 
	; 27
	%struct.TypeMapModuleEntry {
		i32 33554676, ; type_token_id
		i32 170; java_map_index
	}, 
	; 28
	%struct.TypeMapModuleEntry {
		i32 33554680, ; type_token_id
		i32 330; java_map_index
	}, 
	; 29
	%struct.TypeMapModuleEntry {
		i32 33554681, ; type_token_id
		i32 313; java_map_index
	}, 
	; 30
	%struct.TypeMapModuleEntry {
		i32 33554683, ; type_token_id
		i32 386; java_map_index
	}, 
	; 31
	%struct.TypeMapModuleEntry {
		i32 33554684, ; type_token_id
		i32 386; java_map_index
	}, 
	; 32
	%struct.TypeMapModuleEntry {
		i32 33554689, ; type_token_id
		i32 621; java_map_index
	}, 
	; 33
	%struct.TypeMapModuleEntry {
		i32 33554690, ; type_token_id
		i32 263; java_map_index
	}, 
	; 34
	%struct.TypeMapModuleEntry {
		i32 33554694, ; type_token_id
		i32 393; java_map_index
	}, 
	; 35
	%struct.TypeMapModuleEntry {
		i32 33554695, ; type_token_id
		i32 96; java_map_index
	}, 
	; 36
	%struct.TypeMapModuleEntry {
		i32 33554700, ; type_token_id
		i32 404; java_map_index
	}, 
	; 37
	%struct.TypeMapModuleEntry {
		i32 33554702, ; type_token_id
		i32 411; java_map_index
	}, 
	; 38
	%struct.TypeMapModuleEntry {
		i32 33554704, ; type_token_id
		i32 8; java_map_index
	}, 
	; 39
	%struct.TypeMapModuleEntry {
		i32 33554709, ; type_token_id
		i32 93; java_map_index
	}, 
	; 40
	%struct.TypeMapModuleEntry {
		i32 33554711, ; type_token_id
		i32 322; java_map_index
	}, 
	; 41
	%struct.TypeMapModuleEntry {
		i32 33554724, ; type_token_id
		i32 387; java_map_index
	}, 
	; 42
	%struct.TypeMapModuleEntry {
		i32 33554727, ; type_token_id
		i32 193; java_map_index
	}, 
	; 43
	%struct.TypeMapModuleEntry {
		i32 33554731, ; type_token_id
		i32 376; java_map_index
	}, 
	; 44
	%struct.TypeMapModuleEntry {
		i32 33554737, ; type_token_id
		i32 216; java_map_index
	}, 
	; 45
	%struct.TypeMapModuleEntry {
		i32 33554739, ; type_token_id
		i32 277; java_map_index
	}, 
	; 46
	%struct.TypeMapModuleEntry {
		i32 33554742, ; type_token_id
		i32 148; java_map_index
	}, 
	; 47
	%struct.TypeMapModuleEntry {
		i32 33554744, ; type_token_id
		i32 486; java_map_index
	}, 
	; 48
	%struct.TypeMapModuleEntry {
		i32 33554746, ; type_token_id
		i32 409; java_map_index
	}, 
	; 49
	%struct.TypeMapModuleEntry {
		i32 33554750, ; type_token_id
		i32 361; java_map_index
	}, 
	; 50
	%struct.TypeMapModuleEntry {
		i32 33554754, ; type_token_id
		i32 259; java_map_index
	}, 
	; 51
	%struct.TypeMapModuleEntry {
		i32 33554764, ; type_token_id
		i32 152; java_map_index
	}, 
	; 52
	%struct.TypeMapModuleEntry {
		i32 33554767, ; type_token_id
		i32 80; java_map_index
	}, 
	; 53
	%struct.TypeMapModuleEntry {
		i32 33554769, ; type_token_id
		i32 556; java_map_index
	}, 
	; 54
	%struct.TypeMapModuleEntry {
		i32 33554773, ; type_token_id
		i32 74; java_map_index
	}, 
	; 55
	%struct.TypeMapModuleEntry {
		i32 33554775, ; type_token_id
		i32 608; java_map_index
	}, 
	; 56
	%struct.TypeMapModuleEntry {
		i32 33554777, ; type_token_id
		i32 524; java_map_index
	}, 
	; 57
	%struct.TypeMapModuleEntry {
		i32 33554779, ; type_token_id
		i32 173; java_map_index
	}, 
	; 58
	%struct.TypeMapModuleEntry {
		i32 33554782, ; type_token_id
		i32 191; java_map_index
	}, 
	; 59
	%struct.TypeMapModuleEntry {
		i32 33554785, ; type_token_id
		i32 468; java_map_index
	}, 
	; 60
	%struct.TypeMapModuleEntry {
		i32 33554786, ; type_token_id
		i32 429; java_map_index
	}, 
	; 61
	%struct.TypeMapModuleEntry {
		i32 33554789, ; type_token_id
		i32 519; java_map_index
	}, 
	; 62
	%struct.TypeMapModuleEntry {
		i32 33554797, ; type_token_id
		i32 163; java_map_index
	}, 
	; 63
	%struct.TypeMapModuleEntry {
		i32 33554799, ; type_token_id
		i32 107; java_map_index
	}, 
	; 64
	%struct.TypeMapModuleEntry {
		i32 33554802, ; type_token_id
		i32 194; java_map_index
	}, 
	; 65
	%struct.TypeMapModuleEntry {
		i32 33554804, ; type_token_id
		i32 378; java_map_index
	}, 
	; 66
	%struct.TypeMapModuleEntry {
		i32 33554806, ; type_token_id
		i32 563; java_map_index
	}, 
	; 67
	%struct.TypeMapModuleEntry {
		i32 33554809, ; type_token_id
		i32 611; java_map_index
	}, 
	; 68
	%struct.TypeMapModuleEntry {
		i32 33554811, ; type_token_id
		i32 46; java_map_index
	}, 
	; 69
	%struct.TypeMapModuleEntry {
		i32 33554813, ; type_token_id
		i32 610; java_map_index
	}, 
	; 70
	%struct.TypeMapModuleEntry {
		i32 33554816, ; type_token_id
		i32 476; java_map_index
	}, 
	; 71
	%struct.TypeMapModuleEntry {
		i32 33554818, ; type_token_id
		i32 439; java_map_index
	}, 
	; 72
	%struct.TypeMapModuleEntry {
		i32 33554820, ; type_token_id
		i32 182; java_map_index
	}, 
	; 73
	%struct.TypeMapModuleEntry {
		i32 33554822, ; type_token_id
		i32 597; java_map_index
	}, 
	; 74
	%struct.TypeMapModuleEntry {
		i32 33554824, ; type_token_id
		i32 470; java_map_index
	}, 
	; 75
	%struct.TypeMapModuleEntry {
		i32 33554826, ; type_token_id
		i32 437; java_map_index
	}, 
	; 76
	%struct.TypeMapModuleEntry {
		i32 33554828, ; type_token_id
		i32 215; java_map_index
	}, 
	; 77
	%struct.TypeMapModuleEntry {
		i32 33554830, ; type_token_id
		i32 82; java_map_index
	}, 
	; 78
	%struct.TypeMapModuleEntry {
		i32 33554833, ; type_token_id
		i32 471; java_map_index
	}, 
	; 79
	%struct.TypeMapModuleEntry {
		i32 33554837, ; type_token_id
		i32 513; java_map_index
	}, 
	; 80
	%struct.TypeMapModuleEntry {
		i32 33554847, ; type_token_id
		i32 606; java_map_index
	}, 
	; 81
	%struct.TypeMapModuleEntry {
		i32 33554862, ; type_token_id
		i32 44; java_map_index
	}, 
	; 82
	%struct.TypeMapModuleEntry {
		i32 33554863, ; type_token_id
		i32 12; java_map_index
	}, 
	; 83
	%struct.TypeMapModuleEntry {
		i32 33554866, ; type_token_id
		i32 539; java_map_index
	}, 
	; 84
	%struct.TypeMapModuleEntry {
		i32 33554871, ; type_token_id
		i32 321; java_map_index
	}, 
	; 85
	%struct.TypeMapModuleEntry {
		i32 33554873, ; type_token_id
		i32 551; java_map_index
	}, 
	; 86
	%struct.TypeMapModuleEntry {
		i32 33554876, ; type_token_id
		i32 580; java_map_index
	}, 
	; 87
	%struct.TypeMapModuleEntry {
		i32 33554887, ; type_token_id
		i32 41; java_map_index
	}, 
	; 88
	%struct.TypeMapModuleEntry {
		i32 33554891, ; type_token_id
		i32 440; java_map_index
	}, 
	; 89
	%struct.TypeMapModuleEntry {
		i32 33554895, ; type_token_id
		i32 485; java_map_index
	}, 
	; 90
	%struct.TypeMapModuleEntry {
		i32 33554898, ; type_token_id
		i32 24; java_map_index
	}, 
	; 91
	%struct.TypeMapModuleEntry {
		i32 33554902, ; type_token_id
		i32 560; java_map_index
	}, 
	; 92
	%struct.TypeMapModuleEntry {
		i32 33554904, ; type_token_id
		i32 527; java_map_index
	}, 
	; 93
	%struct.TypeMapModuleEntry {
		i32 33554907, ; type_token_id
		i32 299; java_map_index
	}, 
	; 94
	%struct.TypeMapModuleEntry {
		i32 33554909, ; type_token_id
		i32 418; java_map_index
	}, 
	; 95
	%struct.TypeMapModuleEntry {
		i32 33554912, ; type_token_id
		i32 276; java_map_index
	}, 
	; 96
	%struct.TypeMapModuleEntry {
		i32 33554915, ; type_token_id
		i32 605; java_map_index
	}, 
	; 97
	%struct.TypeMapModuleEntry {
		i32 33554917, ; type_token_id
		i32 270; java_map_index
	}, 
	; 98
	%struct.TypeMapModuleEntry {
		i32 33554923, ; type_token_id
		i32 222; java_map_index
	}, 
	; 99
	%struct.TypeMapModuleEntry {
		i32 33554930, ; type_token_id
		i32 53; java_map_index
	}, 
	; 100
	%struct.TypeMapModuleEntry {
		i32 33554933, ; type_token_id
		i32 4; java_map_index
	}, 
	; 101
	%struct.TypeMapModuleEntry {
		i32 33554935, ; type_token_id
		i32 434; java_map_index
	}, 
	; 102
	%struct.TypeMapModuleEntry {
		i32 33554937, ; type_token_id
		i32 417; java_map_index
	}, 
	; 103
	%struct.TypeMapModuleEntry {
		i32 33554939, ; type_token_id
		i32 450; java_map_index
	}, 
	; 104
	%struct.TypeMapModuleEntry {
		i32 33554941, ; type_token_id
		i32 501; java_map_index
	}, 
	; 105
	%struct.TypeMapModuleEntry {
		i32 33554943, ; type_token_id
		i32 525; java_map_index
	}, 
	; 106
	%struct.TypeMapModuleEntry {
		i32 33554945, ; type_token_id
		i32 153; java_map_index
	}, 
	; 107
	%struct.TypeMapModuleEntry {
		i32 33554948, ; type_token_id
		i32 105; java_map_index
	}, 
	; 108
	%struct.TypeMapModuleEntry {
		i32 33554950, ; type_token_id
		i32 564; java_map_index
	}, 
	; 109
	%struct.TypeMapModuleEntry {
		i32 33554952, ; type_token_id
		i32 529; java_map_index
	}, 
	; 110
	%struct.TypeMapModuleEntry {
		i32 33554956, ; type_token_id
		i32 248; java_map_index
	}, 
	; 111
	%struct.TypeMapModuleEntry {
		i32 33554968, ; type_token_id
		i32 126; java_map_index
	}, 
	; 112
	%struct.TypeMapModuleEntry {
		i32 33554970, ; type_token_id
		i32 465; java_map_index
	}, 
	; 113
	%struct.TypeMapModuleEntry {
		i32 33554972, ; type_token_id
		i32 268; java_map_index
	}, 
	; 114
	%struct.TypeMapModuleEntry {
		i32 33554974, ; type_token_id
		i32 316; java_map_index
	}, 
	; 115
	%struct.TypeMapModuleEntry {
		i32 33554976, ; type_token_id
		i32 609; java_map_index
	}, 
	; 116
	%struct.TypeMapModuleEntry {
		i32 33554985, ; type_token_id
		i32 190; java_map_index
	}, 
	; 117
	%struct.TypeMapModuleEntry {
		i32 33554987, ; type_token_id
		i32 546; java_map_index
	}, 
	; 118
	%struct.TypeMapModuleEntry {
		i32 33554990, ; type_token_id
		i32 111; java_map_index
	}, 
	; 119
	%struct.TypeMapModuleEntry {
		i32 33555021, ; type_token_id
		i32 536; java_map_index
	}, 
	; 120
	%struct.TypeMapModuleEntry {
		i32 33555025, ; type_token_id
		i32 413; java_map_index
	}, 
	; 121
	%struct.TypeMapModuleEntry {
		i32 33555031, ; type_token_id
		i32 0; java_map_index
	}, 
	; 122
	%struct.TypeMapModuleEntry {
		i32 33555033, ; type_token_id
		i32 130; java_map_index
	}, 
	; 123
	%struct.TypeMapModuleEntry {
		i32 33555037, ; type_token_id
		i32 464; java_map_index
	}, 
	; 124
	%struct.TypeMapModuleEntry {
		i32 33555043, ; type_token_id
		i32 48; java_map_index
	}, 
	; 125
	%struct.TypeMapModuleEntry {
		i32 33555045, ; type_token_id
		i32 339; java_map_index
	}, 
	; 126
	%struct.TypeMapModuleEntry {
		i32 33555047, ; type_token_id
		i32 62; java_map_index
	}, 
	; 127
	%struct.TypeMapModuleEntry {
		i32 33555052, ; type_token_id
		i32 489; java_map_index
	}, 
	; 128
	%struct.TypeMapModuleEntry {
		i32 33555054, ; type_token_id
		i32 503; java_map_index
	}, 
	; 129
	%struct.TypeMapModuleEntry {
		i32 33555063, ; type_token_id
		i32 381; java_map_index
	}, 
	; 130
	%struct.TypeMapModuleEntry {
		i32 33555076, ; type_token_id
		i32 566; java_map_index
	}, 
	; 131
	%struct.TypeMapModuleEntry {
		i32 33555078, ; type_token_id
		i32 202; java_map_index
	}, 
	; 132
	%struct.TypeMapModuleEntry {
		i32 33555083, ; type_token_id
		i32 245; java_map_index
	}, 
	; 133
	%struct.TypeMapModuleEntry {
		i32 33555091, ; type_token_id
		i32 301; java_map_index
	}, 
	; 134
	%struct.TypeMapModuleEntry {
		i32 33555093, ; type_token_id
		i32 585; java_map_index
	}, 
	; 135
	%struct.TypeMapModuleEntry {
		i32 33555096, ; type_token_id
		i32 372; java_map_index
	}, 
	; 136
	%struct.TypeMapModuleEntry {
		i32 33555098, ; type_token_id
		i32 584; java_map_index
	}, 
	; 137
	%struct.TypeMapModuleEntry {
		i32 33555100, ; type_token_id
		i32 392; java_map_index
	}, 
	; 138
	%struct.TypeMapModuleEntry {
		i32 33555103, ; type_token_id
		i32 438; java_map_index
	}, 
	; 139
	%struct.TypeMapModuleEntry {
		i32 33555107, ; type_token_id
		i32 92; java_map_index
	}, 
	; 140
	%struct.TypeMapModuleEntry {
		i32 33555110, ; type_token_id
		i32 314; java_map_index
	}, 
	; 141
	%struct.TypeMapModuleEntry {
		i32 33555121, ; type_token_id
		i32 394; java_map_index
	}, 
	; 142
	%struct.TypeMapModuleEntry {
		i32 33555127, ; type_token_id
		i32 550; java_map_index
	}, 
	; 143
	%struct.TypeMapModuleEntry {
		i32 33555158, ; type_token_id
		i32 200; java_map_index
	}, 
	; 144
	%struct.TypeMapModuleEntry {
		i32 33555164, ; type_token_id
		i32 228; java_map_index
	}, 
	; 145
	%struct.TypeMapModuleEntry {
		i32 33555169, ; type_token_id
		i32 112; java_map_index
	}, 
	; 146
	%struct.TypeMapModuleEntry {
		i32 33555174, ; type_token_id
		i32 607; java_map_index
	}, 
	; 147
	%struct.TypeMapModuleEntry {
		i32 33555206, ; type_token_id
		i32 384; java_map_index
	}, 
	; 148
	%struct.TypeMapModuleEntry {
		i32 33555208, ; type_token_id
		i32 446; java_map_index
	}, 
	; 149
	%struct.TypeMapModuleEntry {
		i32 33555212, ; type_token_id
		i32 213; java_map_index
	}, 
	; 150
	%struct.TypeMapModuleEntry {
		i32 33555218, ; type_token_id
		i32 416; java_map_index
	}, 
	; 151
	%struct.TypeMapModuleEntry {
		i32 33555220, ; type_token_id
		i32 159; java_map_index
	}, 
	; 152
	%struct.TypeMapModuleEntry {
		i32 33555227, ; type_token_id
		i32 500; java_map_index
	}, 
	; 153
	%struct.TypeMapModuleEntry {
		i32 33555229, ; type_token_id
		i32 175; java_map_index
	}, 
	; 154
	%struct.TypeMapModuleEntry {
		i32 33555231, ; type_token_id
		i32 66; java_map_index
	}, 
	; 155
	%struct.TypeMapModuleEntry {
		i32 33555234, ; type_token_id
		i32 250; java_map_index
	}, 
	; 156
	%struct.TypeMapModuleEntry {
		i32 33555237, ; type_token_id
		i32 64; java_map_index
	}, 
	; 157
	%struct.TypeMapModuleEntry {
		i32 33555239, ; type_token_id
		i32 165; java_map_index
	}, 
	; 158
	%struct.TypeMapModuleEntry {
		i32 33555242, ; type_token_id
		i32 9; java_map_index
	}, 
	; 159
	%struct.TypeMapModuleEntry {
		i32 33555245, ; type_token_id
		i32 320; java_map_index
	}, 
	; 160
	%struct.TypeMapModuleEntry {
		i32 33555247, ; type_token_id
		i32 380; java_map_index
	}, 
	; 161
	%struct.TypeMapModuleEntry {
		i32 33555251, ; type_token_id
		i32 592; java_map_index
	}, 
	; 162
	%struct.TypeMapModuleEntry {
		i32 33555253, ; type_token_id
		i32 139; java_map_index
	}, 
	; 163
	%struct.TypeMapModuleEntry {
		i32 33555254, ; type_token_id
		i32 11; java_map_index
	}, 
	; 164
	%struct.TypeMapModuleEntry {
		i32 33555256, ; type_token_id
		i32 293; java_map_index
	}, 
	; 165
	%struct.TypeMapModuleEntry {
		i32 33555258, ; type_token_id
		i32 30; java_map_index
	}, 
	; 166
	%struct.TypeMapModuleEntry {
		i32 33555260, ; type_token_id
		i32 95; java_map_index
	}, 
	; 167
	%struct.TypeMapModuleEntry {
		i32 33555262, ; type_token_id
		i32 246; java_map_index
	}, 
	; 168
	%struct.TypeMapModuleEntry {
		i32 33555264, ; type_token_id
		i32 33; java_map_index
	}, 
	; 169
	%struct.TypeMapModuleEntry {
		i32 33555266, ; type_token_id
		i32 155; java_map_index
	}, 
	; 170
	%struct.TypeMapModuleEntry {
		i32 33555268, ; type_token_id
		i32 291; java_map_index
	}, 
	; 171
	%struct.TypeMapModuleEntry {
		i32 33555270, ; type_token_id
		i32 377; java_map_index
	}, 
	; 172
	%struct.TypeMapModuleEntry {
		i32 33555272, ; type_token_id
		i32 247; java_map_index
	}, 
	; 173
	%struct.TypeMapModuleEntry {
		i32 33555274, ; type_token_id
		i32 20; java_map_index
	}, 
	; 174
	%struct.TypeMapModuleEntry {
		i32 33555276, ; type_token_id
		i32 37; java_map_index
	}, 
	; 175
	%struct.TypeMapModuleEntry {
		i32 33555278, ; type_token_id
		i32 231; java_map_index
	}, 
	; 176
	%struct.TypeMapModuleEntry {
		i32 33555300, ; type_token_id
		i32 68; java_map_index
	}, 
	; 177
	%struct.TypeMapModuleEntry {
		i32 33555302, ; type_token_id
		i32 357; java_map_index
	}, 
	; 178
	%struct.TypeMapModuleEntry {
		i32 33555305, ; type_token_id
		i32 183; java_map_index
	}, 
	; 179
	%struct.TypeMapModuleEntry {
		i32 33555307, ; type_token_id
		i32 2; java_map_index
	}, 
	; 180
	%struct.TypeMapModuleEntry {
		i32 33555308, ; type_token_id
		i32 120; java_map_index
	}, 
	; 181
	%struct.TypeMapModuleEntry {
		i32 33555311, ; type_token_id
		i32 176; java_map_index
	}, 
	; 182
	%struct.TypeMapModuleEntry {
		i32 33555313, ; type_token_id
		i32 207; java_map_index
	}, 
	; 183
	%struct.TypeMapModuleEntry {
		i32 33555315, ; type_token_id
		i32 354; java_map_index
	}, 
	; 184
	%struct.TypeMapModuleEntry {
		i32 33555320, ; type_token_id
		i32 149; java_map_index
	}, 
	; 185
	%struct.TypeMapModuleEntry {
		i32 33555322, ; type_token_id
		i32 281; java_map_index
	}, 
	; 186
	%struct.TypeMapModuleEntry {
		i32 33555327, ; type_token_id
		i32 493; java_map_index
	}, 
	; 187
	%struct.TypeMapModuleEntry {
		i32 33555332, ; type_token_id
		i32 166; java_map_index
	}, 
	; 188
	%struct.TypeMapModuleEntry {
		i32 33555334, ; type_token_id
		i32 76; java_map_index
	}, 
	; 189
	%struct.TypeMapModuleEntry {
		i32 33555336, ; type_token_id
		i32 5; java_map_index
	}, 
	; 190
	%struct.TypeMapModuleEntry {
		i32 33555338, ; type_token_id
		i32 351; java_map_index
	}, 
	; 191
	%struct.TypeMapModuleEntry {
		i32 33555340, ; type_token_id
		i32 27; java_map_index
	}, 
	; 192
	%struct.TypeMapModuleEntry {
		i32 33555345, ; type_token_id
		i32 620; java_map_index
	}, 
	; 193
	%struct.TypeMapModuleEntry {
		i32 33555347, ; type_token_id
		i32 474; java_map_index
	}, 
	; 194
	%struct.TypeMapModuleEntry {
		i32 33555349, ; type_token_id
		i32 559; java_map_index
	}, 
	; 195
	%struct.TypeMapModuleEntry {
		i32 33555353, ; type_token_id
		i32 102; java_map_index
	}, 
	; 196
	%struct.TypeMapModuleEntry {
		i32 33555355, ; type_token_id
		i32 298; java_map_index
	}, 
	; 197
	%struct.TypeMapModuleEntry {
		i32 33555358, ; type_token_id
		i32 591; java_map_index
	}, 
	; 198
	%struct.TypeMapModuleEntry {
		i32 33555361, ; type_token_id
		i32 594; java_map_index
	}
], align 4; end of 'module7_managed_to_java_duplicates' array


; module8_managed_to_java
@module8_managed_to_java = internal constant [12 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 272; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554435, ; type_token_id
		i32 171; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 142; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554437, ; type_token_id
		i32 230; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 325; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 144; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554443, ; type_token_id
		i32 14; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554444, ; type_token_id
		i32 288; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 355; java_map_index
	}, 
	; 9
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 444; java_map_index
	}, 
	; 10
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 331; java_map_index
	}, 
	; 11
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 260; java_map_index
	}
], align 4; end of 'module8_managed_to_java' array


; module8_managed_to_java_duplicates
@module8_managed_to_java_duplicates = internal constant [5 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 144; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554447, ; type_token_id
		i32 230; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554449, ; type_token_id
		i32 355; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554451, ; type_token_id
		i32 444; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554455, ; type_token_id
		i32 331; java_map_index
	}
], align 4; end of 'module8_managed_to_java_duplicates' array


; module9_managed_to_java
@module9_managed_to_java = internal constant [9 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 100; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 180; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554440, ; type_token_id
		i32 285; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 138; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554448, ; type_token_id
		i32 541; java_map_index
	}, 
	; 5
	%struct.TypeMapModuleEntry {
		i32 33554450, ; type_token_id
		i32 143; java_map_index
	}, 
	; 6
	%struct.TypeMapModuleEntry {
		i32 33554452, ; type_token_id
		i32 249; java_map_index
	}, 
	; 7
	%struct.TypeMapModuleEntry {
		i32 33554454, ; type_token_id
		i32 232; java_map_index
	}, 
	; 8
	%struct.TypeMapModuleEntry {
		i32 33554456, ; type_token_id
		i32 225; java_map_index
	}
], align 4; end of 'module9_managed_to_java' array


; module10_managed_to_java
@module10_managed_to_java = internal constant [5 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 188; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 484; java_map_index
	}, 
	; 2
	%struct.TypeMapModuleEntry {
		i32 33554438, ; type_token_id
		i32 531; java_map_index
	}, 
	; 3
	%struct.TypeMapModuleEntry {
		i32 33554439, ; type_token_id
		i32 81; java_map_index
	}, 
	; 4
	%struct.TypeMapModuleEntry {
		i32 33554441, ; type_token_id
		i32 504; java_map_index
	}
], align 4; end of 'module10_managed_to_java' array


; module11_managed_to_java
@module11_managed_to_java = internal constant [2 x %struct.TypeMapModuleEntry] [
	; 0
	%struct.TypeMapModuleEntry {
		i32 33554434, ; type_token_id
		i32 25; java_map_index
	}, 
	; 1
	%struct.TypeMapModuleEntry {
		i32 33554436, ; type_token_id
		i32 373; java_map_index
	}
], align 4; end of 'module11_managed_to_java' array

; Map modules
@__TypeMapModule_assembly_name.0 = internal constant [31 x i8] c"Xamarin.Forms.Platform.Android\00", align 1
@__TypeMapModule_assembly_name.1 = internal constant [31 x i8] c"Xamarin.Android.Support.Compat\00", align 1
@__TypeMapModule_assembly_name.2 = internal constant [38 x i8] c"Xamarin.Android.Arch.Lifecycle.Common\00", align 1
@__TypeMapModule_assembly_name.3 = internal constant [32 x i8] c"Xamarin.Android.Support.Core.UI\00", align 1
@__TypeMapModule_assembly_name.4 = internal constant [36 x i8] c"Xamarin.Android.Support.v7.CardView\00", align 1
@__TypeMapModule_assembly_name.5 = internal constant [37 x i8] c"Xamarin.Android.Support.v7.AppCompat\00", align 1
@__TypeMapModule_assembly_name.6 = internal constant [28 x i8] c"ThreePointCheck_App.Android\00", align 1
@__TypeMapModule_assembly_name.7 = internal constant [13 x i8] c"Mono.Android\00", align 1
@__TypeMapModule_assembly_name.8 = internal constant [33 x i8] c"Xamarin.Android.Support.Fragment\00", align 1
@__TypeMapModule_assembly_name.9 = internal constant [31 x i8] c"Xamarin.Android.Support.Design\00", align 1
@__TypeMapModule_assembly_name.10 = internal constant [35 x i8] c"Xamarin.Android.Support.Core.Utils\00", align 1
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
], align 4; end of 'map_modules' array


; Java to managed map

; map_java
@map_java = local_unnamed_addr constant [624 x %struct.TypeMapJava] [
	; 0
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 430; java_name_index
	}, 
	; 1
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555290, ; type_token_id
		i32 548; java_name_index
	}, 
	; 2
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 560; java_name_index
	}, 
	; 3
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554634, ; type_token_id
		i32 12; java_name_index
	}, 
	; 4
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 367; java_name_index
	}, 
	; 5
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 578; java_name_index
	}, 
	; 6
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554645, ; type_token_id
		i32 24; java_name_index
	}, 
	; 7
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554470, ; type_token_id
		i32 186; java_name_index
	}, 
	; 8
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 252; java_name_index
	}, 
	; 9
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555241, ; type_token_id
		i32 518; java_name_index
	}, 
	; 10
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555119, ; type_token_id
		i32 473; java_name_index
	}, 
	; 11
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555249, ; type_token_id
		i32 523; java_name_index
	}, 
	; 12
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554858, ; type_token_id
		i32 330; java_name_index
	}, 
	; 13
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554522, ; type_token_id
		i32 40; java_name_index
	}, 
	; 14
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554443, ; type_token_id
		i32 602; java_name_index
	}, 
	; 15
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555064, ; type_token_id
		i32 448; java_name_index
	}, 
	; 16
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554466, ; type_token_id
		i32 11; java_name_index
	}, 
	; 17
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554889, ; type_token_id
		i32 344; java_name_index
	}, 
	; 18
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554595, ; type_token_id
		i32 93; java_name_index
	}, 
	; 19
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554561, ; type_token_id
		i32 71; java_name_index
	}, 
	; 20
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 534; java_name_index
	}, 
	; 21
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554475, ; type_token_id
		i32 189; java_name_index
	}, 
	; 22
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 209; java_name_index
	}, 
	; 23
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554762, ; type_token_id
		i32 286; java_name_index
	}, 
	; 24
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 349; java_name_index
	}, 
	; 25
	%struct.TypeMapJava {
		i32 11, ; module_index
		i32 33554434, ; type_token_id
		i32 622; java_name_index
	}, 
	; 26
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554465, ; type_token_id
		i32 182; java_name_index
	}, 
	; 27
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 580; java_name_index
	}, 
	; 28
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555203, ; type_token_id
		i32 492; java_name_index
	}, 
	; 29
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554466, ; type_token_id
		i32 183; java_name_index
	}, 
	; 30
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555257, ; type_token_id
		i32 526; java_name_index
	}, 
	; 31
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555316, ; type_token_id
		i32 564; java_name_index
	}, 
	; 32
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 216; java_name_index
	}, 
	; 33
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 529; java_name_index
	}, 
	; 34
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554992, ; type_token_id
		i32 404; java_name_index
	}, 
	; 35
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554562, ; type_token_id
		i32 72; java_name_index
	}, 
	; 36
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554482, ; type_token_id
		i32 191; java_name_index
	}, 
	; 37
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 535; java_name_index
	}, 
	; 38
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554716, ; type_token_id
		i32 261; java_name_index
	}, 
	; 39
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554671, ; type_token_id
		i32 234; java_name_index
	}, 
	; 40
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555328, ; type_token_id
		i32 573; java_name_index
	}, 
	; 41
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 343; java_name_index
	}, 
	; 42
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554674, ; type_token_id
		i32 62; java_name_index
	}, 
	; 43
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554604, ; type_token_id
		i32 203; java_name_index
	}, 
	; 44
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 333; java_name_index
	}, 
	; 45
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554697, ; type_token_id
		i32 248; java_name_index
	}, 
	; 46
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 311; java_name_index
	}, 
	; 47
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554711, ; type_token_id
		i32 108; java_name_index
	}, 
	; 48
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555029, ; type_token_id
		i32 429; java_name_index
	}, 
	; 49
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554446, ; type_token_id
		i32 170; java_name_index
	}, 
	; 50
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554589, ; type_token_id
		i32 92; java_name_index
	}, 
	; 51
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554469, ; type_token_id
		i32 134; java_name_index
	}, 
	; 52
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554579, ; type_token_id
		i32 87; java_name_index
	}, 
	; 53
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554929, ; type_token_id
		i32 365; java_name_index
	}, 
	; 54
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555224, ; type_token_id
		i32 507; java_name_index
	}, 
	; 55
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554441, ; type_token_id
		i32 167; java_name_index
	}, 
	; 56
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554597, ; type_token_id
		i32 94; java_name_index
	}, 
	; 57
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554859, ; type_token_id
		i32 331; java_name_index
	}, 
	; 58
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554552, ; type_token_id
		i32 59; java_name_index
	}, 
	; 59
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554464, ; type_token_id
		i32 181; java_name_index
	}, 
	; 60
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554524, ; type_token_id
		i32 41; java_name_index
	}, 
	; 61
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555296, ; type_token_id
		i32 553; java_name_index
	}, 
	; 62
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 437; java_name_index
	}, 
	; 63
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554613, ; type_token_id
		i32 112; java_name_index
	}, 
	; 64
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 515; java_name_index
	}, 
	; 65
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555289, ; type_token_id
		i32 547; java_name_index
	}, 
	; 66
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 511; java_name_index
	}, 
	; 67
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555209, ; type_token_id
		i32 496; java_name_index
	}, 
	; 68
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555299, ; type_token_id
		i32 556; java_name_index
	}, 
	; 69
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555202, ; type_token_id
		i32 491; java_name_index
	}, 
	; 70
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554954, ; type_token_id
		i32 379; java_name_index
	}, 
	; 71
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554533, ; type_token_id
		i32 43; java_name_index
	}, 
	; 72
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555323, ; type_token_id
		i32 569; java_name_index
	}, 
	; 73
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554707, ; type_token_id
		i32 103; java_name_index
	}, 
	; 74
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 293; java_name_index
	}, 
	; 75
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554615, ; type_token_id
		i32 115; java_name_index
	}, 
	; 76
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 577; java_name_index
	}, 
	; 77
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554568, ; type_token_id
		i32 79; java_name_index
	}, 
	; 78
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554569, ; type_token_id
		i32 80; java_name_index
	}, 
	; 79
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554860, ; type_token_id
		i32 332; java_name_index
	}, 
	; 80
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 289; java_name_index
	}, 
	; 81
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554439, ; type_token_id
		i32 620; java_name_index
	}, 
	; 82
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 320; java_name_index
	}, 
	; 83
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554978, ; type_token_id
		i32 395; java_name_index
	}, 
	; 84
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554563, ; type_token_id
		i32 73; java_name_index
	}, 
	; 85
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554437, ; type_token_id
		i32 144; java_name_index
	}, 
	; 86
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555189, ; type_token_id
		i32 490; java_name_index
	}, 
	; 87
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554685, ; type_token_id
		i32 84; java_name_index
	}, 
	; 88
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554710, ; type_token_id
		i32 107; java_name_index
	}, 
	; 89
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554555, ; type_token_id
		i32 63; java_name_index
	}, 
	; 90
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555024, ; type_token_id
		i32 426; java_name_index
	}, 
	; 91
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554542, ; type_token_id
		i32 49; java_name_index
	}, 
	; 92
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 466; java_name_index
	}, 
	; 93
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 256; java_name_index
	}, 
	; 94
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554606, ; type_token_id
		i32 100; java_name_index
	}, 
	; 95
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555259, ; type_token_id
		i32 527; java_name_index
	}, 
	; 96
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554692, ; type_token_id
		i32 245; java_name_index
	}, 
	; 97
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555317, ; type_token_id
		i32 565; java_name_index
	}, 
	; 98
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554771, ; type_token_id
		i32 292; java_name_index
	}, 
	; 99
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554965, ; type_token_id
		i32 387; java_name_index
	}, 
	; 100
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554434, ; type_token_id
		i32 608; java_name_index
	}, 
	; 101
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554566, ; type_token_id
		i32 77; java_name_index
	}, 
	; 102
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 589; java_name_index
	}, 
	; 103
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554510, ; type_token_id
		i32 35; java_name_index
	}, 
	; 104
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555225, ; type_token_id
		i32 508; java_name_index
	}, 
	; 105
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 375; java_name_index
	}, 
	; 106
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555074, ; type_token_id
		i32 450; java_name_index
	}, 
	; 107
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 306; java_name_index
	}, 
	; 108
	%struct.TypeMapJava {
		i32 6, ; module_index
		i32 33554434, ; type_token_id
		i32 197; java_name_index
	}, 
	; 109
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554470, ; type_token_id
		i32 135; java_name_index
	}, 
	; 110
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554509, ; type_token_id
		i32 34; java_name_index
	}, 
	; 111
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 402; java_name_index
	}, 
	; 112
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555168, ; type_token_id
		i32 486; java_name_index
	}, 
	; 113
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554521, ; type_token_id
		i32 39; java_name_index
	}, 
	; 114
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554536, ; type_token_id
		i32 44; java_name_index
	}, 
	; 115
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554496, ; type_token_id
		i32 21; java_name_index
	}, 
	; 116
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554719, ; type_token_id
		i32 263; java_name_index
	}, 
	; 117
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554684, ; type_token_id
		i32 82; java_name_index
	}, 
	; 118
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554651, ; type_token_id
		i32 32; java_name_index
	}, 
	; 119
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554450, ; type_token_id
		i32 173; java_name_index
	}, 
	; 120
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 545; java_name_index
	}, 
	; 121
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555356, ; type_token_id
		i32 591; java_name_index
	}, 
	; 122
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 235; java_name_index
	}, 
	; 123
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554690, ; type_token_id
		i32 88; java_name_index
	}, 
	; 124
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555288, ; type_token_id
		i32 546; java_name_index
	}, 
	; 125
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554491, ; type_token_id
		i32 196; java_name_index
	}, 
	; 126
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 389; java_name_index
	}, 
	; 127
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555295, ; type_token_id
		i32 552; java_name_index
	}, 
	; 128
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555204, ; type_token_id
		i32 493; java_name_index
	}, 
	; 129
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555325, ; type_token_id
		i32 571; java_name_index
	}, 
	; 130
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 431; java_name_index
	}, 
	; 131
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554451, ; type_token_id
		i32 174; java_name_index
	}, 
	; 132
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554611, ; type_token_id
		i32 110; java_name_index
	}, 
	; 133
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554443, ; type_token_id
		i32 151; java_name_index
	}, 
	; 134
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555124, ; type_token_id
		i32 476; java_name_index
	}, 
	; 135
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554995, ; type_token_id
		i32 406; java_name_index
	}, 
	; 136
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 210; java_name_index
	}, 
	; 137
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555292, ; type_token_id
		i32 550; java_name_index
	}, 
	; 138
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554441, ; type_token_id
		i32 611; java_name_index
	}, 
	; 139
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555252, ; type_token_id
		i32 524; java_name_index
	}, 
	; 140
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554999, ; type_token_id
		i32 408; java_name_index
	}, 
	; 141
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554630, ; type_token_id
		i32 8; java_name_index
	}, 
	; 142
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554436, ; type_token_id
		i32 598; java_name_index
	}, 
	; 143
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554450, ; type_token_id
		i32 613; java_name_index
	}, 
	; 144
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554440, ; type_token_id
		i32 601; java_name_index
	}, 
	; 145
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554488, ; type_token_id
		i32 195; java_name_index
	}, 
	; 146
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554926, ; type_token_id
		i32 362; java_name_index
	}, 
	; 147
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554925, ; type_token_id
		i32 361; java_name_index
	}, 
	; 148
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 279; java_name_index
	}, 
	; 149
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 567; java_name_index
	}, 
	; 150
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554698, ; type_token_id
		i32 249; java_name_index
	}, 
	; 151
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554463, ; type_token_id
		i32 130; java_name_index
	}, 
	; 152
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 287; java_name_index
	}, 
	; 153
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554944, ; type_token_id
		i32 373; java_name_index
	}, 
	; 154
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555342, ; type_token_id
		i32 582; java_name_index
	}, 
	; 155
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 530; java_name_index
	}, 
	; 156
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554463, ; type_token_id
		i32 180; java_name_index
	}, 
	; 157
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554551, ; type_token_id
		i32 58; java_name_index
	}, 
	; 158
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554691, ; type_token_id
		i32 244; java_name_index
	}, 
	; 159
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555219, ; type_token_id
		i32 503; java_name_index
	}, 
	; 160
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554657, ; type_token_id
		i32 227; java_name_index
	}, 
	; 161
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555129, ; type_token_id
		i32 479; java_name_index
	}, 
	; 162
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554900, ; type_token_id
		i32 350; java_name_index
	}, 
	; 163
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 305; java_name_index
	}, 
	; 164
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554677, ; type_token_id
		i32 238; java_name_index
	}, 
	; 165
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 516; java_name_index
	}, 
	; 166
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 576; java_name_index
	}, 
	; 167
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555039, ; type_token_id
		i32 435; java_name_index
	}, 
	; 168
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554622, ; type_token_id
		i32 212; java_name_index
	}, 
	; 169
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554519, ; type_token_id
		i32 38; java_name_index
	}, 
	; 170
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 237; java_name_index
	}, 
	; 171
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554435, ; type_token_id
		i32 597; java_name_index
	}, 
	; 172
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 231; java_name_index
	}, 
	; 173
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 296; java_name_index
	}, 
	; 174
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554567, ; type_token_id
		i32 78; java_name_index
	}, 
	; 175
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 510; java_name_index
	}, 
	; 176
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 561; java_name_index
	}, 
	; 177
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 217; java_name_index
	}, 
	; 178
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554486, ; type_token_id
		i32 19; java_name_index
	}, 
	; 179
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555283, ; type_token_id
		i32 541; java_name_index
	}, 
	; 180
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554436, ; type_token_id
		i32 609; java_name_index
	}, 
	; 181
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554443, ; type_token_id
		i32 168; java_name_index
	}, 
	; 182
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 315; java_name_index
	}, 
	; 183
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 559; java_name_index
	}, 
	; 184
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554434, ; type_token_id
		i32 146; java_name_index
	}, 
	; 185
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555035, ; type_token_id
		i32 433; java_name_index
	}, 
	; 186
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555060, ; type_token_id
		i32 446; java_name_index
	}, 
	; 187
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554602, ; type_token_id
		i32 202; java_name_index
	}, 
	; 188
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554434, ; type_token_id
		i32 617; java_name_index
	}, 
	; 189
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554468, ; type_token_id
		i32 159; java_name_index
	}, 
	; 190
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554960, ; type_token_id
		i32 383; java_name_index
	}, 
	; 191
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 298; java_name_index
	}, 
	; 192
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555222, ; type_token_id
		i32 505; java_name_index
	}, 
	; 193
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 269; java_name_index
	}, 
	; 194
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 307; java_name_index
	}, 
	; 195
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554650, ; type_token_id
		i32 31; java_name_index
	}, 
	; 196
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555297, ; type_token_id
		i32 554; java_name_index
	}, 
	; 197
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554454, ; type_token_id
		i32 4; java_name_index
	}, 
	; 198
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554481, ; type_token_id
		i32 17; java_name_index
	}, 
	; 199
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554623, ; type_token_id
		i32 213; java_name_index
	}, 
	; 200
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555157, ; type_token_id
		i32 484; java_name_index
	}, 
	; 201
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555006, ; type_token_id
		i32 411; java_name_index
	}, 
	; 202
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555049, ; type_token_id
		i32 438; java_name_index
	}, 
	; 203
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555298, ; type_token_id
		i32 555; java_name_index
	}, 
	; 204
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555014, ; type_token_id
		i32 418; java_name_index
	}, 
	; 205
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 207; java_name_index
	}, 
	; 206
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555092, ; type_token_id
		i32 458; java_name_index
	}, 
	; 207
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 562; java_name_index
	}, 
	; 208
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554461, ; type_token_id
		i32 7; java_name_index
	}, 
	; 209
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554466, ; type_token_id
		i32 132; java_name_index
	}, 
	; 210
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554701, ; type_token_id
		i32 101; java_name_index
	}, 
	; 211
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555114, ; type_token_id
		i32 471; java_name_index
	}, 
	; 212
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555329, ; type_token_id
		i32 574; java_name_index
	}, 
	; 213
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555211, ; type_token_id
		i32 497; java_name_index
	}, 
	; 214
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555016, ; type_token_id
		i32 420; java_name_index
	}, 
	; 215
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 319; java_name_index
	}, 
	; 216
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 276; java_name_index
	}, 
	; 217
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554474, ; type_token_id
		i32 188; java_name_index
	}, 
	; 218
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554714, ; type_token_id
		i32 259; java_name_index
	}, 
	; 219
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554869, ; type_token_id
		i32 335; java_name_index
	}, 
	; 220
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554447, ; type_token_id
		i32 152; java_name_index
	}, 
	; 221
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555101, ; type_token_id
		i32 463; java_name_index
	}, 
	; 222
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554922, ; type_token_id
		i32 360; java_name_index
	}, 
	; 223
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554718, ; type_token_id
		i32 262; java_name_index
	}, 
	; 224
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554457, ; type_token_id
		i32 177; java_name_index
	}, 
	; 225
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554456, ; type_token_id
		i32 616; java_name_index
	}, 
	; 226
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554441, ; type_token_id
		i32 121; java_name_index
	}, 
	; 227
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554583, ; type_token_id
		i32 89; java_name_index
	}, 
	; 228
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555159, ; type_token_id
		i32 485; java_name_index
	}, 
	; 229
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554541, ; type_token_id
		i32 48; java_name_index
	}, 
	; 230
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554437, ; type_token_id
		i32 599; java_name_index
	}, 
	; 231
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555277, ; type_token_id
		i32 536; java_name_index
	}, 
	; 232
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554454, ; type_token_id
		i32 615; java_name_index
	}, 
	; 233
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554685, ; type_token_id
		i32 241; java_name_index
	}, 
	; 234
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554554, ; type_token_id
		i32 61; java_name_index
	}, 
	; 235
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555341, ; type_token_id
		i32 581; java_name_index
	}, 
	; 236
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554486, ; type_token_id
		i32 193; java_name_index
	}, 
	; 237
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554831, ; type_token_id
		i32 321; java_name_index
	}, 
	; 238
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554473, ; type_token_id
		i32 137; java_name_index
	}, 
	; 239
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555057, ; type_token_id
		i32 443; java_name_index
	}, 
	; 240
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554560, ; type_token_id
		i32 70; java_name_index
	}, 
	; 241
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554458, ; type_token_id
		i32 6; java_name_index
	}, 
	; 242
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554460, ; type_token_id
		i32 178; java_name_index
	}, 
	; 243
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554792, ; type_token_id
		i32 303; java_name_index
	}, 
	; 244
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554958, ; type_token_id
		i32 381; java_name_index
	}, 
	; 245
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555082, ; type_token_id
		i32 453; java_name_index
	}, 
	; 246
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 528; java_name_index
	}, 
	; 247
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 533; java_name_index
	}, 
	; 248
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 380; java_name_index
	}, 
	; 249
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554452, ; type_token_id
		i32 614; java_name_index
	}, 
	; 250
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 513; java_name_index
	}, 
	; 251
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554982, ; type_token_id
		i32 398; java_name_index
	}, 
	; 252
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555005, ; type_token_id
		i32 410; java_name_index
	}, 
	; 253
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554734, ; type_token_id
		i32 274; java_name_index
	}, 
	; 254
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555291, ; type_token_id
		i32 549; java_name_index
	}, 
	; 255
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554477, ; type_token_id
		i32 139; java_name_index
	}, 
	; 256
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555318, ; type_token_id
		i32 566; java_name_index
	}, 
	; 257
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554500, ; type_token_id
		i32 26; java_name_index
	}, 
	; 258
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554610, ; type_token_id
		i32 106; java_name_index
	}, 
	; 259
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 285; java_name_index
	}, 
	; 260
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554454, ; type_token_id
		i32 607; java_name_index
	}, 
	; 261
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555280, ; type_token_id
		i32 538; java_name_index
	}, 
	; 262
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554570, ; type_token_id
		i32 81; java_name_index
	}, 
	; 263
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554687, ; type_token_id
		i32 242; java_name_index
	}, 
	; 264
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554447, ; type_token_id
		i32 124; java_name_index
	}, 
	; 265
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555281, ; type_token_id
		i32 539; java_name_index
	}, 
	; 266
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554840, ; type_token_id
		i32 323; java_name_index
	}, 
	; 267
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554696, ; type_token_id
		i32 247; java_name_index
	}, 
	; 268
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 391; java_name_index
	}, 
	; 269
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555232, ; type_token_id
		i32 512; java_name_index
	}, 
	; 270
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554916, ; type_token_id
		i32 357; java_name_index
	}, 
	; 271
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554961, ; type_token_id
		i32 384; java_name_index
	}, 
	; 272
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554434, ; type_token_id
		i32 596; java_name_index
	}, 
	; 273
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555012, ; type_token_id
		i32 416; java_name_index
	}, 
	; 274
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555125, ; type_token_id
		i32 477; java_name_index
	}, 
	; 275
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554678, ; type_token_id
		i32 239; java_name_index
	}, 
	; 276
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 355; java_name_index
	}, 
	; 277
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 277; java_name_index
	}, 
	; 278
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554456, ; type_token_id
		i32 5; java_name_index
	}, 
	; 279
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555243, ; type_token_id
		i32 519; java_name_index
	}, 
	; 280
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554441, ; type_token_id
		i32 150; java_name_index
	}, 
	; 281
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 568; java_name_index
	}, 
	; 282
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554713, ; type_token_id
		i32 258; java_name_index
	}, 
	; 283
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554729, ; type_token_id
		i32 15; java_name_index
	}, 
	; 284
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554850, ; type_token_id
		i32 327; java_name_index
	}, 
	; 285
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554440, ; type_token_id
		i32 610; java_name_index
	}, 
	; 286
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554631, ; type_token_id
		i32 218; java_name_index
	}, 
	; 287
	%struct.TypeMapJava {
		i32 4, ; module_index
		i32 33554434, ; type_token_id
		i32 162; java_name_index
	}, 
	; 288
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554444, ; type_token_id
		i32 603; java_name_index
	}, 
	; 289
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 85; java_name_index
	}, 
	; 290
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554959, ; type_token_id
		i32 382; java_name_index
	}, 
	; 291
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 531; java_name_index
	}, 
	; 292
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554720, ; type_token_id
		i32 264; java_name_index
	}, 
	; 293
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555255, ; type_token_id
		i32 525; java_name_index
	}, 
	; 294
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554712, ; type_token_id
		i32 109; java_name_index
	}, 
	; 295
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554931, ; type_token_id
		i32 366; java_name_index
	}, 
	; 296
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554482, ; type_token_id
		i32 18; java_name_index
	}, 
	; 297
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 232; java_name_index
	}, 
	; 298
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555354, ; type_token_id
		i32 590; java_name_index
	}, 
	; 299
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 353; java_name_index
	}, 
	; 300
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555108, ; type_token_id
		i32 467; java_name_index
	}, 
	; 301
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555090, ; type_token_id
		i32 457; java_name_index
	}, 
	; 302
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554525, ; type_token_id
		i32 42; java_name_index
	}, 
	; 303
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554436, ; type_token_id
		i32 165; java_name_index
	}, 
	; 304
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554464, ; type_token_id
		i32 131; java_name_index
	}, 
	; 305
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555056, ; type_token_id
		i32 442; java_name_index
	}, 
	; 306
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555279, ; type_token_id
		i32 537; java_name_index
	}, 
	; 307
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 230; java_name_index
	}, 
	; 308
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555026, ; type_token_id
		i32 427; java_name_index
	}, 
	; 309
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555088, ; type_token_id
		i32 456; java_name_index
	}, 
	; 310
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554882, ; type_token_id
		i32 342; java_name_index
	}, 
	; 311
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554790, ; type_token_id
		i32 302; java_name_index
	}, 
	; 312
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554666, ; type_token_id
		i32 53; java_name_index
	}, 
	; 313
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554662, ; type_token_id
		i32 229; java_name_index
	}, 
	; 314
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 468; java_name_index
	}, 
	; 315
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554729, ; type_token_id
		i32 271; java_name_index
	}, 
	; 316
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 392; java_name_index
	}, 
	; 317
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554649, ; type_token_id
		i32 222; java_name_index
	}, 
	; 318
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554571, ; type_token_id
		i32 83; java_name_index
	}, 
	; 319
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554458, ; type_token_id
		i32 127; java_name_index
	}, 
	; 320
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 520; java_name_index
	}, 
	; 321
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554870, ; type_token_id
		i32 336; java_name_index
	}, 
	; 322
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 257; java_name_index
	}, 
	; 323
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555058, ; type_token_id
		i32 444; java_name_index
	}, 
	; 324
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 45; java_name_index
	}, 
	; 325
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554439, ; type_token_id
		i32 600; java_name_index
	}, 
	; 326
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555112, ; type_token_id
		i32 470; java_name_index
	}, 
	; 327
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555240, ; type_token_id
		i32 517; java_name_index
	}, 
	; 328
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554966, ; type_token_id
		i32 388; java_name_index
	}, 
	; 329
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554559, ; type_token_id
		i32 69; java_name_index
	}, 
	; 330
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554679, ; type_token_id
		i32 240; java_name_index
	}, 
	; 331
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554452, ; type_token_id
		i32 606; java_name_index
	}, 
	; 332
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555010, ; type_token_id
		i32 414; java_name_index
	}, 
	; 333
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554677, ; type_token_id
		i32 66; java_name_index
	}, 
	; 334
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554546, ; type_token_id
		i32 54; java_name_index
	}, 
	; 335
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555126, ; type_token_id
		i32 478; java_name_index
	}, 
	; 336
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554437, ; type_token_id
		i32 148; java_name_index
	}, 
	; 337
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554443, ; type_token_id
		i32 122; java_name_index
	}, 
	; 338
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554549, ; type_token_id
		i32 56; java_name_index
	}, 
	; 339
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555044, ; type_token_id
		i32 436; java_name_index
	}, 
	; 340
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554438, ; type_token_id
		i32 119; java_name_index
	}, 
	; 341
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 116; java_name_index
	}, 
	; 342
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555023, ; type_token_id
		i32 425; java_name_index
	}, 
	; 343
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 114; java_name_index
	}, 
	; 344
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 200; java_name_index
	}, 
	; 345
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554622, ; type_token_id
		i32 0; java_name_index
	}, 
	; 346
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554708, ; type_token_id
		i32 104; java_name_index
	}, 
	; 347
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555223, ; type_token_id
		i32 506; java_name_index
	}, 
	; 348
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555216, ; type_token_id
		i32 501; java_name_index
	}, 
	; 349
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555059, ; type_token_id
		i32 445; java_name_index
	}, 
	; 350
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555111, ; type_token_id
		i32 469; java_name_index
	}, 
	; 351
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 579; java_name_index
	}, 
	; 352
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554585, ; type_token_id
		i32 91; java_name_index
	}, 
	; 353
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554439, ; type_token_id
		i32 149; java_name_index
	}, 
	; 354
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 563; java_name_index
	}, 
	; 355
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554448, ; type_token_id
		i32 604; java_name_index
	}, 
	; 356
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554434, ; type_token_id
		i32 163; java_name_index
	}, 
	; 357
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555301, ; type_token_id
		i32 557; java_name_index
	}, 
	; 358
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554649, ; type_token_id
		i32 30; java_name_index
	}, 
	; 359
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554722, ; type_token_id
		i32 266; java_name_index
	}, 
	; 360
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554728, ; type_token_id
		i32 270; java_name_index
	}, 
	; 361
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 283; java_name_index
	}, 
	; 362
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555084, ; type_token_id
		i32 454; java_name_index
	}, 
	; 363
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554893, ; type_token_id
		i32 347; java_name_index
	}, 
	; 364
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554508, ; type_token_id
		i32 33; java_name_index
	}, 
	; 365
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554475, ; type_token_id
		i32 138; java_name_index
	}, 
	; 366
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555330, ; type_token_id
		i32 575; java_name_index
	}, 
	; 367
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555130, ; type_token_id
		i32 480; java_name_index
	}, 
	; 368
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554565, ; type_token_id
		i32 75; java_name_index
	}, 
	; 369
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555221, ; type_token_id
		i32 504; java_name_index
	}, 
	; 370
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554980, ; type_token_id
		i32 396; java_name_index
	}, 
	; 371
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554600, ; type_token_id
		i32 201; java_name_index
	}, 
	; 372
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 460; java_name_index
	}, 
	; 373
	%struct.TypeMapJava {
		i32 11, ; module_index
		i32 33554436, ; type_token_id
		i32 623; java_name_index
	}, 
	; 374
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554718, ; type_token_id
		i32 113; java_name_index
	}, 
	; 375
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554653, ; type_token_id
		i32 224; java_name_index
	}, 
	; 376
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 272; java_name_index
	}, 
	; 377
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 532; java_name_index
	}, 
	; 378
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 308; java_name_index
	}, 
	; 379
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555343, ; type_token_id
		i32 583; java_name_index
	}, 
	; 380
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555246, ; type_token_id
		i32 521; java_name_index
	}, 
	; 381
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 447; java_name_index
	}, 
	; 382
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554707, ; type_token_id
		i32 255; java_name_index
	}, 
	; 383
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555034, ; type_token_id
		i32 432; java_name_index
	}, 
	; 384
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555205, ; type_token_id
		i32 494; java_name_index
	}, 
	; 385
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554448, ; type_token_id
		i32 171; java_name_index
	}, 
	; 386
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 233; java_name_index
	}, 
	; 387
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 267; java_name_index
	}, 
	; 388
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554452, ; type_token_id
		i32 2; java_name_index
	}, 
	; 389
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554468, ; type_token_id
		i32 133; java_name_index
	}, 
	; 390
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554456, ; type_token_id
		i32 126; java_name_index
	}, 
	; 391
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554636, ; type_token_id
		i32 13; java_name_index
	}, 
	; 392
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 462; java_name_index
	}, 
	; 393
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 246; java_name_index
	}, 
	; 394
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555120, ; type_token_id
		i32 474; java_name_index
	}, 
	; 395
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554624, ; type_token_id
		i32 1; java_name_index
	}, 
	; 396
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554547, ; type_token_id
		i32 55; java_name_index
	}, 
	; 397
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555350, ; type_token_id
		i32 587; java_name_index
	}, 
	; 398
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554705, ; type_token_id
		i32 253; java_name_index
	}, 
	; 399
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554504, ; type_token_id
		i32 28; java_name_index
	}, 
	; 400
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 206; java_name_index
	}, 
	; 401
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554479, ; type_token_id
		i32 16; java_name_index
	}, 
	; 402
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554656, ; type_token_id
		i32 226; java_name_index
	}, 
	; 403
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554498, ; type_token_id
		i32 22; java_name_index
	}, 
	; 404
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 250; java_name_index
	}, 
	; 405
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554770, ; type_token_id
		i32 291; java_name_index
	}, 
	; 406
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554689, ; type_token_id
		i32 86; java_name_index
	}, 
	; 407
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554458, ; type_token_id
		i32 154; java_name_index
	}, 
	; 408
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554674, ; type_token_id
		i32 236; java_name_index
	}, 
	; 409
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 281; java_name_index
	}, 
	; 410
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 220; java_name_index
	}, 
	; 411
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 251; java_name_index
	}, 
	; 412
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554499, ; type_token_id
		i32 23; java_name_index
	}, 
	; 413
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555019, ; type_token_id
		i32 422; java_name_index
	}, 
	; 414
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554462, ; type_token_id
		i32 156; java_name_index
	}, 
	; 415
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554735, ; type_token_id
		i32 275; java_name_index
	}, 
	; 416
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555217, ; type_token_id
		i32 502; java_name_index
	}, 
	; 417
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 369; java_name_index
	}, 
	; 418
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 354; java_name_index
	}, 
	; 419
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555286, ; type_token_id
		i32 544; java_name_index
	}, 
	; 420
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555022, ; type_token_id
		i32 424; java_name_index
	}, 
	; 421
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554953, ; type_token_id
		i32 378; java_name_index
	}, 
	; 422
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554962, ; type_token_id
		i32 385; java_name_index
	}, 
	; 423
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554449, ; type_token_id
		i32 172; java_name_index
	}, 
	; 424
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554721, ; type_token_id
		i32 265; java_name_index
	}, 
	; 425
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554439, ; type_token_id
		i32 120; java_name_index
	}, 
	; 426
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554748, ; type_token_id
		i32 282; java_name_index
	}, 
	; 427
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554460, ; type_token_id
		i32 128; java_name_index
	}, 
	; 428
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554439, ; type_token_id
		i32 145; java_name_index
	}, 
	; 429
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554783, ; type_token_id
		i32 299; java_name_index
	}, 
	; 430
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554487, ; type_token_id
		i32 194; java_name_index
	}, 
	; 431
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555117, ; type_token_id
		i32 472; java_name_index
	}, 
	; 432
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554437, ; type_token_id
		i32 118; java_name_index
	}, 
	; 433
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554435, ; type_token_id
		i32 147; java_name_index
	}, 
	; 434
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 368; java_name_index
	}, 
	; 435
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554464, ; type_token_id
		i32 10; java_name_index
	}, 
	; 436
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554461, ; type_token_id
		i32 179; java_name_index
	}, 
	; 437
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 318; java_name_index
	}, 
	; 438
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 464; java_name_index
	}, 
	; 439
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554817, ; type_token_id
		i32 314; java_name_index
	}, 
	; 440
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 345; java_name_index
	}, 
	; 441
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554608, ; type_token_id
		i32 102; java_name_index
	}, 
	; 442
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555285, ; type_token_id
		i32 543; java_name_index
	}, 
	; 443
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554715, ; type_token_id
		i32 260; java_name_index
	}, 
	; 444
	%struct.TypeMapJava {
		i32 8, ; module_index
		i32 33554450, ; type_token_id
		i32 605; java_name_index
	}, 
	; 445
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554438, ; type_token_id
		i32 166; java_name_index
	}, 
	; 446
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555207, ; type_token_id
		i32 495; java_name_index
	}, 
	; 447
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 483; java_name_index
	}, 
	; 448
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555383, ; type_token_id
		i32 595; java_name_index
	}, 
	; 449
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554946, ; type_token_id
		i32 374; java_name_index
	}, 
	; 450
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 370; java_name_index
	}, 
	; 451
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554853, ; type_token_id
		i32 328; java_name_index
	}, 
	; 452
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554539, ; type_token_id
		i32 47; java_name_index
	}, 
	; 453
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554918, ; type_token_id
		i32 358; java_name_index
	}, 
	; 454
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554612, ; type_token_id
		i32 111; java_name_index
	}, 
	; 455
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555359, ; type_token_id
		i32 593; java_name_index
	}, 
	; 456
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554874, ; type_token_id
		i32 338; java_name_index
	}, 
	; 457
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554502, ; type_token_id
		i32 27; java_name_index
	}, 
	; 458
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554435, ; type_token_id
		i32 143; java_name_index
	}, 
	; 459
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554435, ; type_token_id
		i32 164; java_name_index
	}, 
	; 460
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554651, ; type_token_id
		i32 223; java_name_index
	}, 
	; 461
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554468, ; type_token_id
		i32 185; java_name_index
	}, 
	; 462
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554472, ; type_token_id
		i32 187; java_name_index
	}, 
	; 463
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554845, ; type_token_id
		i32 324; java_name_index
	}, 
	; 464
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 434; java_name_index
	}, 
	; 465
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 390; java_name_index
	}, 
	; 466
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555011, ; type_token_id
		i32 415; java_name_index
	}, 
	; 467
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554877, ; type_token_id
		i32 340; java_name_index
	}, 
	; 468
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 300; java_name_index
	}, 
	; 469
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554725, ; type_token_id
		i32 268; java_name_index
	}, 
	; 470
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 317; java_name_index
	}, 
	; 471
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 322; java_name_index
	}, 
	; 472
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554473, ; type_token_id
		i32 160; java_name_index
	}, 
	; 473
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555081, ; type_token_id
		i32 452; java_name_index
	}, 
	; 474
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 585; java_name_index
	}, 
	; 475
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554752, ; type_token_id
		i32 284; java_name_index
	}, 
	; 476
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 313; java_name_index
	}, 
	; 477
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554864, ; type_token_id
		i32 334; java_name_index
	}, 
	; 478
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554454, ; type_token_id
		i32 125; java_name_index
	}, 
	; 479
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 208; java_name_index
	}, 
	; 480
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554676, ; type_token_id
		i32 65; java_name_index
	}, 
	; 481
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555215, ; type_token_id
		i32 500; java_name_index
	}, 
	; 482
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554991, ; type_token_id
		i32 403; java_name_index
	}, 
	; 483
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554544, ; type_token_id
		i32 51; java_name_index
	}, 
	; 484
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554436, ; type_token_id
		i32 618; java_name_index
	}, 
	; 485
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 348; java_name_index
	}, 
	; 486
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 280; java_name_index
	}, 
	; 487
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554848, ; type_token_id
		i32 326; java_name_index
	}, 
	; 488
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554495, ; type_token_id
		i32 20; java_name_index
	}, 
	; 489
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555051, ; type_token_id
		i32 439; java_name_index
	}, 
	; 490
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554608, ; type_token_id
		i32 205; java_name_index
	}, 
	; 491
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554445, ; type_token_id
		i32 169; java_name_index
	}, 
	; 492
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554604, ; type_token_id
		i32 99; java_name_index
	}, 
	; 493
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555326, ; type_token_id
		i32 572; java_name_index
	}, 
	; 494
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554597, ; type_token_id
		i32 199; java_name_index
	}, 
	; 495
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554602, ; type_token_id
		i32 97; java_name_index
	}, 
	; 496
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554511, ; type_token_id
		i32 36; java_name_index
	}, 
	; 497
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 0, ; type_token_id
		i32 68; java_name_index
	}, 
	; 498
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554553, ; type_token_id
		i32 60; java_name_index
	}, 
	; 499
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555007, ; type_token_id
		i32 412; java_name_index
	}, 
	; 500
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555226, ; type_token_id
		i32 509; java_name_index
	}, 
	; 501
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 371; java_name_index
	}, 
	; 502
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554599, ; type_token_id
		i32 95; java_name_index
	}, 
	; 503
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 440; java_name_index
	}, 
	; 504
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554441, ; type_token_id
		i32 621; java_name_index
	}, 
	; 505
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554556, ; type_token_id
		i32 64; java_name_index
	}, 
	; 506
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554462, ; type_token_id
		i32 129; java_name_index
	}, 
	; 507
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555172, ; type_token_id
		i32 488; java_name_index
	}, 
	; 508
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554659, ; type_token_id
		i32 228; java_name_index
	}, 
	; 509
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554988, ; type_token_id
		i32 401; java_name_index
	}, 
	; 510
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554449, ; type_token_id
		i32 153; java_name_index
	}, 
	; 511
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554543, ; type_token_id
		i32 50; java_name_index
	}, 
	; 512
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554683, ; type_token_id
		i32 76; java_name_index
	}, 
	; 513
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554765, ; type_token_id
		i32 288; java_name_index
	}, 
	; 514
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555293, ; type_token_id
		i32 551; java_name_index
	}, 
	; 515
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554637, ; type_token_id
		i32 14; java_name_index
	}, 
	; 516
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555213, ; type_token_id
		i32 498; java_name_index
	}, 
	; 517
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554881, ; type_token_id
		i32 341; java_name_index
	}, 
	; 518
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555170, ; type_token_id
		i32 487; java_name_index
	}, 
	; 519
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554788, ; type_token_id
		i32 301; java_name_index
	}, 
	; 520
	%struct.TypeMapJava {
		i32 6, ; module_index
		i32 33554437, ; type_token_id
		i32 198; java_name_index
	}, 
	; 521
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554920, ; type_token_id
		i32 359; java_name_index
	}, 
	; 522
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555008, ; type_token_id
		i32 413; java_name_index
	}, 
	; 523
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555284, ; type_token_id
		i32 542; java_name_index
	}, 
	; 524
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 295; java_name_index
	}, 
	; 525
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554942, ; type_token_id
		i32 372; java_name_index
	}, 
	; 526
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554963, ; type_token_id
		i32 386; java_name_index
	}, 
	; 527
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 352; java_name_index
	}, 
	; 528
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554606, ; type_token_id
		i32 204; java_name_index
	}, 
	; 529
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554951, ; type_token_id
		i32 377; java_name_index
	}, 
	; 530
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555214, ; type_token_id
		i32 499; java_name_index
	}, 
	; 531
	%struct.TypeMapJava {
		i32 10, ; module_index
		i32 33554438, ; type_token_id
		i32 619; java_name_index
	}, 
	; 532
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554460, ; type_token_id
		i32 155; java_name_index
	}, 
	; 533
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554445, ; type_token_id
		i32 123; java_name_index
	}, 
	; 534
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554648, ; type_token_id
		i32 221; java_name_index
	}, 
	; 535
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554453, ; type_token_id
		i32 3; java_name_index
	}, 
	; 536
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 423; java_name_index
	}, 
	; 537
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554668, ; type_token_id
		i32 57; java_name_index
	}, 
	; 538
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554994, ; type_token_id
		i32 405; java_name_index
	}, 
	; 539
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554780, ; type_token_id
		i32 297; java_name_index
	}, 
	; 540
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554463, ; type_token_id
		i32 9; java_name_index
	}, 
	; 541
	%struct.TypeMapJava {
		i32 9, ; module_index
		i32 33554448, ; type_token_id
		i32 612; java_name_index
	}, 
	; 542
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554609, ; type_token_id
		i32 105; java_name_index
	}, 
	; 543
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554545, ; type_token_id
		i32 52; java_name_index
	}, 
	; 544
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554557, ; type_token_id
		i32 67; java_name_index
	}, 
	; 545
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555131, ; type_token_id
		i32 481; java_name_index
	}, 
	; 546
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554986, ; type_token_id
		i32 400; java_name_index
	}, 
	; 547
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554692, ; type_token_id
		i32 90; java_name_index
	}, 
	; 548
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 211; java_name_index
	}, 
	; 549
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554484, ; type_token_id
		i32 192; java_name_index
	}, 
	; 550
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 475; java_name_index
	}, 
	; 551
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554872, ; type_token_id
		i32 337; java_name_index
	}, 
	; 552
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555003, ; type_token_id
		i32 409; java_name_index
	}, 
	; 553
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555282, ; type_token_id
		i32 540; java_name_index
	}, 
	; 554
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554655, ; type_token_id
		i32 225; java_name_index
	}, 
	; 555
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554474, ; type_token_id
		i32 161; java_name_index
	}, 
	; 556
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 290; java_name_index
	}, 
	; 557
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554706, ; type_token_id
		i32 254; java_name_index
	}, 
	; 558
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555017, ; type_token_id
		i32 421; java_name_index
	}, 
	; 559
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555348, ; type_token_id
		i32 586; java_name_index
	}, 
	; 560
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 351; java_name_index
	}, 
	; 561
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 219; java_name_index
	}, 
	; 562
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555235, ; type_token_id
		i32 514; java_name_index
	}, 
	; 563
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 309; java_name_index
	}, 
	; 564
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554949, ; type_token_id
		i32 376; java_name_index
	}, 
	; 565
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554564, ; type_token_id
		i32 74; java_name_index
	}, 
	; 566
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 451; java_name_index
	}, 
	; 567
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555105, ; type_token_id
		i32 465; java_name_index
	}, 
	; 568
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555015, ; type_token_id
		i32 419; java_name_index
	}, 
	; 569
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554518, ; type_token_id
		i32 37; java_name_index
	}, 
	; 570
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554732, ; type_token_id
		i32 273; java_name_index
	}, 
	; 571
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555153, ; type_token_id
		i32 482; java_name_index
	}, 
	; 572
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554624, ; type_token_id
		i32 214; java_name_index
	}, 
	; 573
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554480, ; type_token_id
		i32 141; java_name_index
	}, 
	; 574
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554467, ; type_token_id
		i32 184; java_name_index
	}, 
	; 575
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555094, ; type_token_id
		i32 459; java_name_index
	}, 
	; 576
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554996, ; type_token_id
		i32 407; java_name_index
	}, 
	; 577
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555303, ; type_token_id
		i32 558; java_name_index
	}, 
	; 578
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554478, ; type_token_id
		i32 140; java_name_index
	}, 
	; 579
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555065, ; type_token_id
		i32 449; java_name_index
	}, 
	; 580
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 339; java_name_index
	}, 
	; 581
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554463, ; type_token_id
		i32 157; java_name_index
	}, 
	; 582
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554452, ; type_token_id
		i32 175; java_name_index
	}, 
	; 583
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555027, ; type_token_id
		i32 428; java_name_index
	}, 
	; 584
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 461; java_name_index
	}, 
	; 585
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555087, ; type_token_id
		i32 455; java_name_index
	}, 
	; 586
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555324, ; type_token_id
		i32 570; java_name_index
	}, 
	; 587
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554795, ; type_token_id
		i32 304; java_name_index
	}, 
	; 588
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554983, ; type_token_id
		i32 399; java_name_index
	}, 
	; 589
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554892, ; type_token_id
		i32 346; java_name_index
	}, 
	; 590
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554855, ; type_token_id
		i32 329; java_name_index
	}, 
	; 591
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555357, ; type_token_id
		i32 592; java_name_index
	}, 
	; 592
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555248, ; type_token_id
		i32 522; java_name_index
	}, 
	; 593
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554740, ; type_token_id
		i32 278; java_name_index
	}, 
	; 594
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555360, ; type_token_id
		i32 594; java_name_index
	}, 
	; 595
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554927, ; type_token_id
		i32 363; java_name_index
	}, 
	; 596
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555055, ; type_token_id
		i32 441; java_name_index
	}, 
	; 597
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 316; java_name_index
	}, 
	; 598
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554977, ; type_token_id
		i32 394; java_name_index
	}, 
	; 599
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554435, ; type_token_id
		i32 117; java_name_index
	}, 
	; 600
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554505, ; type_token_id
		i32 29; java_name_index
	}, 
	; 601
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554626, ; type_token_id
		i32 215; java_name_index
	}, 
	; 602
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555351, ; type_token_id
		i32 588; java_name_index
	}, 
	; 603
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554646, ; type_token_id
		i32 25; java_name_index
	}, 
	; 604
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554478, ; type_token_id
		i32 190; java_name_index
	}, 
	; 605
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 356; java_name_index
	}, 
	; 606
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 325; java_name_index
	}, 
	; 607
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555173, ; type_token_id
		i32 489; java_name_index
	}, 
	; 608
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 294; java_name_index
	}, 
	; 609
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 393; java_name_index
	}, 
	; 610
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 312; java_name_index
	}, 
	; 611
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 310; java_name_index
	}, 
	; 612
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554601, ; type_token_id
		i32 96; java_name_index
	}, 
	; 613
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554658, ; type_token_id
		i32 46; java_name_index
	}, 
	; 614
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554928, ; type_token_id
		i32 364; java_name_index
	}, 
	; 615
	%struct.TypeMapJava {
		i32 3, ; module_index
		i32 33554466, ; type_token_id
		i32 158; java_name_index
	}, 
	; 616
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33554981, ; type_token_id
		i32 397; java_name_index
	}, 
	; 617
	%struct.TypeMapJava {
		i32 0, ; module_index
		i32 33554603, ; type_token_id
		i32 98; java_name_index
	}, 
	; 618
	%struct.TypeMapJava {
		i32 5, ; module_index
		i32 33554455, ; type_token_id
		i32 176; java_name_index
	}, 
	; 619
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 33555013, ; type_token_id
		i32 417; java_name_index
	}, 
	; 620
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 584; java_name_index
	}, 
	; 621
	%struct.TypeMapJava {
		i32 7, ; module_index
		i32 0, ; type_token_id
		i32 243; java_name_index
	}, 
	; 622
	%struct.TypeMapJava {
		i32 1, ; module_index
		i32 33554471, ; type_token_id
		i32 136; java_name_index
	}, 
	; 623
	%struct.TypeMapJava {
		i32 2, ; module_index
		i32 33554434, ; type_token_id
		i32 142; java_name_index
	}
], align 4; end of 'map_java' array

@map_java_hashes = local_unnamed_addr constant [624 x i32] [
	i32 4689355, ; 0: 0x478dcb => android/animation/Animator$AnimatorListener
	i32 12341354, ; 1: 0xbc506a => java/lang/Object
	i32 12507823, ; 2: 0xbedaaf => java/lang/AutoCloseable
	i32 12843394, ; 3: 0xc3f982 => crc643f46942d9dd1fff9/CellRenderer_RendererHolder
	i32 12855812, ; 4: 0xc42a04 => android/text/style/LineHeightSpan
	i32 13389226, ; 5: 0xcc4daa => java/lang/reflect/GenericDeclaration
	i32 16785207, ; 6: 0x1001f37 => crc643f46942d9dd1fff9/ButtonRenderer_ButtonClickListener
	i32 21368018, ; 7: 0x1460cd2 => android/support/v7/app/ActionBar$OnMenuVisibilityListener
	i32 29653966, ; 8: 0x1c47bce => android/widget/ListAdapter
	i32 32078366, ; 9: 0x1e97a1e => java/security/cert/Certificate
	i32 34115578, ; 10: 0x2088ffa => android/content/pm/PackageItemInfo
	i32 41795600, ; 11: 0x27dc010 => java/nio/CharBuffer
	i32 74282880, ; 12: 0x46d7780 => android/view/ViewGroup
	i32 84395501, ; 13: 0x507c5ed => crc643f46942d9dd1fff9/ScrollViewContainer
	i32 90623032, ; 14: 0x566cc38 => android/support/v4/app/FragmentManager$OnBackStackChangedListener
	i32 101184921, ; 15: 0x607f599 => mono/android/app/DatePickerDialog_OnDateSetListenerImplementor
	i32 106428973, ; 16: 0x657fa2d => crc643f46942d9dd1fff9/BaseCellView
	i32 118977103, ; 17: 0x717724f => android/util/DisplayMetrics
	i32 119391918, ; 18: 0x71dc6ae => crc64ee486da937c010f4/ButtonRenderer
	i32 121332358, ; 19: 0x73b6286 => crc643f46942d9dd1fff9/ProgressBarRenderer
	i32 133154022, ; 20: 0x7efc4e6 => java/nio/channels/SeekableByteChannel
	i32 134617809, ; 21: 0x8061ad1 => android/support/v7/app/ActionBar$Tab
	i32 138171443, ; 22: 0x83c5433 => javax/net/ssl/SSLSessionContext
	i32 139280357, ; 23: 0x84d3fe5 => android/view/KeyEvent
	i32 148505617, ; 24: 0x8da0411 => android/text/GetChars
	i32 149497687, ; 25: 0x8e92757 => com/xamarin/forms/platform/android/FormsViewGroup
	i32 150434817, ; 26: 0x8f77401 => android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener
	i32 151062962, ; 27: 0x90109b2 => java/lang/reflect/TypeVariable
	i32 166208029, ; 28: 0x9e8221d => java/text/DecimalFormat
	i32 170356038, ; 29: 0xa276d46 => android/support/v7/widget/SwitchCompat
	i32 170818099, ; 30: 0xa2e7a33 => java/nio/IntBuffer
	i32 176697843, ; 31: 0xa8831f3 => java/lang/IllegalArgumentException
	i32 181638202, ; 32: 0xad3943a => javax/microedition/khronos/opengles/GL
	i32 182338948, ; 33: 0xade4584 => java/nio/channels/Channel
	i32 192156965, ; 34: 0xb741525 => android/media/VolumeShaper$Configuration
	i32 196798070, ; 35: 0xbbae676 => crc643f46942d9dd1fff9/ScrollViewRenderer
	i32 220529267, ; 36: 0xd250273 => android/support/v7/app/ActionBarDrawerToggle
	i32 229694295, ; 37: 0xdb0db57 => java/nio/channels/WritableByteChannel
	i32 238150282, ; 38: 0xe31e28a => android/widget/NumberPicker
	i32 251666975, ; 39: 0xf00221f => android/widget/DatePicker
	i32 257094054, ; 40: 0xf52f1a6 => java/lang/ReflectiveOperationException
	i32 268673672, ; 41: 0x1003a288 => android/view/accessibility/AccessibilityEventSource
	i32 269111810, ; 42: 0x100a5202 => crc643f46942d9dd1fff9/ListViewRenderer_Container
	i32 269199815, ; 43: 0x100ba9c7 => javax/security/cert/X509Certificate
	i32 277940852, ; 44: 0x10910a74 => android/view/ViewGroup$OnHierarchyChangeListener
	i32 298436412, ; 45: 0x11c9c73c => android/widget/GridView
	i32 307048059, ; 46: 0x124d2e7b => android/view/MenuItem$OnActionExpandListener
	i32 312053096, ; 47: 0x12998d68 => crc64720bb2db43a66fe9/NavigationPageRenderer_Container
	i32 317135051, ; 48: 0x12e718cb => android/animation/Animator
	i32 318734747, ; 49: 0x12ff819b => android/support/v7/view/menu/MenuBuilder
	i32 327411168, ; 50: 0x1383e5e0 => crc643f46942d9dd1fff9/GroupedListViewAdapter
	i32 345266101, ; 51: 0x149457b5 => android/support/v4/graphics/drawable/DrawableCompat
	i32 350063814, ; 52: 0x14dd8cc6 => crc643f46942d9dd1fff9/PickerRenderer
	i32 358279401, ; 53: 0x155ae8e9 => android/text/style/CharacterStyle
	i32 362231028, ; 54: 0x159734f4 => java/net/URI
	i32 366002464, ; 55: 0x15d0c120 => android/support/v7/view/menu/MenuPresenter$Callback
	i32 366469956, ; 56: 0x15d7e344 => crc64ee486da937c010f4/FrameRenderer
	i32 366534601, ; 57: 0x15d8dfc9 => android/view/ViewGroup$LayoutParams
	i32 367245512, ; 58: 0x15e3b8c8 => crc643f46942d9dd1fff9/LabelRenderer
	i32 368584068, ; 59: 0x15f82584 => android/support/v7/widget/ScrollingTabContainerView
	i32 384559414, ; 60: 0x16ebe936 => crc643f46942d9dd1fff9/ToolbarButton
	i32 393371378, ; 61: 0x17725ef2 => mono/java/lang/RunnableImplementor
	i32 399364059, ; 62: 0x17cdcfdb => android/animation/TimeInterpolator
	i32 410684164, ; 63: 0x187a8b04 => crc64720bb2db43a66fe9/PickerRenderer
	i32 412395228, ; 64: 0x1894a6dc => java/security/KeyStore$LoadStoreParameter
	i32 412771173, ; 65: 0x189a6365 => java/lang/Long
	i32 419359493, ; 66: 0x18feeb05 => java/util/Iterator
	i32 420482824, ; 67: 0x19100f08 => java/net/ConnectException
	i32 424391913, ; 68: 0x194bb4e9 => java/lang/ClassLoader
	i32 434958167, ; 69: 0x19ecef57 => android/runtime/XmlReaderPullParser
	i32 439788454, ; 70: 0x1a36a3a6 => android/opengl/GLSurfaceView
	i32 441025504, ; 71: 0x1a4983e0 => crc643f46942d9dd1fff9/GenericMenuClickListener
	i32 443233435, ; 72: 0x1a6b349b => java/lang/LinkageError
	i32 445971717, ; 73: 0x1a94fd05 => crc64720bb2db43a66fe9/ButtonRenderer_ButtonClickListener
	i32 454360943, ; 74: 0x1b14ff6f => android/view/ViewTreeObserver$OnGlobalFocusChangeListener
	i32 458908568, ; 75: 0x1b5a6398 => crc64720bb2db43a66fe9/CarouselPageRenderer
	i32 466997013, ; 76: 0x1bd5cf15 => java/lang/reflect/AnnotatedElement
	i32 494182306, ; 77: 0x1d749fa2 => crc643f46942d9dd1fff9/TableViewModelRenderer
	i32 496889387, ; 78: 0x1d9dee2b => crc643f46942d9dd1fff9/TableViewRenderer
	i32 501733478, ; 79: 0x1de7d866 => android/view/ViewGroup$MarginLayoutParams
	i32 509491678, ; 80: 0x1e5e39de => android/view/LayoutInflater$Factory
	i32 514704326, ; 81: 0x1eadc3c6 => android/support/v4/app/TaskStackBuilder
	i32 517025718, ; 82: 0x1ed12fb6 => android/view/ViewParent
	i32 517668398, ; 83: 0x1edafe2e => android/os/Parcel
	i32 522924724, ; 84: 0x1f2b32b4 => crc643f46942d9dd1fff9/SearchBarRenderer
	i32 528353894, ; 85: 0x1f7e0a66 => android/arch/lifecycle/LifecycleObserver
	i32 531198748, ; 86: 0x1fa9731c => mono/android/runtime/OutputStreamAdapter
	i32 536181430, ; 87: 0x1ff57ab6 => crc643f46942d9dd1fff9/WebViewRenderer_JavascriptResult
	i32 536324699, ; 88: 0x1ff7aa5b => crc64720bb2db43a66fe9/NavigationPageRenderer_ClickListener
	i32 550445668, ; 89: 0x20cf2264 => crc643f46942d9dd1fff9/MasterDetailRenderer
	i32 553905247, ; 90: 0x2103ec5f => android/graphics/drawable/ColorDrawable
	i32 554951604, ; 91: 0x2113e3b4 => crc643f46942d9dd1fff9/ActivityIndicatorRenderer
	i32 568462196, ; 92: 0x21e20b74 => android/content/DialogInterface$OnDismissListener
	i32 571321220, ; 93: 0x220dab84 => android/widget/SectionIndexer
	i32 574308542, ; 94: 0x223b40be => crc64720bb2db43a66fe9/MasterDetailContainer
	i32 581097368, ; 95: 0x22a2d798 => java/nio/channels/FileChannel
	i32 584201455, ; 96: 0x22d234ef => android/widget/Filter
	i32 584231583, ; 97: 0x22d2aa9f => java/lang/IllegalStateException
	i32 590702782, ; 98: 0x233568be => android/view/ViewTreeObserver
	i32 591810476, ; 99: 0x23464fac => android/os/Bundle
	i32 596068502, ; 100: 0x23874896 => android/support/design/widget/TabLayout
	i32 605349366, ; 101: 0x2414e5f6 => crc643f46942d9dd1fff9/SwitchRenderer
	i32 606085292, ; 102: 0x242020ac => java/io/Serializable
	i32 618118586, ; 103: 0x24d7bdba => crc643f46942d9dd1fff9/FormsWebChromeClient
	i32 619060219, ; 104: 0x24e61bfb => java/net/URL
	i32 630387043, ; 105: 0x2592f163 => android/text/method/KeyListener
	i32 632089155, ; 106: 0x25acea43 => android/app/TimePickerDialog
	i32 638717086, ; 107: 0x26120c9e => android/view/GestureDetector$OnGestureListener
	i32 658258285, ; 108: 0x273c396d => crc64dbeead12be5aee1d/MainActivity
	i32 660927550, ; 109: 0x2764f43e => android/support/v4/content/ContextCompat
	i32 671763918, ; 110: 0x280a4dce => crc643f46942d9dd1fff9/FormsTextView
	i32 685199447, ; 111: 0x28d75057 => android/media/VolumeAutomation
	i32 692920175, ; 112: 0x294d1f6f => java/util/ArrayList
	i32 706212339, ; 113: 0x2a17f1f3 => crc643f46942d9dd1fff9/PageContainer
	i32 725629047, ; 114: 0x2b403877 => crc643f46942d9dd1fff9/ViewRenderer
	i32 739999095, ; 115: 0x2c1b7d77 => crc643f46942d9dd1fff9/AHorizontalScrollView
	i32 741095218, ; 116: 0x2c2c3732 => android/widget/RelativeLayout
	i32 747134991, ; 117: 0x2c88600f => crc643f46942d9dd1fff9/TimePickerRenderer_TimePickerListener
	i32 755077306, ; 118: 0x2d0190ba => crc643f46942d9dd1fff9/FormattedStringExtensions_LineHeightSpan
	i32 762267294, ; 119: 0x2d6f469e => android/support/v7/view/menu/SubMenuBuilder
	i32 780408360, ; 120: 0x2e841628 => java/lang/CharSequence
	i32 780987551, ; 121: 0x2e8cec9f => java/io/PrintWriter
	i32 784348946, ; 122: 0x2ec03712 => android/widget/DatePicker$OnDateChangedListener
	i32 787555063, ; 123: 0x2ef122f7 => crc643f46942d9dd1fff9/PickerRenderer_PickerListener
	i32 793918146, ; 124: 0x2f523ac2 => java/lang/Integer
	i32 798443257, ; 125: 0x2f9746f9 => android/support/v7/app/AppCompatCallback
	i32 805498755, ; 126: 0x3002ef83 => android/os/IBinder$DeathRecipient
	i32 806800039, ; 127: 0x3016caa7 => java/lang/Thread
	i32 806884132, ; 128: 0x30181324 => java/text/DecimalFormatSymbols
	i32 838682992, ; 129: 0x31fd4970 => java/lang/NullPointerException
	i32 843201759, ; 130: 0x32423cdf => android/animation/Animator$AnimatorPauseListener
	i32 843976700, ; 131: 0x324e0ffc => android/support/v7/widget/Toolbar
	i32 851697872, ; 132: 0x32c3e0d0 => crc64720bb2db43a66fe9/SwitchRenderer
	i32 851809012, ; 133: 0x32c592f4 => android/support/v4/view/ViewPager$OnPageChangeListener
	i32 857458217, ; 134: 0x331bc629 => android/content/res/AssetManager
	i32 864882745, ; 135: 0x338d1039 => android/graphics/Bitmap$Config
	i32 876646173, ; 136: 0x34408f1d => javax/net/ssl/TrustManager
	i32 893363610, ; 137: 0x353fa59a => java/lang/Short
	i32 915625445, ; 138: 0x369355e5 => android/support/design/widget/TabLayout$Tab
	i32 925357775, ; 139: 0x3727d6cf => java/nio/ByteBuffer
	i32 928674904, ; 140: 0x375a7458 => android/graphics/BitmapFactory
	i32 929500419, ; 141: 0x37670d03 => crc643f46942d9dd1fff9/GestureManager_TapAndPanGestureDetector
	i32 933236006, ; 142: 0x37a00d26 => android/support/v4/app/Fragment$SavedState
	i32 938344595, ; 143: 0x37ee0093 => android/support/design/widget/BottomNavigationView$OnNavigationItemReselectedListener
	i32 955594626, ; 144: 0x38f53782 => android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks
	i32 960048840, ; 145: 0x39392ec8 => android/support/v7/app/AppCompatDelegate
	i32 964779174, ; 146: 0x39815ca6 => android/text/TextUtils
	i32 967170543, ; 147: 0x39a5d9ef => android/text/TextPaint
	i32 968142514, ; 148: 0x39b4aeb2 => android/view/View$OnCreateContextMenuListener
	i32 976682796, ; 149: 0x3a36ff2c => java/lang/Readable
	i32 982326989, ; 150: 0x3a8d1ecd => android/widget/HorizontalScrollView
	i32 983151272, ; 151: 0x3a99b2a8 => android/support/v4/view/ScaleGestureDetectorCompat
	i32 988336100, ; 152: 0x3ae8cfe4 => android/view/KeyEvent$Callback
	i32 988965965, ; 153: 0x3af26c4d => android/text/method/BaseKeyListener
	i32 996699600, ; 154: 0x3b686dd0 => java/io/FileDescriptor
	i32 998009430, ; 155: 0x3b7c6a56 => java/nio/channels/GatheringByteChannel
	i32 1000548692, ; 156: 0x3ba32954 => android/support/v7/widget/DecorToolbar
	i32 1002766992, ; 157: 0x3bc50290 => crc643f46942d9dd1fff9/ImageRenderer
	i32 1018791985, ; 158: 0x3cb98831 => android/widget/EditText
	i32 1026507328, ; 159: 0x3d2f4240 => java/net/SocketAddress
	i32 1030707578, ; 160: 0x3d6f597a => android/database/DataSetObserver
	i32 1035992969, ; 161: 0x3dbfff89 => android/content/res/Resources
	i32 1046511593, ; 162: 0x3e607fe9 => android/text/InputFilter$LengthFilter
	i32 1048070238, ; 163: 0x3e78485e => android/view/GestureDetector$OnDoubleTapListener
	i32 1055644286, ; 164: 0x3eebda7e => android/widget/AbsoluteLayout
	i32 1062235695, ; 165: 0x3f506e2f => java/security/KeyStore$ProtectionParameter
	i32 1073016658, ; 166: 0x3ff4ef52 => java/lang/annotation/Annotation
	i32 1073696643, ; 167: 0x3fff4f83 => mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor
	i32 1090939588, ; 168: 0x41066ac4 => javax/net/ssl/KeyManagerFactory
	i32 1097250267, ; 169: 0x4166b5db => crc643f46942d9dd1fff9/MasterDetailContainer
	i32 1100963717, ; 170: 0x419f5f85 => android/widget/TextView$OnEditorActionListener
	i32 1102400940, ; 171: 0x41b54dac => android/support/v4/app/Fragment
	i32 1108415989, ; 172: 0x421115f5 => android/widget/AdapterView$OnItemLongClickListener
	i32 1117937440, ; 173: 0x42a25f20 => android/view/ViewTreeObserver$OnTouchModeChangeListener
	i32 1121817792, ; 174: 0x42dd94c0 => crc643f46942d9dd1fff9/TabbedRenderer
	i32 1142011573, ; 175: 0x4411b6b5 => java/util/Enumeration
	i32 1149267780, ; 176: 0x44806f44 => java/lang/Cloneable
	i32 1152243858, ; 177: 0x44add892 => javax/microedition/khronos/opengles/GL10
	i32 1160021234, ; 178: 0x452484f2 => crc643f46942d9dd1fff9/NativeViewWrapperRenderer
	i32 1175636112, ; 179: 0x4612c890 => java/lang/ClassNotFoundException
	i32 1175688539, ; 180: 0x4613955b => android/support/design/widget/TabLayout$OnTabSelectedListener
	i32 1182637472, ; 181: 0x467d9da0 => android/support/v7/view/menu/MenuPresenter
	i32 1185273701, ; 182: 0x46a5d765 => android/view/SubMenu
	i32 1196063310, ; 183: 0x474a7a4e => java/lang/Appendable
	i32 1200883145, ; 184: 0x479405c9 => android/support/v4/app/ActionBarDrawerToggle
	i32 1205083900, ; 185: 0x47d41efc => android/animation/ValueAnimator
	i32 1212684324, ; 186: 0x48481824 => android/app/DatePickerDialog
	i32 1227075600, ; 187: 0x4923b010 => javax/security/cert/Certificate
	i32 1244064794, ; 188: 0x4a26ec1a => android/support/v4/content/Loader
	i32 1264345651, ; 189: 0x4b5c6233 => android/support/v4/widget/DrawerLayout$DrawerListener
	i32 1267415633, ; 190: 0x4b8b3a51 => android/os/Vibrator
	i32 1270186925, ; 191: 0x4bb583ad => android/view/Window$Callback
	i32 1270561450, ; 192: 0x4bbb3aaa => java/net/SocketTimeoutException
	i32 1281062668, ; 193: 0x4c5b770c => android/widget/SeekBar$OnSeekBarChangeListener
	i32 1290366087, ; 194: 0x4ce96c87 => android/view/CollapsibleActionView
	i32 1292893960, ; 195: 0x4d0fff08 => crc643f46942d9dd1fff9/FormattedStringExtensions_TextDecorationSpan
	i32 1298454265, ; 196: 0x4d64d6f9 => java/lang/Throwable
	i32 1310268936, ; 197: 0x4e191e08 => crc643f46942d9dd1fff9/EntryCellView
	i32 1311929319, ; 198: 0x4e3273e7 => crc643f46942d9dd1fff9/InnerGestureListener
	i32 1323697755, ; 199: 0x4ee6065b => javax/net/ssl/SSLContext
	i32 1335098580, ; 200: 0x4f93fcd4 => java/util/Collection
	i32 1340347874, ; 201: 0x4fe415e2 => android/graphics/Paint
	i32 1348172419, ; 202: 0x505b7a83 => android/app/ActionBar
	i32 1368421702, ; 203: 0x51907546 => java/lang/ClassCastException
	i32 1370891736, ; 204: 0x51b625d8 => android/graphics/PorterDuff$Mode
	i32 1373631042, ; 205: 0x51dff242 => javax/net/ssl/KeyManager
	i32 1386757446, ; 206: 0x52a83d46 => android/content/ComponentName
	i32 1388906712, ; 207: 0x52c908d8 => java/lang/Comparable
	i32 1398811288, ; 208: 0x53602a98 => crc643f46942d9dd1fff9/ImageButtonRenderer
	i32 1404166657, ; 209: 0x53b1e201 => android/support/v4/internal/view/SupportMenu
	i32 1414504369, ; 210: 0x544f9fb1 => crc64720bb2db43a66fe9/Platform_ModalContainer
	i32 1415978247, ; 211: 0x54661d07 => android/content/pm/ApplicationInfo
	i32 1425790689, ; 212: 0x54fbd6e1 => java/lang/SecurityException
	i32 1428048664, ; 213: 0x551e4b18 => java/net/HttpURLConnection
	i32 1429796945, ; 214: 0x5538f851 => android/graphics/RectF
	i32 1433059198, ; 215: 0x556abf7e => android/view/ViewManager
	i32 1438762315, ; 216: 0x55c1c54b => android/view/View$OnAttachStateChangeListener
	i32 1444123905, ; 217: 0x56139501 => android/support/v7/app/ActionBar$OnNavigationListener
	i32 1447309214, ; 218: 0x56442f9e => android/widget/LinearLayout$LayoutParams
	i32 1448438974, ; 219: 0x56556cbe => android/view/animation/AccelerateInterpolator
	i32 1453012136, ; 220: 0x569b34a8 => mono/android/support/v4/view/ViewPager_OnPageChangeListenerImplementor
	i32 1457311873, ; 221: 0x56dcd081 => mono/android/content/DialogInterface_OnCancelListenerImplementor
	i32 1457582199, ; 222: 0x56e0f077 => android/text/SpannableStringInternal
	i32 1459844378, ; 223: 0x5703751a => android/widget/ProgressBar
	i32 1464492834, ; 224: 0x574a6322 => mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor
	i32 1466161184, ; 225: 0x5763d820 => mono/android/support/design/widget/BottomNavigationView_OnNavigationItemSelectedListenerImplementor
	i32 1468165286, ; 226: 0x57826ca6 => android/support/v4/view/ActionProvider$SubUiVisibilityListener
	i32 1471437521, ; 227: 0x57b45ad1 => crc643f46942d9dd1fff9/OpenGLViewRenderer
	i32 1475682991, ; 228: 0x57f522af => java/util/HashMap
	i32 1484646360, ; 229: 0x587de7d8 => crc643f46942d9dd1fff9/ActionSheetRenderer
	i32 1485846485, ; 230: 0x589037d5 => android/support/v4/app/FragmentManager
	i32 1489594546, ; 231: 0x58c968b2 => java/nio/channels/spi/AbstractInterruptibleChannel
	i32 1497664125, ; 232: 0x59448a7d => android/support/design/widget/BottomNavigationView$OnNavigationItemSelectedListener
	i32 1506774891, ; 233: 0x59cf8f6b => android/widget/Button
	i32 1542555879, ; 234: 0x5bf188e7 => crc643f46942d9dd1fff9/ListViewRenderer
	i32 1544613420, ; 235: 0x5c10ee2c => java/io/File
	i32 1546872752, ; 236: 0x5c3367b0 => android/support/v7/app/ActionBarDrawerToggle$DelegateProvider
	i32 1548306256, ; 237: 0x5c494750 => android/view/WindowManager$LayoutParams
	i32 1560011070, ; 238: 0x5cfbe13e => android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback
	i32 1573833883, ; 239: 0x5dcecc9b => android/app/AlertDialog
	i32 1577737889, ; 240: 0x5e0a5ea1 => crc643f46942d9dd1fff9/PageRenderer
	i32 1581332053, ; 241: 0x5e413655 => crc643f46942d9dd1fff9/FormsAppCompatActivity
	i32 1583473051, ; 242: 0x5e61e19b => android/support/v7/widget/AppCompatButton
	i32 1584672329, ; 243: 0x5e742e49 => android/view/Display
	i32 1586851388, ; 244: 0x5e956e3c => android/os/Handler
	i32 1588770285, ; 245: 0x5eb2b5ed => android/app/FragmentTransaction
	i32 1595725058, ; 246: 0x5f1cd502 => java/nio/channels/ByteChannel
	i32 1605789814, ; 247: 0x5fb66876 => java/nio/channels/ScatteringByteChannel
	i32 1609205360, ; 248: 0x5fea8670 => android/opengl/GLSurfaceView$Renderer
	i32 1636879970, ; 249: 0x6190ce62 => mono/android/support/design/widget/BottomNavigationView_OnNavigationItemReselectedListenerImplementor
	i32 1637959351, ; 250: 0x61a146b7 => java/security/Principal
	i32 1641608421, ; 251: 0x61d8f4e5 => android/os/StrictMode$VmPolicy
	i32 1644876130, ; 252: 0x620ad162 => android/graphics/Matrix
	i32 1646348278, ; 253: 0x622147f6 => android/view/View
	i32 1649695927, ; 254: 0x62545cb7 => java/lang/RuntimeException
	i32 1653473656, ; 255: 0x628e0178 => android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator
	i32 1657134862, ; 256: 0x62c5df0e => java/lang/IndexOutOfBoundsException
	i32 1659690010, ; 257: 0x62ecdc1a => crc643f46942d9dd1fff9/ConditionalFocusLayout
	i32 1660273449, ; 258: 0x62f5c329 => crc64720bb2db43a66fe9/NavigationPageRenderer
	i32 1661912031, ; 259: 0x630ec3df => android/view/View$OnTouchListener
	i32 1672498570, ; 260: 0x63b04d8a => android/support/v4/app/LoaderManager$LoaderCallbacks
	i32 1680835779, ; 261: 0x642f84c3 => java/lang/Byte
	i32 1697387342, ; 262: 0x652c134e => crc643f46942d9dd1fff9/TimePickerRenderer
	i32 1699467861, ; 263: 0x654bd255 => android/widget/CompoundButton
	i32 1707466195, ; 264: 0x65c5ddd3 => mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor
	i32 1718265030, ; 265: 0x666aa4c6 => java/lang/Character
	i32 1729659134, ; 266: 0x671880fe => android/view/MenuInflater
	i32 1740814247, ; 267: 0x67c2b7a7 => android/widget/FrameLayout
	i32 1740929322, ; 268: 0x67c4792a => android/os/IInterface
	i32 1755285137, ; 269: 0x689f8691 => java/util/Random
	i32 1756909581, ; 270: 0x68b8500d => android/text/Layout
	i32 1758490869, ; 271: 0x68d070f5 => android/os/BaseBundle
	i32 1771248925, ; 272: 0x69931d1d => android/support/v4/app/FragmentActivity
	i32 1772705556, ; 273: 0x69a95714 => android/graphics/Point
	i32 1775355160, ; 274: 0x69d1c518 => android/content/res/ColorStateList
	i32 1786818014, ; 275: 0x6a80adde => android/widget/AbsoluteLayout$LayoutParams
	i32 1790236887, ; 276: 0x6ab4d8d7 => android/text/Spanned
	i32 1807220671, ; 277: 0x6bb7ffbf => android/view/View$OnClickListener
	i32 1817317664, ; 278: 0x6c521120 => crc643f46942d9dd1fff9/SwitchCellView
	i32 1828773851, ; 279: 0x6d00dfdb => java/security/cert/CertificateFactory
	i32 1835898073, ; 280: 0x6d6d94d9 => mono/android/support/v4/view/ViewPager_OnAdapterChangeListenerImplementor
	i32 1851730788, ; 281: 0x6e5f2b64 => java/lang/Runnable
	i32 1859010077, ; 282: 0x6ece3e1d => android/widget/LinearLayout
	i32 1860371261, ; 283: 0x6ee3033d => crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer_LongPressGestureListener
	i32 1866304377, ; 284: 0x6f3d8b79 => android/view/SearchEvent
	i32 1872656141, ; 285: 0x6f9e770d => mono/android/support/design/widget/TabLayout_OnTabSelectedListenerImplementor
	i32 1872777977, ; 286: 0x6fa052f9 => javax/microedition/khronos/egl/EGLConfig
	i32 1873436133, ; 287: 0x6faa5de5 => android/support/v7/widget/CardView
	i32 1877568311, ; 288: 0x6fe96b37 => mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor
	i32 1882041350, ; 289: 0x702dac06 => crc643f46942d9dd1fff9/VisualElementRenderer_1
	i32 1884841200, ; 290: 0x705864f0 => android/os/PowerManager
	i32 1889248750, ; 291: 0x709ba5ee => java/nio/channels/InterruptibleChannel
	i32 1895664339, ; 292: 0x70fd8ad3 => android/widget/RelativeLayout$LayoutParams
	i32 1898500913, ; 293: 0x7128d331 => java/nio/FloatBuffer
	i32 1903394236, ; 294: 0x71737dbc => crc64720bb2db43a66fe9/NavigationPageRenderer_DrawerMultiplexedListener
	i32 1904678085, ; 295: 0x718714c5 => android/text/style/ForegroundColorSpan
	i32 1943699094, ; 296: 0x73da7e96 => crc643f46942d9dd1fff9/InnerScaleListener
	i32 1943778051, ; 297: 0x73dbb303 => android/widget/AdapterView$OnItemSelectedListener
	i32 1944129628, ; 298: 0x73e1105c => java/io/OutputStream
	i32 1950441461, ; 299: 0x74415ff5 => android/text/ParcelableSpan
	i32 1960987726, ; 300: 0x74e24c4e => mono/android/content/DialogInterface_OnDismissListenerImplementor
	i32 1962126435, ; 301: 0x74f3ac63 => android/content/BroadcastReceiver
	i32 1964342327, ; 302: 0x75157c37 => crc643f46942d9dd1fff9/ToolbarImageButton
	i32 1976530008, ; 303: 0x75cf7458 => android/support/v7/view/ActionMode
	i32 1977499375, ; 304: 0x75de3eef => android/support/v4/view/ViewPropertyAnimatorCompat
	i32 1985929388, ; 305: 0x765ee0ac => android/app/Activity
	i32 1987841337, ; 306: 0x767c0d39 => java/lang/Boolean
	i32 1990610968, ; 307: 0x76a65018 => android/widget/AdapterView$OnItemClickListener
	i32 1999563224, ; 308: 0x772ee9d8 => android/graphics/drawable/GradientDrawable
	i32 2008064836, ; 309: 0x77b0a344 => android/content/Intent
	i32 2014726135, ; 310: 0x781647f7 => android/view/accessibility/AccessibilityRecord
	i32 2027782872, ; 311: 0x78dd82d8 => android/view/ContextThemeWrapper
	i32 2029919256, ; 312: 0x78fe1c18 => crc643f46942d9dd1fff9/DatePickerRenderer_TextFieldClickHandler
	i32 2031450615, ; 313: 0x791579f7 => android/widget/AdapterView
	i32 2036556174, ; 314: 0x7963618e => android/content/DialogInterface
	i32 2039728241, ; 315: 0x7993c871 => android/widget/TimePicker
	i32 2043030513, ; 316: 0x79c62bf1 => android/os/Parcelable$Creator
	i32 2047721020, ; 317: 0x7a0dbe3c => android/webkit/WebChromeClient$FileChooserParams
	i32 2048817474, ; 318: 0x7a1e7942 => crc643f46942d9dd1fff9/WebViewRenderer
	i32 2050558450, ; 319: 0x7a3909f2 => android/support/v4/view/TintableBackgroundView
	i32 2057114326, ; 320: 0x7a9d12d6 => java/security/cert/X509Extension
	i32 2063985753, ; 321: 0x7b05ec59 => android/view/animation/Animation
	i32 2064723667, ; 322: 0x7b112ed3 => android/widget/SpinnerAdapter
	i32 2073337312, ; 323: 0x7b949de0 => android/app/AlertDialog$Builder
	i32 2074034559, ; 324: 0x7b9f417f => crc643f46942d9dd1fff9/ViewRenderer_2
	i32 2074243551, ; 325: 0x7ba271df => android/support/v4/app/FragmentManager$BackStackEntry
	i32 2079753938, ; 326: 0x7bf686d2 => android/content/IntentSender
	i32 2080685156, ; 327: 0x7c04bc64 => java/security/SecureRandom
	i32 2090823071, ; 328: 0x7c9f6d9f => android/os/Environment
	i32 2093036686, ; 329: 0x7cc1348e => crc643f46942d9dd1fff9/CarouselPageAdapter
	i32 2096401987, ; 330: 0x7cf48e43 => android/widget/AbsSeekBar
	i32 2099081960, ; 331: 0x7d1d72e8 => android/support/v4/app/LoaderManager
	i32 2100944957, ; 332: 0x7d39e03d => android/graphics/Path
	i32 2110921060, ; 333: 0x7dd21964 => crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuAdapter
	i32 2113018286, ; 334: 0x7df219ae => crc643f46942d9dd1fff9/EditorRenderer
	i32 2114237978, ; 335: 0x7e04b61a => android/content/res/Configuration
	i32 2120783598, ; 336: 0x7e6896ee => android/support/v4/view/ViewPager
	i32 2125153170, ; 337: 0x7eab4392 => mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor
	i32 2127582614, ; 338: 0x7ed05596 => crc643f46942d9dd1fff9/FrameRenderer
	i32 2131480051, ; 339: 0x7f0bcdf3 => android/animation/AnimatorListenerAdapter
	i32 2142522978, ; 340: 0x7fb44e62 => android/support/v4/widget/TextViewCompat
	i32 2158850425, ; 341: 0x80ad7179 => crc64720bb2db43a66fe9/FormsFragmentPagerAdapter_1
	i32 2176080607, ; 342: 0x81b45adf => android/graphics/drawable/BitmapDrawable
	i32 2183713232, ; 343: 0x8228d1d0 => crc64720bb2db43a66fe9/ViewRenderer_2
	i32 2204262174, ; 344: 0x83625f1e => org/xmlpull/v1/XmlPullParser
	i32 2212187999, ; 345: 0x83db4f5f => crc643f46942d9dd1fff9/PageExtensions_EmbeddedFragment
	i32 2267512470, ; 346: 0x87277e96 => crc64720bb2db43a66fe9/ButtonRenderer_ButtonTouchListener
	i32 2269094561, ; 347: 0x873fa2a1 => java/net/UnknownServiceException
	i32 2270923754, ; 348: 0x875b8bea => java/net/Proxy$Type
	i32 2284656609, ; 349: 0x882d17e1 => android/app/Application
	i32 2296411383, ; 350: 0x88e074f7 => android/content/IntentFilter
	i32 2316381801, ; 351: 0x8a112e69 => java/lang/reflect/Type
	i32 2316963515, ; 352: 0x8a1a0ebb => crc643f46942d9dd1fff9/FormsSeekBar
	i32 2323299264, ; 353: 0x8a7abbc0 => android/support/v4/view/ViewPager$OnAdapterChangeListener
	i32 2325674508, ; 354: 0x8a9efa0c => java/lang/Iterable
	i32 2346418601, ; 355: 0x8bdb81a9 => android/support/v4/app/FragmentPagerAdapter
	i32 2361905000, ; 356: 0x8cc7cf68 => android/support/v7/graphics/drawable/DrawerArrowDrawable
	i32 2363729366, ; 357: 0x8ce3a5d6 => java/lang/Enum
	i32 2364001221, ; 358: 0x8ce7cbc5 => crc643f46942d9dd1fff9/FormattedStringExtensions_FontSpan
	i32 2367500547, ; 359: 0x8d1d3103 => android/widget/SearchView
	i32 2371350972, ; 360: 0x8d57f1bc => android/widget/Switch
	i32 2395748977, ; 361: 0x8ecc3a71 => android/view/View$OnLayoutChangeListener
	i32 2404057846, ; 362: 0x8f4b02f6 => android/app/PendingIntent
	i32 2409724717, ; 363: 0x8fa17b2d => android/util/TypedValue
	i32 2410565953, ; 364: 0x8fae5141 => crc643f46942d9dd1fff9/FormsImageView
	i32 2410638029, ; 365: 0x8faf6acd => android/support/v4/app/ActivityCompat$PermissionCompatDelegate
	i32 2411404453, ; 366: 0x8fbb1ca5 => java/lang/UnsupportedOperationException
	i32 2420104680, ; 367: 0x903fdde8 => android/content/res/Resources$Theme
	i32 2432510118, ; 368: 0x90fd28a6 => crc643f46942d9dd1fff9/StepperRenderer
	i32 2443438835, ; 369: 0x91a3eaf3 => java/net/SocketException
	i32 2458007569, ; 370: 0x92823811 => android/os/Process
	i32 2461273673, ; 371: 0x92b40e49 => org/xmlpull/v1/XmlPullParserException
	i32 2462006028, ; 372: 0x92bf3b0c => android/content/ComponentCallbacks
	i32 2465247168, ; 373: 0x92f0afc0 => com/xamarin/formsviewgroup/BuildConfig
	i32 2479060654, ; 374: 0x93c376ae => crc64720bb2db43a66fe9/PickerRenderer_PickerListener
	i32 2484873381, ; 375: 0x941c28a5 => android/webkit/WebSettings
	i32 2497808471, ; 376: 0x94e18857 => android/widget/TimePicker$OnTimeChangedListener
	i32 2520212266, ; 377: 0x9637632a => java/nio/channels/ReadableByteChannel
	i32 2541780716, ; 378: 0x97807eec => android/view/ContextMenu$ContextMenuInfo
	i32 2558143838, ; 379: 0x987a2d5e => java/io/FileInputStream
	i32 2561967928, ; 380: 0x98b48738 => java/security/cert/X509Certificate
	i32 2565590497, ; 381: 0x98ebcde1 => android/app/DatePickerDialog$OnDateSetListener
	i32 2578357124, ; 382: 0x99ae9b84 => android/widget/ImageView$ScaleType
	i32 2583054407, ; 383: 0x99f64847 => mono/android/animation/AnimatorEventDispatcher
	i32 2585603720, ; 384: 0x9a1d2e88 => java/text/NumberFormat
	i32 2593423670, ; 385: 0x9a948136 => android/support/v7/view/menu/MenuBuilder$Callback
	i32 2594241228, ; 386: 0x9aa0facc => android/widget/BaseAdapter
	i32 2606059086, ; 387: 0x9b554e4e => android/widget/SearchView$OnQueryTextListener
	i32 2611866357, ; 388: 0x9badeaf5 => crc643f46942d9dd1fff9/CellAdapter
	i32 2615894356, ; 389: 0x9beb6154 => android/support/v4/internal/view/SupportMenuItem
	i32 2620251611, ; 390: 0x9c2ddddb => android/support/v4/view/NestedScrollingParent
	i32 2627681282, ; 391: 0x9c9f3c02 => crc643f46942d9dd1fff9/TextCellRenderer_TextCellView
	i32 2628279754, ; 392: 0x9ca85dca => android/content/DialogInterface$OnCancelListener
	i32 2631544208, ; 393: 0x9cda2d90 => android/widget/Filter$FilterListener
	i32 2637159311, ; 394: 0x9d2fdb8f => android/content/pm/PackageManager
	i32 2650660999, ; 395: 0x9dfde087 => crc643f46942d9dd1fff9/PageExtensions_EmbeddedSupportFragment
	i32 2652170898, ; 396: 0x9e14ea92 => crc643f46942d9dd1fff9/EntryRenderer
	i32 2654672461, ; 397: 0x9e3b164d => java/io/InterruptedIOException
	i32 2661939407, ; 398: 0x9ea9f8cf => android/widget/ImageButton
	i32 2664702160, ; 399: 0x9ed420d0 => crc643f46942d9dd1fff9/EntryEditText
	i32 2664928003, ; 400: 0x9ed79303 => javax/net/ssl/HostnameVerifier
	i32 2671854315, ; 401: 0x9f4142eb => crc643f46942d9dd1fff9/FormsWebViewClient
	i32 2675615863, ; 402: 0x9f7aa877 => android/webkit/WebViewClient
	i32 2679308441, ; 403: 0x9fb30099 => crc643f46942d9dd1fff9/BorderDrawable
	i32 2681209703, ; 404: 0x9fd00367 => android/widget/Adapter
	i32 2681988174, ; 405: 0x9fdbe44e => android/view/MotionEvent
	i32 2686858262, ; 406: 0xa0263416 => crc643f46942d9dd1fff9/VisualElementTracker_AttachTracker
	i32 2687190151, ; 407: 0xa02b4487 => android/support/v4/widget/SwipeRefreshLayout
	i32 2687778660, ; 408: 0xa0343f64 => android/widget/TextView
	i32 2691558259, ; 409: 0xa06deb73 => android/view/View$OnKeyListener
	i32 2699556053, ; 410: 0xa0e7f4d5 => android/webkit/WebResourceRequest
	i32 2710910562, ; 411: 0xa1953662 => android/widget/Checkable
	i32 2719447701, ; 412: 0xa2177a95 => crc643f46942d9dd1fff9/ButtonRenderer
	i32 2721599187, ; 413: 0xa2384ed3 => android/graphics/drawable/Drawable
	i32 2721845566, ; 414: 0xa23c113e => android/support/v4/widget/SwipeRefreshLayout$OnRefreshListener
	i32 2731618005, ; 415: 0xa2d12ed5 => android/view/View$MeasureSpec
	i32 2741050037, ; 416: 0xa3611ab5 => java/net/ProxySelector
	i32 2753284754, ; 417: 0xa41bca92 => android/text/style/UpdateAppearance
	i32 2755748727, ; 418: 0xa4416377 => android/text/Spannable
	i32 2762684487, ; 419: 0xa4ab3847 => java/lang/Float
	i32 2771894941, ; 420: 0xa537c29d => android/graphics/drawable/LayerDrawable
	i32 2796816157, ; 421: 0xa6b4071d => android/text/format/DateFormat
	i32 2815615939, ; 422: 0xa7d2e3c3 => android/os/Build
	i32 2817798317, ; 423: 0xa7f430ad => android/support/v7/view/menu/MenuItemImpl
	i32 2836478263, ; 424: 0xa9113937 => android/widget/ScrollView
	i32 2848829992, ; 425: 0xa9cdb228 => android/support/v4/view/ActionProvider
	i32 2857352824, ; 426: 0xaa4fbe78 => mono/android/view/View_OnKeyListenerImplementor
	i32 2858765195, ; 427: 0xaa654b8b => android/support/v4/view/ViewPropertyAnimatorListener
	i32 2859587555, ; 428: 0xaa71d7e3 => android/arch/lifecycle/LifecycleOwner
	i32 2866910344, ; 429: 0xaae19488 => android/view/ActionMode
	i32 2871105967, ; 430: 0xab2199af => android/support/v7/app/AppCompatActivity
	i32 2873107855, ; 431: 0xab40258f => android/content/pm/PackageInfo
	i32 2883628780, ; 432: 0xabe0aeec => android/support/v4/widget/TintableImageSourceView
	i32 2890363767, ; 433: 0xac477377 => android/support/v4/view/PagerAdapter
	i32 2905214894, ; 434: 0xad2a0fae => android/text/style/ParagraphStyle
	i32 2905765458, ; 435: 0xad327652 => crc643f46942d9dd1fff9/AndroidActivity
	i32 2906574921, ; 436: 0xad3ed049 => android/support/v7/widget/AppCompatImageButton
	i32 2917163057, ; 437: 0xade06031 => android/view/SurfaceHolder
	i32 2918613155, ; 438: 0xadf680a3 => android/content/DialogInterface$OnClickListener
	i32 2932874700, ; 439: 0xaed01dcc => android/view/InputEvent
	i32 2933762856, ; 440: 0xaeddab28 => android/util/AttributeSet
	i32 2939547218, ; 441: 0xaf35ee52 => crc64720bb2db43a66fe9/ButtonRenderer
	i32 2942792700, ; 442: 0xaf6773fc => java/lang/Exception
	i32 2944806563, ; 443: 0xaf862ea3 => android/widget/ListView
	i32 2954302002, ; 444: 0xb0171232 => android/support/v4/app/FragmentTransaction
	i32 2966961387, ; 445: 0xb0d83ceb => android/support/v7/view/ActionMode$Callback
	i32 2974982681, ; 446: 0xb152a219 => java/text/Format
	i32 2980510762, ; 447: 0xb1a6fc2a => mono/android/runtime/JavaArray
	i32 2983720033, ; 448: 0xb1d7f461 => mono/android/TypeManager
	i32 2985454904, ; 449: 0xb1f26d38 => android/text/method/DigitsKeyListener
	i32 2992476535, ; 450: 0xb25d9177 => android/text/style/UpdateLayout
	i32 3011322120, ; 451: 0xb37d2108 => android/view/Surface
	i32 3019458824, ; 452: 0xb3f94908 => crc643f46942d9dd1fff9/PlatformRenderer
	i32 3023394421, ; 453: 0xb4355675 => android/text/SpannableString
	i32 3028994003, ; 454: 0xb48ac7d3 => crc64720bb2db43a66fe9/TabbedPageRenderer
	i32 3032808825, ; 455: 0xb4c4fd79 => java/io/StringWriter
	i32 3052396687, ; 456: 0xb5efe08f => android/view/animation/DecelerateInterpolator
	i32 3061714165, ; 457: 0xb67e0cf5 => crc643f46942d9dd1fff9/FormsEditText
	i32 3077006502, ; 458: 0xb76764a6 => android/arch/lifecycle/Lifecycle$State
	i32 3097934252, ; 459: 0xb8a6b9ac => android/support/v7/content/res/AppCompatResources
	i32 3098597018, ; 460: 0xb8b0d69a => android/webkit/WebResourceError
	i32 3120301422, ; 461: 0xb9fc056e => android/support/v7/app/ActionBar$LayoutParams
	i32 3122685949, ; 462: 0xba2067fd => mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor
	i32 3141422855, ; 463: 0xbb3e4f07 => android/view/ScaleGestureDetector
	i32 3148065494, ; 464: 0xbba3aad6 => android/animation/ValueAnimator$AnimatorUpdateListener
	i32 3173395525, ; 465: 0xbd262c45 => android/os/IBinder
	i32 3173414241, ; 466: 0xbd267561 => android/graphics/Path$Direction
	i32 3178304415, ; 467: 0xbd71139f => android/view/inputmethod/InputMethodManager
	i32 3183271055, ; 468: 0xbdbcdc8f => android/view/ActionMode$Callback
	i32 3203260291, ; 469: 0xbeeddf83 => android/widget/SeekBar
	i32 3211926369, ; 470: 0xbf721b61 => android/view/SurfaceHolder$Callback2
	i32 3214744068, ; 471: 0xbf9d1a04 => android/view/WindowManager
	i32 3230263057, ; 472: 0xc089e711 => mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor
	i32 3263616128, ; 473: 0xc286d480 => android/app/Fragment
	i32 3264154243, ; 474: 0xc28f0a83 => java/io/Flushable
	i32 3271087717, ; 475: 0xc2f8d665 => mono/android/view/View_OnLayoutChangeListenerImplementor
	i32 3281925794, ; 476: 0xc39e36a2 => android/view/MenuItem
	i32 3290291610, ; 477: 0xc41ddd9a => android/view/ViewPropertyAnimator
	i32 3295872325, ; 478: 0xc4730545 => android/support/v4/view/NestedScrollingChild
	i32 3300906352, ; 479: 0xc4bfd570 => javax/net/ssl/SSLSession
	i32 3306874675, ; 480: 0xc51ae733 => crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuElementView
	i32 3319735188, ; 481: 0xc5df2394 => java/net/Proxy
	i32 3328509384, ; 482: 0xc66505c8 => android/media/VolumeShaper
	i32 3329708765, ; 483: 0xc67752dd => crc643f46942d9dd1fff9/CarouselPageRenderer
	i32 3333169487, ; 484: 0xc6ac214f => android/support/v4/content/Loader$OnLoadCanceledListener
	i32 3379688415, ; 485: 0xc971f3df => android/text/Editable
	i32 3388763936, ; 486: 0xc9fc6f20 => android/view/View$OnFocusChangeListener
	i32 3401332284, ; 487: 0xcabc363c => android/view/ScaleGestureDetector$SimpleOnScaleGestureListener
	i32 3402042179, ; 488: 0xcac70b43 => crc643f46942d9dd1fff9/PowerSaveModeBroadcastReceiver
	i32 3406043478, ; 489: 0xcb041956 => android/app/ActionBar$Tab
	i32 3409419575, ; 490: 0xcb379d37 => javax/net/ssl/HttpsURLConnection
	i32 3411895572, ; 491: 0xcb5d6514 => android/support/v7/view/menu/MenuView
	i32 3421473019, ; 492: 0xcbef88fb => crc64720bb2db43a66fe9/FragmentContainer
	i32 3423467887, ; 493: 0xcc0df96f => java/lang/Number
	i32 3427035968, ; 494: 0xcc446b40 => xamarin/android/net/OldAndroidSSLSocketFactory
	i32 3467682067, ; 495: 0xceb0a113 => crc64720bb2db43a66fe9/FrameRenderer
	i32 3470311886, ; 496: 0xced8c1ce => crc643f46942d9dd1fff9/GenericAnimatorListener
	i32 3483202761, ; 497: 0xcf9d74c9 => crc643f46942d9dd1fff9/ObjectJavaBox_1
	i32 3490023890, ; 498: 0xd00589d2 => crc643f46942d9dd1fff9/ListViewAdapter
	i32 3497630135, ; 499: 0xd07999b7 => android/graphics/Paint$FontMetricsInt
	i32 3519931621, ; 500: 0xd1cde4e5 => java/net/URLConnection
	i32 3532650525, ; 501: 0xd28ff81d => android/text/style/WrapTogetherSpan
	i32 3541868701, ; 502: 0xd31ca09d => crc64ee486da937c010f4/LabelRenderer
	i32 3556970570, ; 503: 0xd403104a => android/app/ActionBar$TabListener
	i32 3558350616, ; 504: 0xd4181f18 => android/support/v4/app/TaskStackBuilder$SupportParentable
	i32 3565936068, ; 505: 0xd48bddc4 => crc643f46942d9dd1fff9/NavigationMenuRenderer
	i32 3569483764, ; 506: 0xd4c1fff4 => android/support/v4/view/ViewPropertyAnimatorUpdateListener
	i32 3576242387, ; 507: 0xd52920d3 => android/runtime/JavaProxyThrowable
	i32 3597654493, ; 508: 0xd66fd9dd => android/widget/AbsListView
	i32 3630284820, ; 509: 0xd861c014 => android/media/MediaPlayer
	i32 3634326192, ; 510: 0xd89f6ab0 => android/support/v4/view/ViewPager$PageTransformer
	i32 3643255480, ; 511: 0xd927aab8 => crc643f46942d9dd1fff9/BoxRenderer
	i32 3657143820, ; 512: 0xd9fb960c => crc643f46942d9dd1fff9/StepperRenderer_StepperListener
	i32 3665774669, ; 513: 0xda7f484d => android/view/LayoutInflater
	i32 3666243682, ; 514: 0xda867062 => java/lang/String
	i32 3666469336, ; 515: 0xda89e1d8 => crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer
	i32 3669061717, ; 516: 0xdab17055 => java/net/InetSocketAddress
	i32 3673444347, ; 517: 0xdaf44ffb => android/view/accessibility/AccessibilityEvent
	i32 3683323802, ; 518: 0xdb8b0f9a => mono/android/runtime/JavaObject
	i32 3684070586, ; 519: 0xdb9674ba => android/view/ActionProvider
	i32 3694742826, ; 520: 0xdc394d2a => crc648ebfd8ed4774273c/ScanEditorRenderer
	i32 3698769169, ; 521: 0xdc76bd11 => android/text/SpannableStringBuilder
	i32 3701331277, ; 522: 0xdc9dd54d => android/graphics/Paint$Style
	i32 3702230909, ; 523: 0xdcab8f7d => java/lang/Double
	i32 3702422870, ; 524: 0xdcae7d56 => android/view/ViewTreeObserver$OnPreDrawListener
	i32 3711529970, ; 525: 0xdd3973f2 => android/text/style/MetricAffectingSpan
	i32 3715861037, ; 526: 0xdd7b8a2d => android/os/Build$VERSION
	i32 3721088312, ; 527: 0xddcb4d38 => android/text/NoCopySpan
	i32 3722843854, ; 528: 0xdde616ce => javax/net/SocketFactory
	i32 3722942310, ; 529: 0xdde79766 => android/text/method/NumberKeyListener
	i32 3726680736, ; 530: 0xde20a2a0 => java/net/ProtocolException
	i32 3728432962, ; 531: 0xde3b5f42 => android/support/v4/content/Loader$OnLoadCompleteListener
	i32 3733536092, ; 532: 0xde893d5c => android/support/v4/widget/SwipeRefreshLayout$OnChildScrollUpCallback
	i32 3734205073, ; 533: 0xde937291 => android/support/v4/view/ActionProvider$VisibilityListener
	i32 3738171500, ; 534: 0xdecff86c => android/webkit/WebChromeClient
	i32 3745708392, ; 535: 0xdf42f968 => crc643f46942d9dd1fff9/EntryCellEditText
	i32 3746020715, ; 536: 0xdf47bd6b => android/graphics/drawable/Drawable$Callback
	i32 3746563526, ; 537: 0xdf5005c6 => crc643f46942d9dd1fff9/FrameRenderer_FrameDrawable
	i32 3759929762, ; 538: 0xe01bf9a2 => android/graphics/Bitmap
	i32 3763853270, ; 539: 0xe057d7d6 => android/view/Window
	i32 3781075776, ; 540: 0xe15ea340 => crc643f46942d9dd1fff9/FormsApplicationActivity
	i32 3781646898, ; 541: 0xe1675a32 => android/support/design/widget/BottomNavigationView
	i32 3785442785, ; 542: 0xe1a145e1 => crc64720bb2db43a66fe9/MasterDetailPageRenderer
	i32 3795789659, ; 543: 0xe23f275b => crc643f46942d9dd1fff9/DatePickerRenderer
	i32 3810191701, ; 544: 0xe31ae955 => crc643f46942d9dd1fff9/NavigationRenderer
	i32 3811192762, ; 545: 0xe32a2fba => android/content/res/TypedArray
	i32 3823421666, ; 546: 0xe3e4c8e2 => android/net/Uri
	i32 3825439658, ; 547: 0xe40393aa => crc643f46942d9dd1fff9/OpenGLViewRenderer_Renderer
	i32 3846932217, ; 548: 0xe54b86f9 => javax/net/ssl/X509TrustManager
	i32 3861854324, ; 549: 0xe62f3874 => android/support/v7/app/ActionBarDrawerToggle$Delegate
	i32 3865571169, ; 550: 0xe667ef61 => android/content/res/XmlResourceParser
	i32 3872328841, ; 551: 0xe6cf0c89 => android/view/animation/BaseInterpolator
	i32 3872825215, ; 552: 0xe6d69f7f => android/graphics/ColorFilter
	i32 3882570516, ; 553: 0xe76b5314 => java/lang/Class
	i32 3884080736, ; 554: 0xe7825e60 => android/webkit/WebView
	i32 3889059793, ; 555: 0xe7ce57d1 => android/support/v4/widget/DrawerLayout$LayoutParams
	i32 3893629743, ; 556: 0xe814132f => android/view/LayoutInflater$Factory2
	i32 3896288302, ; 557: 0xe83ca42e => android/widget/ImageView
	i32 3900328001, ; 558: 0xe87a4841 => android/graphics/Typeface
	i32 3900581163, ; 559: 0xe87e252b => java/io/InputStream
	i32 3901837667, ; 560: 0xe8915163 => android/text/InputFilter
	i32 3906036904, ; 561: 0xe8d164a8 => android/webkit/ValueCallback
	i32 3912451735, ; 562: 0xe9334697 => java/security/KeyStore
	i32 3919758710, ; 563: 0xe9a2c576 => android/view/ContextMenu
	i32 3922608828, ; 564: 0xe9ce42bc => android/text/method/MetaKeyKeyListener
	i32 3923082251, ; 565: 0xe9d57c0b => crc643f46942d9dd1fff9/SliderRenderer
	i32 3926239517, ; 566: 0xea05a91d => android/app/TimePickerDialog$OnTimeSetListener
	i32 3931120197, ; 567: 0xea502245 => mono/android/content/DialogInterface_OnClickListenerImplementor
	i32 3933245259, ; 568: 0xea708f4b => android/graphics/Rect
	i32 3955998141, ; 569: 0xebcbbdbd => crc643f46942d9dd1fff9/LocalizedDigitsKeyListener
	i32 3960999444, ; 570: 0xec180e14 => android/widget/Toast
	i32 3969984744, ; 571: 0xeca128e8 => mono/android/runtime/InputStreamAdapter
	i32 3975001277, ; 572: 0xecedb4bd => javax/net/ssl/SSLSocketFactory
	i32 3982675394, ; 573: 0xed62cdc2 => android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener
	i32 3991247329, ; 574: 0xede599e1 => android/support/v7/app/ActionBar
	i32 3993327007, ; 575: 0xee05559f => android/content/ContextWrapper
	i32 3995406185, ; 576: 0xee250f69 => android/graphics/Canvas
	i32 4020308495, ; 577: 0xefa10a0f => java/lang/Error
	i32 4020474290, ; 578: 0xefa391b2 => android/support/v4/app/SharedElementCallback
	i32 4030673356, ; 579: 0xf03f31cc => android/app/Dialog
	i32 4030975555, ; 580: 0xf043ce43 => android/view/animation/Interpolator
	i32 4036255896, ; 581: 0xf0946098 => mono/android/support/v4/widget/SwipeRefreshLayout_OnRefreshListenerImplementor
	i32 4038157564, ; 582: 0xf0b164fc => android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher
	i32 4040218938, ; 583: 0xf0d0d93a => android/graphics/drawable/RippleDrawable
	i32 4044525863, ; 584: 0xf1129127 => android/content/ComponentCallbacks2
	i32 4051772911, ; 585: 0xf18125ef => android/content/Context
	i32 4056674536, ; 586: 0xf1cbf0e8 => java/lang/NoClassDefFoundError
	i32 4058436930, ; 587: 0xf1e6d542 => android/view/GestureDetector
	i32 4059763550, ; 588: 0xf1fb135e => android/os/StrictMode$VmPolicy$Builder
	i32 4066255456, ; 589: 0xf25e2260 => android/util/SparseArray
	i32 4085114189, ; 590: 0xf37de54d => android/view/SurfaceView
	i32 4088038176, ; 591: 0xf3aa8320 => java/io/Reader
	i32 4089459037, ; 592: 0xf3c0315d => java/nio/Buffer
	i32 4098107575, ; 593: 0xf44428b7 => mono/android/view/View_OnClickListenerImplementor
	i32 4101363546, ; 594: 0xf475d75a => java/io/Writer
	i32 4104288849, ; 595: 0xf4a27a51 => android/text/TextUtils$TruncateAt
	i32 4113079587, ; 596: 0xf5289d23 => mono/android/app/TabEventDispatcher
	i32 4117799665, ; 597: 0xf570a2f1 => android/view/SurfaceHolder$Callback
	i32 4118878202, ; 598: 0xf58117fa => android/os/Looper
	i32 4129663376, ; 599: 0xf625a990 => android/support/v4/widget/AutoSizeableTextView
	i32 4132928654, ; 600: 0xf6577c8e => crc643f46942d9dd1fff9/EditorEditText
	i32 4148593869, ; 601: 0xf74684cd => javax/net/ssl/TrustManagerFactory
	i32 4157808693, ; 602: 0xf7d32035 => java/io/IOException
	i32 4163633888, ; 603: 0xf82c02e0 => crc643f46942d9dd1fff9/ButtonRenderer_ButtonTouchListener
	i32 4163895590, ; 604: 0xf8300126 => android/support/v7/app/ActionBar$TabListener
	i32 4166165970, ; 605: 0xf852a5d2 => android/text/TextWatcher
	i32 4211567724, ; 606: 0xfb076c6c => android/view/ScaleGestureDetector$OnScaleGestureListener
	i32 4232707919, ; 607: 0xfc49ff4f => java/util/HashSet
	i32 4236355936, ; 608: 0xfc81a960 => android/view/ViewTreeObserver$OnGlobalLayoutListener
	i32 4236724582, ; 609: 0xfc874966 => android/os/Parcelable
	i32 4237386260, ; 610: 0xfc916214 => android/view/MenuItem$OnMenuItemClickListener
	i32 4248811056, ; 611: 0xfd3fb630 => android/view/Menu
	i32 4250248733, ; 612: 0xfd55a61d => crc64ee486da937c010f4/ImageRenderer
	i32 4250357225, ; 613: 0xfd574de9 => crc643f46942d9dd1fff9/Platform_DefaultRenderer
	i32 4250389251, ; 614: 0xfd57cb03 => android/text/style/BackgroundColorSpan
	i32 4253863534, ; 615: 0xfd8cce6e => android/support/v4/widget/DrawerLayout
	i32 4260025083, ; 616: 0xfdead2fb => android/os/StrictMode
	i32 4261200319, ; 617: 0xfdfcc1bf => crc64720bb2db43a66fe9/FormsViewPager
	i32 4266941483, ; 618: 0xfe545c2b => android/support/v7/widget/Toolbar$OnMenuItemClickListener
	i32 4271127433, ; 619: 0xfe943b89 => android/graphics/PorterDuff
	i32 4277523103, ; 620: 0xfef5d29f => java/io/Closeable
	i32 4278949669, ; 621: 0xff0b9725 => android/widget/CompoundButton$OnCheckedChangeListener
	i32 4283932092, ; 622: 0xff579dbc => android/support/v4/app/ActivityCompat
	i32 4293803975 ; 623: 0xffee3fc7 => android/arch/lifecycle/Lifecycle
], align 4

; java_type_names
@__java_type_names.0 = internal constant [54 x i8] c"crc643f46942d9dd1fff9/PageExtensions_EmbeddedFragment\00", align 1
@__java_type_names.1 = internal constant [61 x i8] c"crc643f46942d9dd1fff9/PageExtensions_EmbeddedSupportFragment\00", align 1
@__java_type_names.2 = internal constant [34 x i8] c"crc643f46942d9dd1fff9/CellAdapter\00", align 1
@__java_type_names.3 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/EntryCellEditText\00", align 1
@__java_type_names.4 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryCellView\00", align 1
@__java_type_names.5 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SwitchCellView\00", align 1
@__java_type_names.6 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/FormsAppCompatActivity\00", align 1
@__java_type_names.7 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ImageButtonRenderer\00", align 1
@__java_type_names.8 = internal constant [62 x i8] c"crc643f46942d9dd1fff9/GestureManager_TapAndPanGestureDetector\00", align 1
@__java_type_names.9 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/FormsApplicationActivity\00", align 1
@__java_type_names.10 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/AndroidActivity\00", align 1
@__java_type_names.11 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/BaseCellView\00", align 1
@__java_type_names.12 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/CellRenderer_RendererHolder\00", align 1
@__java_type_names.13 = internal constant [52 x i8] c"crc643f46942d9dd1fff9/TextCellRenderer_TextCellView\00", align 1
@__java_type_names.14 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer\00", align 1
@__java_type_names.15 = internal constant [82 x i8] c"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer_LongPressGestureListener\00", align 1
@__java_type_names.16 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/FormsWebViewClient\00", align 1
@__java_type_names.17 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/InnerGestureListener\00", align 1
@__java_type_names.18 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/InnerScaleListener\00", align 1
@__java_type_names.19 = internal constant [48 x i8] c"crc643f46942d9dd1fff9/NativeViewWrapperRenderer\00", align 1
@__java_type_names.20 = internal constant [53 x i8] c"crc643f46942d9dd1fff9/PowerSaveModeBroadcastReceiver\00", align 1
@__java_type_names.21 = internal constant [44 x i8] c"crc643f46942d9dd1fff9/AHorizontalScrollView\00", align 1
@__java_type_names.22 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/BorderDrawable\00", align 1
@__java_type_names.23 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer\00", align 1
@__java_type_names.24 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer_ButtonClickListener\00", align 1
@__java_type_names.25 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/ButtonRenderer_ButtonTouchListener\00", align 1
@__java_type_names.26 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/ConditionalFocusLayout\00", align 1
@__java_type_names.27 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FormsEditText\00", align 1
@__java_type_names.28 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryEditText\00", align 1
@__java_type_names.29 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/EditorEditText\00", align 1
@__java_type_names.30 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_FontSpan\00", align 1
@__java_type_names.31 = internal constant [67 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_TextDecorationSpan\00", align 1
@__java_type_names.32 = internal constant [63 x i8] c"crc643f46942d9dd1fff9/FormattedStringExtensions_LineHeightSpan\00", align 1
@__java_type_names.33 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/FormsImageView\00", align 1
@__java_type_names.34 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FormsTextView\00", align 1
@__java_type_names.35 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/FormsWebChromeClient\00", align 1
@__java_type_names.36 = internal constant [46 x i8] c"crc643f46942d9dd1fff9/GenericAnimatorListener\00", align 1
@__java_type_names.37 = internal constant [49 x i8] c"crc643f46942d9dd1fff9/LocalizedDigitsKeyListener\00", align 1
@__java_type_names.38 = internal constant [44 x i8] c"crc643f46942d9dd1fff9/MasterDetailContainer\00", align 1
@__java_type_names.39 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/PageContainer\00", align 1
@__java_type_names.40 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ScrollViewContainer\00", align 1
@__java_type_names.41 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/ToolbarButton\00", align 1
@__java_type_names.42 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/ToolbarImageButton\00", align 1
@__java_type_names.43 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/GenericMenuClickListener\00", align 1
@__java_type_names.44 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/ViewRenderer\00", align 1
@__java_type_names.45 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/ViewRenderer_2\00", align 1
@__java_type_names.46 = internal constant [47 x i8] c"crc643f46942d9dd1fff9/Platform_DefaultRenderer\00", align 1
@__java_type_names.47 = internal constant [39 x i8] c"crc643f46942d9dd1fff9/PlatformRenderer\00", align 1
@__java_type_names.48 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ActionSheetRenderer\00", align 1
@__java_type_names.49 = internal constant [48 x i8] c"crc643f46942d9dd1fff9/ActivityIndicatorRenderer\00", align 1
@__java_type_names.50 = internal constant [34 x i8] c"crc643f46942d9dd1fff9/BoxRenderer\00", align 1
@__java_type_names.51 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/CarouselPageRenderer\00", align 1
@__java_type_names.52 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/DatePickerRenderer\00", align 1
@__java_type_names.53 = internal constant [63 x i8] c"crc643f46942d9dd1fff9/DatePickerRenderer_TextFieldClickHandler\00", align 1
@__java_type_names.54 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/EditorRenderer\00", align 1
@__java_type_names.55 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/EntryRenderer\00", align 1
@__java_type_names.56 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/FrameRenderer\00", align 1
@__java_type_names.57 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/FrameRenderer_FrameDrawable\00", align 1
@__java_type_names.58 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/ImageRenderer\00", align 1
@__java_type_names.59 = internal constant [36 x i8] c"crc643f46942d9dd1fff9/LabelRenderer\00", align 1
@__java_type_names.60 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/ListViewAdapter\00", align 1
@__java_type_names.61 = internal constant [39 x i8] c"crc643f46942d9dd1fff9/ListViewRenderer\00", align 1
@__java_type_names.62 = internal constant [49 x i8] c"crc643f46942d9dd1fff9/ListViewRenderer_Container\00", align 1
@__java_type_names.63 = internal constant [43 x i8] c"crc643f46942d9dd1fff9/MasterDetailRenderer\00", align 1
@__java_type_names.64 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer\00", align 1
@__java_type_names.65 = internal constant [61 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuElementView\00", align 1
@__java_type_names.66 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/NavigationMenuRenderer_MenuAdapter\00", align 1
@__java_type_names.67 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/NavigationRenderer\00", align 1
@__java_type_names.68 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/ObjectJavaBox_1\00", align 1
@__java_type_names.69 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/CarouselPageAdapter\00", align 1
@__java_type_names.70 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/PageRenderer\00", align 1
@__java_type_names.71 = internal constant [42 x i8] c"crc643f46942d9dd1fff9/ProgressBarRenderer\00", align 1
@__java_type_names.72 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/ScrollViewRenderer\00", align 1
@__java_type_names.73 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/SearchBarRenderer\00", align 1
@__java_type_names.74 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SliderRenderer\00", align 1
@__java_type_names.75 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/StepperRenderer\00", align 1
@__java_type_names.76 = internal constant [54 x i8] c"crc643f46942d9dd1fff9/StepperRenderer_StepperListener\00", align 1
@__java_type_names.77 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/SwitchRenderer\00", align 1
@__java_type_names.78 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/TabbedRenderer\00", align 1
@__java_type_names.79 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/TableViewModelRenderer\00", align 1
@__java_type_names.80 = internal constant [40 x i8] c"crc643f46942d9dd1fff9/TableViewRenderer\00", align 1
@__java_type_names.81 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/TimePickerRenderer\00", align 1
@__java_type_names.82 = internal constant [60 x i8] c"crc643f46942d9dd1fff9/TimePickerRenderer_TimePickerListener\00", align 1
@__java_type_names.83 = internal constant [38 x i8] c"crc643f46942d9dd1fff9/WebViewRenderer\00", align 1
@__java_type_names.84 = internal constant [55 x i8] c"crc643f46942d9dd1fff9/WebViewRenderer_JavascriptResult\00", align 1
@__java_type_names.85 = internal constant [46 x i8] c"crc643f46942d9dd1fff9/VisualElementRenderer_1\00", align 1
@__java_type_names.86 = internal constant [57 x i8] c"crc643f46942d9dd1fff9/VisualElementTracker_AttachTracker\00", align 1
@__java_type_names.87 = internal constant [37 x i8] c"crc643f46942d9dd1fff9/PickerRenderer\00", align 1
@__java_type_names.88 = internal constant [52 x i8] c"crc643f46942d9dd1fff9/PickerRenderer_PickerListener\00", align 1
@__java_type_names.89 = internal constant [41 x i8] c"crc643f46942d9dd1fff9/OpenGLViewRenderer\00", align 1
@__java_type_names.90 = internal constant [50 x i8] c"crc643f46942d9dd1fff9/OpenGLViewRenderer_Renderer\00", align 1
@__java_type_names.91 = internal constant [35 x i8] c"crc643f46942d9dd1fff9/FormsSeekBar\00", align 1
@__java_type_names.92 = internal constant [45 x i8] c"crc643f46942d9dd1fff9/GroupedListViewAdapter\00", align 1
@__java_type_names.93 = internal constant [37 x i8] c"crc64ee486da937c010f4/ButtonRenderer\00", align 1
@__java_type_names.94 = internal constant [36 x i8] c"crc64ee486da937c010f4/FrameRenderer\00", align 1
@__java_type_names.95 = internal constant [36 x i8] c"crc64ee486da937c010f4/LabelRenderer\00", align 1
@__java_type_names.96 = internal constant [36 x i8] c"crc64ee486da937c010f4/ImageRenderer\00", align 1
@__java_type_names.97 = internal constant [36 x i8] c"crc64720bb2db43a66fe9/FrameRenderer\00", align 1
@__java_type_names.98 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/FormsViewPager\00", align 1
@__java_type_names.99 = internal constant [40 x i8] c"crc64720bb2db43a66fe9/FragmentContainer\00", align 1
@__java_type_names.100 = internal constant [44 x i8] c"crc64720bb2db43a66fe9/MasterDetailContainer\00", align 1
@__java_type_names.101 = internal constant [46 x i8] c"crc64720bb2db43a66fe9/Platform_ModalContainer\00", align 1
@__java_type_names.102 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer\00", align 1
@__java_type_names.103 = internal constant [57 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer_ButtonClickListener\00", align 1
@__java_type_names.104 = internal constant [57 x i8] c"crc64720bb2db43a66fe9/ButtonRenderer_ButtonTouchListener\00", align 1
@__java_type_names.105 = internal constant [47 x i8] c"crc64720bb2db43a66fe9/MasterDetailPageRenderer\00", align 1
@__java_type_names.106 = internal constant [45 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer\00", align 1
@__java_type_names.107 = internal constant [59 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_ClickListener\00", align 1
@__java_type_names.108 = internal constant [55 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_Container\00", align 1
@__java_type_names.109 = internal constant [71 x i8] c"crc64720bb2db43a66fe9/NavigationPageRenderer_DrawerMultiplexedListener\00", align 1
@__java_type_names.110 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/SwitchRenderer\00", align 1
@__java_type_names.111 = internal constant [41 x i8] c"crc64720bb2db43a66fe9/TabbedPageRenderer\00", align 1
@__java_type_names.112 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/PickerRenderer\00", align 1
@__java_type_names.113 = internal constant [52 x i8] c"crc64720bb2db43a66fe9/PickerRenderer_PickerListener\00", align 1
@__java_type_names.114 = internal constant [37 x i8] c"crc64720bb2db43a66fe9/ViewRenderer_2\00", align 1
@__java_type_names.115 = internal constant [43 x i8] c"crc64720bb2db43a66fe9/CarouselPageRenderer\00", align 1
@__java_type_names.116 = internal constant [50 x i8] c"crc64720bb2db43a66fe9/FormsFragmentPagerAdapter_1\00", align 1
@__java_type_names.117 = internal constant [47 x i8] c"android/support/v4/widget/AutoSizeableTextView\00", align 1
@__java_type_names.118 = internal constant [50 x i8] c"android/support/v4/widget/TintableImageSourceView\00", align 1
@__java_type_names.119 = internal constant [41 x i8] c"android/support/v4/widget/TextViewCompat\00", align 1
@__java_type_names.120 = internal constant [39 x i8] c"android/support/v4/view/ActionProvider\00", align 1
@__java_type_names.121 = internal constant [63 x i8] c"android/support/v4/view/ActionProvider$SubUiVisibilityListener\00", align 1
@__java_type_names.122 = internal constant [79 x i8] c"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor\00", align 1
@__java_type_names.123 = internal constant [58 x i8] c"android/support/v4/view/ActionProvider$VisibilityListener\00", align 1
@__java_type_names.124 = internal constant [74 x i8] c"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor\00", align 1
@__java_type_names.125 = internal constant [45 x i8] c"android/support/v4/view/NestedScrollingChild\00", align 1
@__java_type_names.126 = internal constant [46 x i8] c"android/support/v4/view/NestedScrollingParent\00", align 1
@__java_type_names.127 = internal constant [47 x i8] c"android/support/v4/view/TintableBackgroundView\00", align 1
@__java_type_names.128 = internal constant [53 x i8] c"android/support/v4/view/ViewPropertyAnimatorListener\00", align 1
@__java_type_names.129 = internal constant [59 x i8] c"android/support/v4/view/ViewPropertyAnimatorUpdateListener\00", align 1
@__java_type_names.130 = internal constant [51 x i8] c"android/support/v4/view/ScaleGestureDetectorCompat\00", align 1
@__java_type_names.131 = internal constant [51 x i8] c"android/support/v4/view/ViewPropertyAnimatorCompat\00", align 1
@__java_type_names.132 = internal constant [45 x i8] c"android/support/v4/internal/view/SupportMenu\00", align 1
@__java_type_names.133 = internal constant [49 x i8] c"android/support/v4/internal/view/SupportMenuItem\00", align 1
@__java_type_names.134 = internal constant [52 x i8] c"android/support/v4/graphics/drawable/DrawableCompat\00", align 1
@__java_type_names.135 = internal constant [41 x i8] c"android/support/v4/content/ContextCompat\00", align 1
@__java_type_names.136 = internal constant [38 x i8] c"android/support/v4/app/ActivityCompat\00", align 1
@__java_type_names.137 = internal constant [73 x i8] c"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback\00", align 1
@__java_type_names.138 = internal constant [63 x i8] c"android/support/v4/app/ActivityCompat$PermissionCompatDelegate\00", align 1
@__java_type_names.139 = internal constant [77 x i8] c"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator\00", align 1
@__java_type_names.140 = internal constant [45 x i8] c"android/support/v4/app/SharedElementCallback\00", align 1
@__java_type_names.141 = internal constant [75 x i8] c"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener\00", align 1
@__java_type_names.142 = internal constant [33 x i8] c"android/arch/lifecycle/Lifecycle\00", align 1
@__java_type_names.143 = internal constant [39 x i8] c"android/arch/lifecycle/Lifecycle$State\00", align 1
@__java_type_names.144 = internal constant [41 x i8] c"android/arch/lifecycle/LifecycleObserver\00", align 1
@__java_type_names.145 = internal constant [38 x i8] c"android/arch/lifecycle/LifecycleOwner\00", align 1
@__java_type_names.146 = internal constant [45 x i8] c"android/support/v4/app/ActionBarDrawerToggle\00", align 1
@__java_type_names.147 = internal constant [37 x i8] c"android/support/v4/view/PagerAdapter\00", align 1
@__java_type_names.148 = internal constant [34 x i8] c"android/support/v4/view/ViewPager\00", align 1
@__java_type_names.149 = internal constant [58 x i8] c"android/support/v4/view/ViewPager$OnAdapterChangeListener\00", align 1
@__java_type_names.150 = internal constant [74 x i8] c"mono/android/support/v4/view/ViewPager_OnAdapterChangeListenerImplementor\00", align 1
@__java_type_names.151 = internal constant [55 x i8] c"android/support/v4/view/ViewPager$OnPageChangeListener\00", align 1
@__java_type_names.152 = internal constant [71 x i8] c"mono/android/support/v4/view/ViewPager_OnPageChangeListenerImplementor\00", align 1
@__java_type_names.153 = internal constant [50 x i8] c"android/support/v4/view/ViewPager$PageTransformer\00", align 1
@__java_type_names.154 = internal constant [45 x i8] c"android/support/v4/widget/SwipeRefreshLayout\00", align 1
@__java_type_names.155 = internal constant [69 x i8] c"android/support/v4/widget/SwipeRefreshLayout$OnChildScrollUpCallback\00", align 1
@__java_type_names.156 = internal constant [63 x i8] c"android/support/v4/widget/SwipeRefreshLayout$OnRefreshListener\00", align 1
@__java_type_names.157 = internal constant [79 x i8] c"mono/android/support/v4/widget/SwipeRefreshLayout_OnRefreshListenerImplementor\00", align 1
@__java_type_names.158 = internal constant [39 x i8] c"android/support/v4/widget/DrawerLayout\00", align 1
@__java_type_names.159 = internal constant [54 x i8] c"android/support/v4/widget/DrawerLayout$DrawerListener\00", align 1
@__java_type_names.160 = internal constant [70 x i8] c"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor\00", align 1
@__java_type_names.161 = internal constant [52 x i8] c"android/support/v4/widget/DrawerLayout$LayoutParams\00", align 1
@__java_type_names.162 = internal constant [35 x i8] c"android/support/v7/widget/CardView\00", align 1
@__java_type_names.163 = internal constant [57 x i8] c"android/support/v7/graphics/drawable/DrawerArrowDrawable\00", align 1
@__java_type_names.164 = internal constant [50 x i8] c"android/support/v7/content/res/AppCompatResources\00", align 1
@__java_type_names.165 = internal constant [35 x i8] c"android/support/v7/view/ActionMode\00", align 1
@__java_type_names.166 = internal constant [44 x i8] c"android/support/v7/view/ActionMode$Callback\00", align 1
@__java_type_names.167 = internal constant [52 x i8] c"android/support/v7/view/menu/MenuPresenter$Callback\00", align 1
@__java_type_names.168 = internal constant [43 x i8] c"android/support/v7/view/menu/MenuPresenter\00", align 1
@__java_type_names.169 = internal constant [38 x i8] c"android/support/v7/view/menu/MenuView\00", align 1
@__java_type_names.170 = internal constant [41 x i8] c"android/support/v7/view/menu/MenuBuilder\00", align 1
@__java_type_names.171 = internal constant [50 x i8] c"android/support/v7/view/menu/MenuBuilder$Callback\00", align 1
@__java_type_names.172 = internal constant [42 x i8] c"android/support/v7/view/menu/MenuItemImpl\00", align 1
@__java_type_names.173 = internal constant [44 x i8] c"android/support/v7/view/menu/SubMenuBuilder\00", align 1
@__java_type_names.174 = internal constant [34 x i8] c"android/support/v7/widget/Toolbar\00", align 1
@__java_type_names.175 = internal constant [67 x i8] c"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher\00", align 1
@__java_type_names.176 = internal constant [58 x i8] c"android/support/v7/widget/Toolbar$OnMenuItemClickListener\00", align 1
@__java_type_names.177 = internal constant [74 x i8] c"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor\00", align 1
@__java_type_names.178 = internal constant [42 x i8] c"android/support/v7/widget/AppCompatButton\00", align 1
@__java_type_names.179 = internal constant [47 x i8] c"android/support/v7/widget/AppCompatImageButton\00", align 1
@__java_type_names.180 = internal constant [39 x i8] c"android/support/v7/widget/DecorToolbar\00", align 1
@__java_type_names.181 = internal constant [52 x i8] c"android/support/v7/widget/ScrollingTabContainerView\00", align 1
@__java_type_names.182 = internal constant [75 x i8] c"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener\00", align 1
@__java_type_names.183 = internal constant [39 x i8] c"android/support/v7/widget/SwitchCompat\00", align 1
@__java_type_names.184 = internal constant [33 x i8] c"android/support/v7/app/ActionBar\00", align 1
@__java_type_names.185 = internal constant [46 x i8] c"android/support/v7/app/ActionBar$LayoutParams\00", align 1
@__java_type_names.186 = internal constant [58 x i8] c"android/support/v7/app/ActionBar$OnMenuVisibilityListener\00", align 1
@__java_type_names.187 = internal constant [74 x i8] c"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor\00", align 1
@__java_type_names.188 = internal constant [54 x i8] c"android/support/v7/app/ActionBar$OnNavigationListener\00", align 1
@__java_type_names.189 = internal constant [37 x i8] c"android/support/v7/app/ActionBar$Tab\00", align 1
@__java_type_names.190 = internal constant [45 x i8] c"android/support/v7/app/ActionBar$TabListener\00", align 1
@__java_type_names.191 = internal constant [45 x i8] c"android/support/v7/app/ActionBarDrawerToggle\00", align 1
@__java_type_names.192 = internal constant [54 x i8] c"android/support/v7/app/ActionBarDrawerToggle$Delegate\00", align 1
@__java_type_names.193 = internal constant [62 x i8] c"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider\00", align 1
@__java_type_names.194 = internal constant [41 x i8] c"android/support/v7/app/AppCompatActivity\00", align 1
@__java_type_names.195 = internal constant [41 x i8] c"android/support/v7/app/AppCompatDelegate\00", align 1
@__java_type_names.196 = internal constant [41 x i8] c"android/support/v7/app/AppCompatCallback\00", align 1
@__java_type_names.197 = internal constant [35 x i8] c"crc64dbeead12be5aee1d/MainActivity\00", align 1
@__java_type_names.198 = internal constant [41 x i8] c"crc648ebfd8ed4774273c/ScanEditorRenderer\00", align 1
@__java_type_names.199 = internal constant [47 x i8] c"xamarin/android/net/OldAndroidSSLSocketFactory\00", align 1
@__java_type_names.200 = internal constant [29 x i8] c"org/xmlpull/v1/XmlPullParser\00", align 1
@__java_type_names.201 = internal constant [38 x i8] c"org/xmlpull/v1/XmlPullParserException\00", align 1
@__java_type_names.202 = internal constant [32 x i8] c"javax/security/cert/Certificate\00", align 1
@__java_type_names.203 = internal constant [36 x i8] c"javax/security/cert/X509Certificate\00", align 1
@__java_type_names.204 = internal constant [24 x i8] c"javax/net/SocketFactory\00", align 1
@__java_type_names.205 = internal constant [33 x i8] c"javax/net/ssl/HttpsURLConnection\00", align 1
@__java_type_names.206 = internal constant [31 x i8] c"javax/net/ssl/HostnameVerifier\00", align 1
@__java_type_names.207 = internal constant [25 x i8] c"javax/net/ssl/KeyManager\00", align 1
@__java_type_names.208 = internal constant [25 x i8] c"javax/net/ssl/SSLSession\00", align 1
@__java_type_names.209 = internal constant [32 x i8] c"javax/net/ssl/SSLSessionContext\00", align 1
@__java_type_names.210 = internal constant [27 x i8] c"javax/net/ssl/TrustManager\00", align 1
@__java_type_names.211 = internal constant [31 x i8] c"javax/net/ssl/X509TrustManager\00", align 1
@__java_type_names.212 = internal constant [32 x i8] c"javax/net/ssl/KeyManagerFactory\00", align 1
@__java_type_names.213 = internal constant [25 x i8] c"javax/net/ssl/SSLContext\00", align 1
@__java_type_names.214 = internal constant [31 x i8] c"javax/net/ssl/SSLSocketFactory\00", align 1
@__java_type_names.215 = internal constant [34 x i8] c"javax/net/ssl/TrustManagerFactory\00", align 1
@__java_type_names.216 = internal constant [39 x i8] c"javax/microedition/khronos/opengles/GL\00", align 1
@__java_type_names.217 = internal constant [41 x i8] c"javax/microedition/khronos/opengles/GL10\00", align 1
@__java_type_names.218 = internal constant [41 x i8] c"javax/microedition/khronos/egl/EGLConfig\00", align 1
@__java_type_names.219 = internal constant [29 x i8] c"android/webkit/ValueCallback\00", align 1
@__java_type_names.220 = internal constant [34 x i8] c"android/webkit/WebResourceRequest\00", align 1
@__java_type_names.221 = internal constant [31 x i8] c"android/webkit/WebChromeClient\00", align 1
@__java_type_names.222 = internal constant [49 x i8] c"android/webkit/WebChromeClient$FileChooserParams\00", align 1
@__java_type_names.223 = internal constant [32 x i8] c"android/webkit/WebResourceError\00", align 1
@__java_type_names.224 = internal constant [27 x i8] c"android/webkit/WebSettings\00", align 1
@__java_type_names.225 = internal constant [23 x i8] c"android/webkit/WebView\00", align 1
@__java_type_names.226 = internal constant [29 x i8] c"android/webkit/WebViewClient\00", align 1
@__java_type_names.227 = internal constant [33 x i8] c"android/database/DataSetObserver\00", align 1
@__java_type_names.228 = internal constant [27 x i8] c"android/widget/AbsListView\00", align 1
@__java_type_names.229 = internal constant [27 x i8] c"android/widget/AdapterView\00", align 1
@__java_type_names.230 = internal constant [47 x i8] c"android/widget/AdapterView$OnItemClickListener\00", align 1
@__java_type_names.231 = internal constant [51 x i8] c"android/widget/AdapterView$OnItemLongClickListener\00", align 1
@__java_type_names.232 = internal constant [50 x i8] c"android/widget/AdapterView$OnItemSelectedListener\00", align 1
@__java_type_names.233 = internal constant [27 x i8] c"android/widget/BaseAdapter\00", align 1
@__java_type_names.234 = internal constant [26 x i8] c"android/widget/DatePicker\00", align 1
@__java_type_names.235 = internal constant [48 x i8] c"android/widget/DatePicker$OnDateChangedListener\00", align 1
@__java_type_names.236 = internal constant [24 x i8] c"android/widget/TextView\00", align 1
@__java_type_names.237 = internal constant [47 x i8] c"android/widget/TextView$OnEditorActionListener\00", align 1
@__java_type_names.238 = internal constant [30 x i8] c"android/widget/AbsoluteLayout\00", align 1
@__java_type_names.239 = internal constant [43 x i8] c"android/widget/AbsoluteLayout$LayoutParams\00", align 1
@__java_type_names.240 = internal constant [26 x i8] c"android/widget/AbsSeekBar\00", align 1
@__java_type_names.241 = internal constant [22 x i8] c"android/widget/Button\00", align 1
@__java_type_names.242 = internal constant [30 x i8] c"android/widget/CompoundButton\00", align 1
@__java_type_names.243 = internal constant [54 x i8] c"android/widget/CompoundButton$OnCheckedChangeListener\00", align 1
@__java_type_names.244 = internal constant [24 x i8] c"android/widget/EditText\00", align 1
@__java_type_names.245 = internal constant [22 x i8] c"android/widget/Filter\00", align 1
@__java_type_names.246 = internal constant [37 x i8] c"android/widget/Filter$FilterListener\00", align 1
@__java_type_names.247 = internal constant [27 x i8] c"android/widget/FrameLayout\00", align 1
@__java_type_names.248 = internal constant [24 x i8] c"android/widget/GridView\00", align 1
@__java_type_names.249 = internal constant [36 x i8] c"android/widget/HorizontalScrollView\00", align 1
@__java_type_names.250 = internal constant [23 x i8] c"android/widget/Adapter\00", align 1
@__java_type_names.251 = internal constant [25 x i8] c"android/widget/Checkable\00", align 1
@__java_type_names.252 = internal constant [27 x i8] c"android/widget/ListAdapter\00", align 1
@__java_type_names.253 = internal constant [27 x i8] c"android/widget/ImageButton\00", align 1
@__java_type_names.254 = internal constant [25 x i8] c"android/widget/ImageView\00", align 1
@__java_type_names.255 = internal constant [35 x i8] c"android/widget/ImageView$ScaleType\00", align 1
@__java_type_names.256 = internal constant [30 x i8] c"android/widget/SectionIndexer\00", align 1
@__java_type_names.257 = internal constant [30 x i8] c"android/widget/SpinnerAdapter\00", align 1
@__java_type_names.258 = internal constant [28 x i8] c"android/widget/LinearLayout\00", align 1
@__java_type_names.259 = internal constant [41 x i8] c"android/widget/LinearLayout$LayoutParams\00", align 1
@__java_type_names.260 = internal constant [24 x i8] c"android/widget/ListView\00", align 1
@__java_type_names.261 = internal constant [28 x i8] c"android/widget/NumberPicker\00", align 1
@__java_type_names.262 = internal constant [27 x i8] c"android/widget/ProgressBar\00", align 1
@__java_type_names.263 = internal constant [30 x i8] c"android/widget/RelativeLayout\00", align 1
@__java_type_names.264 = internal constant [43 x i8] c"android/widget/RelativeLayout$LayoutParams\00", align 1
@__java_type_names.265 = internal constant [26 x i8] c"android/widget/ScrollView\00", align 1
@__java_type_names.266 = internal constant [26 x i8] c"android/widget/SearchView\00", align 1
@__java_type_names.267 = internal constant [46 x i8] c"android/widget/SearchView$OnQueryTextListener\00", align 1
@__java_type_names.268 = internal constant [23 x i8] c"android/widget/SeekBar\00", align 1
@__java_type_names.269 = internal constant [47 x i8] c"android/widget/SeekBar$OnSeekBarChangeListener\00", align 1
@__java_type_names.270 = internal constant [22 x i8] c"android/widget/Switch\00", align 1
@__java_type_names.271 = internal constant [26 x i8] c"android/widget/TimePicker\00", align 1
@__java_type_names.272 = internal constant [48 x i8] c"android/widget/TimePicker$OnTimeChangedListener\00", align 1
@__java_type_names.273 = internal constant [21 x i8] c"android/widget/Toast\00", align 1
@__java_type_names.274 = internal constant [18 x i8] c"android/view/View\00", align 1
@__java_type_names.275 = internal constant [30 x i8] c"android/view/View$MeasureSpec\00", align 1
@__java_type_names.276 = internal constant [46 x i8] c"android/view/View$OnAttachStateChangeListener\00", align 1
@__java_type_names.277 = internal constant [34 x i8] c"android/view/View$OnClickListener\00", align 1
@__java_type_names.278 = internal constant [50 x i8] c"mono/android/view/View_OnClickListenerImplementor\00", align 1
@__java_type_names.279 = internal constant [46 x i8] c"android/view/View$OnCreateContextMenuListener\00", align 1
@__java_type_names.280 = internal constant [40 x i8] c"android/view/View$OnFocusChangeListener\00", align 1
@__java_type_names.281 = internal constant [32 x i8] c"android/view/View$OnKeyListener\00", align 1
@__java_type_names.282 = internal constant [48 x i8] c"mono/android/view/View_OnKeyListenerImplementor\00", align 1
@__java_type_names.283 = internal constant [41 x i8] c"android/view/View$OnLayoutChangeListener\00", align 1
@__java_type_names.284 = internal constant [57 x i8] c"mono/android/view/View_OnLayoutChangeListenerImplementor\00", align 1
@__java_type_names.285 = internal constant [34 x i8] c"android/view/View$OnTouchListener\00", align 1
@__java_type_names.286 = internal constant [22 x i8] c"android/view/KeyEvent\00", align 1
@__java_type_names.287 = internal constant [31 x i8] c"android/view/KeyEvent$Callback\00", align 1
@__java_type_names.288 = internal constant [28 x i8] c"android/view/LayoutInflater\00", align 1
@__java_type_names.289 = internal constant [36 x i8] c"android/view/LayoutInflater$Factory\00", align 1
@__java_type_names.290 = internal constant [37 x i8] c"android/view/LayoutInflater$Factory2\00", align 1
@__java_type_names.291 = internal constant [25 x i8] c"android/view/MotionEvent\00", align 1
@__java_type_names.292 = internal constant [30 x i8] c"android/view/ViewTreeObserver\00", align 1
@__java_type_names.293 = internal constant [58 x i8] c"android/view/ViewTreeObserver$OnGlobalFocusChangeListener\00", align 1
@__java_type_names.294 = internal constant [53 x i8] c"android/view/ViewTreeObserver$OnGlobalLayoutListener\00", align 1
@__java_type_names.295 = internal constant [48 x i8] c"android/view/ViewTreeObserver$OnPreDrawListener\00", align 1
@__java_type_names.296 = internal constant [56 x i8] c"android/view/ViewTreeObserver$OnTouchModeChangeListener\00", align 1
@__java_type_names.297 = internal constant [20 x i8] c"android/view/Window\00", align 1
@__java_type_names.298 = internal constant [29 x i8] c"android/view/Window$Callback\00", align 1
@__java_type_names.299 = internal constant [24 x i8] c"android/view/ActionMode\00", align 1
@__java_type_names.300 = internal constant [33 x i8] c"android/view/ActionMode$Callback\00", align 1
@__java_type_names.301 = internal constant [28 x i8] c"android/view/ActionProvider\00", align 1
@__java_type_names.302 = internal constant [33 x i8] c"android/view/ContextThemeWrapper\00", align 1
@__java_type_names.303 = internal constant [21 x i8] c"android/view/Display\00", align 1
@__java_type_names.304 = internal constant [29 x i8] c"android/view/GestureDetector\00", align 1
@__java_type_names.305 = internal constant [49 x i8] c"android/view/GestureDetector$OnDoubleTapListener\00", align 1
@__java_type_names.306 = internal constant [47 x i8] c"android/view/GestureDetector$OnGestureListener\00", align 1
@__java_type_names.307 = internal constant [35 x i8] c"android/view/CollapsibleActionView\00", align 1
@__java_type_names.308 = internal constant [41 x i8] c"android/view/ContextMenu$ContextMenuInfo\00", align 1
@__java_type_names.309 = internal constant [25 x i8] c"android/view/ContextMenu\00", align 1
@__java_type_names.310 = internal constant [18 x i8] c"android/view/Menu\00", align 1
@__java_type_names.311 = internal constant [45 x i8] c"android/view/MenuItem$OnActionExpandListener\00", align 1
@__java_type_names.312 = internal constant [46 x i8] c"android/view/MenuItem$OnMenuItemClickListener\00", align 1
@__java_type_names.313 = internal constant [22 x i8] c"android/view/MenuItem\00", align 1
@__java_type_names.314 = internal constant [24 x i8] c"android/view/InputEvent\00", align 1
@__java_type_names.315 = internal constant [21 x i8] c"android/view/SubMenu\00", align 1
@__java_type_names.316 = internal constant [36 x i8] c"android/view/SurfaceHolder$Callback\00", align 1
@__java_type_names.317 = internal constant [37 x i8] c"android/view/SurfaceHolder$Callback2\00", align 1
@__java_type_names.318 = internal constant [27 x i8] c"android/view/SurfaceHolder\00", align 1
@__java_type_names.319 = internal constant [25 x i8] c"android/view/ViewManager\00", align 1
@__java_type_names.320 = internal constant [24 x i8] c"android/view/ViewParent\00", align 1
@__java_type_names.321 = internal constant [40 x i8] c"android/view/WindowManager$LayoutParams\00", align 1
@__java_type_names.322 = internal constant [27 x i8] c"android/view/WindowManager\00", align 1
@__java_type_names.323 = internal constant [26 x i8] c"android/view/MenuInflater\00", align 1
@__java_type_names.324 = internal constant [34 x i8] c"android/view/ScaleGestureDetector\00", align 1
@__java_type_names.325 = internal constant [57 x i8] c"android/view/ScaleGestureDetector$OnScaleGestureListener\00", align 1
@__java_type_names.326 = internal constant [63 x i8] c"android/view/ScaleGestureDetector$SimpleOnScaleGestureListener\00", align 1
@__java_type_names.327 = internal constant [25 x i8] c"android/view/SearchEvent\00", align 1
@__java_type_names.328 = internal constant [21 x i8] c"android/view/Surface\00", align 1
@__java_type_names.329 = internal constant [25 x i8] c"android/view/SurfaceView\00", align 1
@__java_type_names.330 = internal constant [23 x i8] c"android/view/ViewGroup\00", align 1
@__java_type_names.331 = internal constant [36 x i8] c"android/view/ViewGroup$LayoutParams\00", align 1
@__java_type_names.332 = internal constant [42 x i8] c"android/view/ViewGroup$MarginLayoutParams\00", align 1
@__java_type_names.333 = internal constant [49 x i8] c"android/view/ViewGroup$OnHierarchyChangeListener\00", align 1
@__java_type_names.334 = internal constant [34 x i8] c"android/view/ViewPropertyAnimator\00", align 1
@__java_type_names.335 = internal constant [46 x i8] c"android/view/animation/AccelerateInterpolator\00", align 1
@__java_type_names.336 = internal constant [33 x i8] c"android/view/animation/Animation\00", align 1
@__java_type_names.337 = internal constant [40 x i8] c"android/view/animation/BaseInterpolator\00", align 1
@__java_type_names.338 = internal constant [46 x i8] c"android/view/animation/DecelerateInterpolator\00", align 1
@__java_type_names.339 = internal constant [36 x i8] c"android/view/animation/Interpolator\00", align 1
@__java_type_names.340 = internal constant [44 x i8] c"android/view/inputmethod/InputMethodManager\00", align 1
@__java_type_names.341 = internal constant [46 x i8] c"android/view/accessibility/AccessibilityEvent\00", align 1
@__java_type_names.342 = internal constant [47 x i8] c"android/view/accessibility/AccessibilityRecord\00", align 1
@__java_type_names.343 = internal constant [52 x i8] c"android/view/accessibility/AccessibilityEventSource\00", align 1
@__java_type_names.344 = internal constant [28 x i8] c"android/util/DisplayMetrics\00", align 1
@__java_type_names.345 = internal constant [26 x i8] c"android/util/AttributeSet\00", align 1
@__java_type_names.346 = internal constant [25 x i8] c"android/util/SparseArray\00", align 1
@__java_type_names.347 = internal constant [24 x i8] c"android/util/TypedValue\00", align 1
@__java_type_names.348 = internal constant [22 x i8] c"android/text/Editable\00", align 1
@__java_type_names.349 = internal constant [22 x i8] c"android/text/GetChars\00", align 1
@__java_type_names.350 = internal constant [38 x i8] c"android/text/InputFilter$LengthFilter\00", align 1
@__java_type_names.351 = internal constant [25 x i8] c"android/text/InputFilter\00", align 1
@__java_type_names.352 = internal constant [24 x i8] c"android/text/NoCopySpan\00", align 1
@__java_type_names.353 = internal constant [28 x i8] c"android/text/ParcelableSpan\00", align 1
@__java_type_names.354 = internal constant [23 x i8] c"android/text/Spannable\00", align 1
@__java_type_names.355 = internal constant [21 x i8] c"android/text/Spanned\00", align 1
@__java_type_names.356 = internal constant [25 x i8] c"android/text/TextWatcher\00", align 1
@__java_type_names.357 = internal constant [20 x i8] c"android/text/Layout\00", align 1
@__java_type_names.358 = internal constant [29 x i8] c"android/text/SpannableString\00", align 1
@__java_type_names.359 = internal constant [36 x i8] c"android/text/SpannableStringBuilder\00", align 1
@__java_type_names.360 = internal constant [37 x i8] c"android/text/SpannableStringInternal\00", align 1
@__java_type_names.361 = internal constant [23 x i8] c"android/text/TextPaint\00", align 1
@__java_type_names.362 = internal constant [23 x i8] c"android/text/TextUtils\00", align 1
@__java_type_names.363 = internal constant [34 x i8] c"android/text/TextUtils$TruncateAt\00", align 1
@__java_type_names.364 = internal constant [39 x i8] c"android/text/style/BackgroundColorSpan\00", align 1
@__java_type_names.365 = internal constant [34 x i8] c"android/text/style/CharacterStyle\00", align 1
@__java_type_names.366 = internal constant [39 x i8] c"android/text/style/ForegroundColorSpan\00", align 1
@__java_type_names.367 = internal constant [34 x i8] c"android/text/style/LineHeightSpan\00", align 1
@__java_type_names.368 = internal constant [34 x i8] c"android/text/style/ParagraphStyle\00", align 1
@__java_type_names.369 = internal constant [36 x i8] c"android/text/style/UpdateAppearance\00", align 1
@__java_type_names.370 = internal constant [32 x i8] c"android/text/style/UpdateLayout\00", align 1
@__java_type_names.371 = internal constant [36 x i8] c"android/text/style/WrapTogetherSpan\00", align 1
@__java_type_names.372 = internal constant [39 x i8] c"android/text/style/MetricAffectingSpan\00", align 1
@__java_type_names.373 = internal constant [36 x i8] c"android/text/method/BaseKeyListener\00", align 1
@__java_type_names.374 = internal constant [38 x i8] c"android/text/method/DigitsKeyListener\00", align 1
@__java_type_names.375 = internal constant [32 x i8] c"android/text/method/KeyListener\00", align 1
@__java_type_names.376 = internal constant [39 x i8] c"android/text/method/MetaKeyKeyListener\00", align 1
@__java_type_names.377 = internal constant [38 x i8] c"android/text/method/NumberKeyListener\00", align 1
@__java_type_names.378 = internal constant [31 x i8] c"android/text/format/DateFormat\00", align 1
@__java_type_names.379 = internal constant [29 x i8] c"android/opengl/GLSurfaceView\00", align 1
@__java_type_names.380 = internal constant [38 x i8] c"android/opengl/GLSurfaceView$Renderer\00", align 1
@__java_type_names.381 = internal constant [19 x i8] c"android/os/Handler\00", align 1
@__java_type_names.382 = internal constant [24 x i8] c"android/os/PowerManager\00", align 1
@__java_type_names.383 = internal constant [20 x i8] c"android/os/Vibrator\00", align 1
@__java_type_names.384 = internal constant [22 x i8] c"android/os/BaseBundle\00", align 1
@__java_type_names.385 = internal constant [17 x i8] c"android/os/Build\00", align 1
@__java_type_names.386 = internal constant [25 x i8] c"android/os/Build$VERSION\00", align 1
@__java_type_names.387 = internal constant [18 x i8] c"android/os/Bundle\00", align 1
@__java_type_names.388 = internal constant [23 x i8] c"android/os/Environment\00", align 1
@__java_type_names.389 = internal constant [34 x i8] c"android/os/IBinder$DeathRecipient\00", align 1
@__java_type_names.390 = internal constant [19 x i8] c"android/os/IBinder\00", align 1
@__java_type_names.391 = internal constant [22 x i8] c"android/os/IInterface\00", align 1
@__java_type_names.392 = internal constant [30 x i8] c"android/os/Parcelable$Creator\00", align 1
@__java_type_names.393 = internal constant [22 x i8] c"android/os/Parcelable\00", align 1
@__java_type_names.394 = internal constant [18 x i8] c"android/os/Looper\00", align 1
@__java_type_names.395 = internal constant [18 x i8] c"android/os/Parcel\00", align 1
@__java_type_names.396 = internal constant [19 x i8] c"android/os/Process\00", align 1
@__java_type_names.397 = internal constant [22 x i8] c"android/os/StrictMode\00", align 1
@__java_type_names.398 = internal constant [31 x i8] c"android/os/StrictMode$VmPolicy\00", align 1
@__java_type_names.399 = internal constant [39 x i8] c"android/os/StrictMode$VmPolicy$Builder\00", align 1
@__java_type_names.400 = internal constant [16 x i8] c"android/net/Uri\00", align 1
@__java_type_names.401 = internal constant [26 x i8] c"android/media/MediaPlayer\00", align 1
@__java_type_names.402 = internal constant [31 x i8] c"android/media/VolumeAutomation\00", align 1
@__java_type_names.403 = internal constant [27 x i8] c"android/media/VolumeShaper\00", align 1
@__java_type_names.404 = internal constant [41 x i8] c"android/media/VolumeShaper$Configuration\00", align 1
@__java_type_names.405 = internal constant [24 x i8] c"android/graphics/Bitmap\00", align 1
@__java_type_names.406 = internal constant [31 x i8] c"android/graphics/Bitmap$Config\00", align 1
@__java_type_names.407 = internal constant [24 x i8] c"android/graphics/Canvas\00", align 1
@__java_type_names.408 = internal constant [31 x i8] c"android/graphics/BitmapFactory\00", align 1
@__java_type_names.409 = internal constant [29 x i8] c"android/graphics/ColorFilter\00", align 1
@__java_type_names.410 = internal constant [24 x i8] c"android/graphics/Matrix\00", align 1
@__java_type_names.411 = internal constant [23 x i8] c"android/graphics/Paint\00", align 1
@__java_type_names.412 = internal constant [38 x i8] c"android/graphics/Paint$FontMetricsInt\00", align 1
@__java_type_names.413 = internal constant [29 x i8] c"android/graphics/Paint$Style\00", align 1
@__java_type_names.414 = internal constant [22 x i8] c"android/graphics/Path\00", align 1
@__java_type_names.415 = internal constant [32 x i8] c"android/graphics/Path$Direction\00", align 1
@__java_type_names.416 = internal constant [23 x i8] c"android/graphics/Point\00", align 1
@__java_type_names.417 = internal constant [28 x i8] c"android/graphics/PorterDuff\00", align 1
@__java_type_names.418 = internal constant [33 x i8] c"android/graphics/PorterDuff$Mode\00", align 1
@__java_type_names.419 = internal constant [22 x i8] c"android/graphics/Rect\00", align 1
@__java_type_names.420 = internal constant [23 x i8] c"android/graphics/RectF\00", align 1
@__java_type_names.421 = internal constant [26 x i8] c"android/graphics/Typeface\00", align 1
@__java_type_names.422 = internal constant [35 x i8] c"android/graphics/drawable/Drawable\00", align 1
@__java_type_names.423 = internal constant [44 x i8] c"android/graphics/drawable/Drawable$Callback\00", align 1
@__java_type_names.424 = internal constant [40 x i8] c"android/graphics/drawable/LayerDrawable\00", align 1
@__java_type_names.425 = internal constant [41 x i8] c"android/graphics/drawable/BitmapDrawable\00", align 1
@__java_type_names.426 = internal constant [40 x i8] c"android/graphics/drawable/ColorDrawable\00", align 1
@__java_type_names.427 = internal constant [43 x i8] c"android/graphics/drawable/GradientDrawable\00", align 1
@__java_type_names.428 = internal constant [41 x i8] c"android/graphics/drawable/RippleDrawable\00", align 1
@__java_type_names.429 = internal constant [27 x i8] c"android/animation/Animator\00", align 1
@__java_type_names.430 = internal constant [44 x i8] c"android/animation/Animator$AnimatorListener\00", align 1
@__java_type_names.431 = internal constant [49 x i8] c"android/animation/Animator$AnimatorPauseListener\00", align 1
@__java_type_names.432 = internal constant [47 x i8] c"mono/android/animation/AnimatorEventDispatcher\00", align 1
@__java_type_names.433 = internal constant [32 x i8] c"android/animation/ValueAnimator\00", align 1
@__java_type_names.434 = internal constant [55 x i8] c"android/animation/ValueAnimator$AnimatorUpdateListener\00", align 1
@__java_type_names.435 = internal constant [71 x i8] c"mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor\00", align 1
@__java_type_names.436 = internal constant [42 x i8] c"android/animation/AnimatorListenerAdapter\00", align 1
@__java_type_names.437 = internal constant [35 x i8] c"android/animation/TimeInterpolator\00", align 1
@__java_type_names.438 = internal constant [22 x i8] c"android/app/ActionBar\00", align 1
@__java_type_names.439 = internal constant [26 x i8] c"android/app/ActionBar$Tab\00", align 1
@__java_type_names.440 = internal constant [34 x i8] c"android/app/ActionBar$TabListener\00", align 1
@__java_type_names.441 = internal constant [36 x i8] c"mono/android/app/TabEventDispatcher\00", align 1
@__java_type_names.442 = internal constant [21 x i8] c"android/app/Activity\00", align 1
@__java_type_names.443 = internal constant [24 x i8] c"android/app/AlertDialog\00", align 1
@__java_type_names.444 = internal constant [32 x i8] c"android/app/AlertDialog$Builder\00", align 1
@__java_type_names.445 = internal constant [24 x i8] c"android/app/Application\00", align 1
@__java_type_names.446 = internal constant [29 x i8] c"android/app/DatePickerDialog\00", align 1
@__java_type_names.447 = internal constant [47 x i8] c"android/app/DatePickerDialog$OnDateSetListener\00", align 1
@__java_type_names.448 = internal constant [63 x i8] c"mono/android/app/DatePickerDialog_OnDateSetListenerImplementor\00", align 1
@__java_type_names.449 = internal constant [19 x i8] c"android/app/Dialog\00", align 1
@__java_type_names.450 = internal constant [29 x i8] c"android/app/TimePickerDialog\00", align 1
@__java_type_names.451 = internal constant [47 x i8] c"android/app/TimePickerDialog$OnTimeSetListener\00", align 1
@__java_type_names.452 = internal constant [21 x i8] c"android/app/Fragment\00", align 1
@__java_type_names.453 = internal constant [32 x i8] c"android/app/FragmentTransaction\00", align 1
@__java_type_names.454 = internal constant [26 x i8] c"android/app/PendingIntent\00", align 1
@__java_type_names.455 = internal constant [24 x i8] c"android/content/Context\00", align 1
@__java_type_names.456 = internal constant [23 x i8] c"android/content/Intent\00", align 1
@__java_type_names.457 = internal constant [34 x i8] c"android/content/BroadcastReceiver\00", align 1
@__java_type_names.458 = internal constant [30 x i8] c"android/content/ComponentName\00", align 1
@__java_type_names.459 = internal constant [31 x i8] c"android/content/ContextWrapper\00", align 1
@__java_type_names.460 = internal constant [35 x i8] c"android/content/ComponentCallbacks\00", align 1
@__java_type_names.461 = internal constant [36 x i8] c"android/content/ComponentCallbacks2\00", align 1
@__java_type_names.462 = internal constant [49 x i8] c"android/content/DialogInterface$OnCancelListener\00", align 1
@__java_type_names.463 = internal constant [65 x i8] c"mono/android/content/DialogInterface_OnCancelListenerImplementor\00", align 1
@__java_type_names.464 = internal constant [48 x i8] c"android/content/DialogInterface$OnClickListener\00", align 1
@__java_type_names.465 = internal constant [64 x i8] c"mono/android/content/DialogInterface_OnClickListenerImplementor\00", align 1
@__java_type_names.466 = internal constant [50 x i8] c"android/content/DialogInterface$OnDismissListener\00", align 1
@__java_type_names.467 = internal constant [66 x i8] c"mono/android/content/DialogInterface_OnDismissListenerImplementor\00", align 1
@__java_type_names.468 = internal constant [32 x i8] c"android/content/DialogInterface\00", align 1
@__java_type_names.469 = internal constant [29 x i8] c"android/content/IntentFilter\00", align 1
@__java_type_names.470 = internal constant [29 x i8] c"android/content/IntentSender\00", align 1
@__java_type_names.471 = internal constant [35 x i8] c"android/content/pm/ApplicationInfo\00", align 1
@__java_type_names.472 = internal constant [31 x i8] c"android/content/pm/PackageInfo\00", align 1
@__java_type_names.473 = internal constant [35 x i8] c"android/content/pm/PackageItemInfo\00", align 1
@__java_type_names.474 = internal constant [34 x i8] c"android/content/pm/PackageManager\00", align 1
@__java_type_names.475 = internal constant [38 x i8] c"android/content/res/XmlResourceParser\00", align 1
@__java_type_names.476 = internal constant [33 x i8] c"android/content/res/AssetManager\00", align 1
@__java_type_names.477 = internal constant [35 x i8] c"android/content/res/ColorStateList\00", align 1
@__java_type_names.478 = internal constant [34 x i8] c"android/content/res/Configuration\00", align 1
@__java_type_names.479 = internal constant [30 x i8] c"android/content/res/Resources\00", align 1
@__java_type_names.480 = internal constant [36 x i8] c"android/content/res/Resources$Theme\00", align 1
@__java_type_names.481 = internal constant [31 x i8] c"android/content/res/TypedArray\00", align 1
@__java_type_names.482 = internal constant [40 x i8] c"mono/android/runtime/InputStreamAdapter\00", align 1
@__java_type_names.483 = internal constant [31 x i8] c"mono/android/runtime/JavaArray\00", align 1
@__java_type_names.484 = internal constant [21 x i8] c"java/util/Collection\00", align 1
@__java_type_names.485 = internal constant [18 x i8] c"java/util/HashMap\00", align 1
@__java_type_names.486 = internal constant [20 x i8] c"java/util/ArrayList\00", align 1
@__java_type_names.487 = internal constant [32 x i8] c"mono/android/runtime/JavaObject\00", align 1
@__java_type_names.488 = internal constant [35 x i8] c"android/runtime/JavaProxyThrowable\00", align 1
@__java_type_names.489 = internal constant [18 x i8] c"java/util/HashSet\00", align 1
@__java_type_names.490 = internal constant [41 x i8] c"mono/android/runtime/OutputStreamAdapter\00", align 1
@__java_type_names.491 = internal constant [36 x i8] c"android/runtime/XmlReaderPullParser\00", align 1
@__java_type_names.492 = internal constant [24 x i8] c"java/text/DecimalFormat\00", align 1
@__java_type_names.493 = internal constant [31 x i8] c"java/text/DecimalFormatSymbols\00", align 1
@__java_type_names.494 = internal constant [23 x i8] c"java/text/NumberFormat\00", align 1
@__java_type_names.495 = internal constant [17 x i8] c"java/text/Format\00", align 1
@__java_type_names.496 = internal constant [26 x i8] c"java/net/ConnectException\00", align 1
@__java_type_names.497 = internal constant [27 x i8] c"java/net/HttpURLConnection\00", align 1
@__java_type_names.498 = internal constant [27 x i8] c"java/net/InetSocketAddress\00", align 1
@__java_type_names.499 = internal constant [27 x i8] c"java/net/ProtocolException\00", align 1
@__java_type_names.500 = internal constant [15 x i8] c"java/net/Proxy\00", align 1
@__java_type_names.501 = internal constant [20 x i8] c"java/net/Proxy$Type\00", align 1
@__java_type_names.502 = internal constant [23 x i8] c"java/net/ProxySelector\00", align 1
@__java_type_names.503 = internal constant [23 x i8] c"java/net/SocketAddress\00", align 1
@__java_type_names.504 = internal constant [25 x i8] c"java/net/SocketException\00", align 1
@__java_type_names.505 = internal constant [32 x i8] c"java/net/SocketTimeoutException\00", align 1
@__java_type_names.506 = internal constant [33 x i8] c"java/net/UnknownServiceException\00", align 1
@__java_type_names.507 = internal constant [13 x i8] c"java/net/URI\00", align 1
@__java_type_names.508 = internal constant [13 x i8] c"java/net/URL\00", align 1
@__java_type_names.509 = internal constant [23 x i8] c"java/net/URLConnection\00", align 1
@__java_type_names.510 = internal constant [22 x i8] c"java/util/Enumeration\00", align 1
@__java_type_names.511 = internal constant [19 x i8] c"java/util/Iterator\00", align 1
@__java_type_names.512 = internal constant [17 x i8] c"java/util/Random\00", align 1
@__java_type_names.513 = internal constant [24 x i8] c"java/security/Principal\00", align 1
@__java_type_names.514 = internal constant [23 x i8] c"java/security/KeyStore\00", align 1
@__java_type_names.515 = internal constant [42 x i8] c"java/security/KeyStore$LoadStoreParameter\00", align 1
@__java_type_names.516 = internal constant [43 x i8] c"java/security/KeyStore$ProtectionParameter\00", align 1
@__java_type_names.517 = internal constant [27 x i8] c"java/security/SecureRandom\00", align 1
@__java_type_names.518 = internal constant [31 x i8] c"java/security/cert/Certificate\00", align 1
@__java_type_names.519 = internal constant [38 x i8] c"java/security/cert/CertificateFactory\00", align 1
@__java_type_names.520 = internal constant [33 x i8] c"java/security/cert/X509Extension\00", align 1
@__java_type_names.521 = internal constant [35 x i8] c"java/security/cert/X509Certificate\00", align 1
@__java_type_names.522 = internal constant [16 x i8] c"java/nio/Buffer\00", align 1
@__java_type_names.523 = internal constant [20 x i8] c"java/nio/CharBuffer\00", align 1
@__java_type_names.524 = internal constant [20 x i8] c"java/nio/ByteBuffer\00", align 1
@__java_type_names.525 = internal constant [21 x i8] c"java/nio/FloatBuffer\00", align 1
@__java_type_names.526 = internal constant [19 x i8] c"java/nio/IntBuffer\00", align 1
@__java_type_names.527 = internal constant [30 x i8] c"java/nio/channels/FileChannel\00", align 1
@__java_type_names.528 = internal constant [30 x i8] c"java/nio/channels/ByteChannel\00", align 1
@__java_type_names.529 = internal constant [26 x i8] c"java/nio/channels/Channel\00", align 1
@__java_type_names.530 = internal constant [39 x i8] c"java/nio/channels/GatheringByteChannel\00", align 1
@__java_type_names.531 = internal constant [39 x i8] c"java/nio/channels/InterruptibleChannel\00", align 1
@__java_type_names.532 = internal constant [38 x i8] c"java/nio/channels/ReadableByteChannel\00", align 1
@__java_type_names.533 = internal constant [40 x i8] c"java/nio/channels/ScatteringByteChannel\00", align 1
@__java_type_names.534 = internal constant [38 x i8] c"java/nio/channels/SeekableByteChannel\00", align 1
@__java_type_names.535 = internal constant [38 x i8] c"java/nio/channels/WritableByteChannel\00", align 1
@__java_type_names.536 = internal constant [51 x i8] c"java/nio/channels/spi/AbstractInterruptibleChannel\00", align 1
@__java_type_names.537 = internal constant [18 x i8] c"java/lang/Boolean\00", align 1
@__java_type_names.538 = internal constant [15 x i8] c"java/lang/Byte\00", align 1
@__java_type_names.539 = internal constant [20 x i8] c"java/lang/Character\00", align 1
@__java_type_names.540 = internal constant [16 x i8] c"java/lang/Class\00", align 1
@__java_type_names.541 = internal constant [33 x i8] c"java/lang/ClassNotFoundException\00", align 1
@__java_type_names.542 = internal constant [17 x i8] c"java/lang/Double\00", align 1
@__java_type_names.543 = internal constant [20 x i8] c"java/lang/Exception\00", align 1
@__java_type_names.544 = internal constant [16 x i8] c"java/lang/Float\00", align 1
@__java_type_names.545 = internal constant [23 x i8] c"java/lang/CharSequence\00", align 1
@__java_type_names.546 = internal constant [18 x i8] c"java/lang/Integer\00", align 1
@__java_type_names.547 = internal constant [15 x i8] c"java/lang/Long\00", align 1
@__java_type_names.548 = internal constant [17 x i8] c"java/lang/Object\00", align 1
@__java_type_names.549 = internal constant [27 x i8] c"java/lang/RuntimeException\00", align 1
@__java_type_names.550 = internal constant [16 x i8] c"java/lang/Short\00", align 1
@__java_type_names.551 = internal constant [17 x i8] c"java/lang/String\00", align 1
@__java_type_names.552 = internal constant [17 x i8] c"java/lang/Thread\00", align 1
@__java_type_names.553 = internal constant [35 x i8] c"mono/java/lang/RunnableImplementor\00", align 1
@__java_type_names.554 = internal constant [20 x i8] c"java/lang/Throwable\00", align 1
@__java_type_names.555 = internal constant [29 x i8] c"java/lang/ClassCastException\00", align 1
@__java_type_names.556 = internal constant [22 x i8] c"java/lang/ClassLoader\00", align 1
@__java_type_names.557 = internal constant [15 x i8] c"java/lang/Enum\00", align 1
@__java_type_names.558 = internal constant [16 x i8] c"java/lang/Error\00", align 1
@__java_type_names.559 = internal constant [21 x i8] c"java/lang/Appendable\00", align 1
@__java_type_names.560 = internal constant [24 x i8] c"java/lang/AutoCloseable\00", align 1
@__java_type_names.561 = internal constant [20 x i8] c"java/lang/Cloneable\00", align 1
@__java_type_names.562 = internal constant [21 x i8] c"java/lang/Comparable\00", align 1
@__java_type_names.563 = internal constant [19 x i8] c"java/lang/Iterable\00", align 1
@__java_type_names.564 = internal constant [35 x i8] c"java/lang/IllegalArgumentException\00", align 1
@__java_type_names.565 = internal constant [32 x i8] c"java/lang/IllegalStateException\00", align 1
@__java_type_names.566 = internal constant [36 x i8] c"java/lang/IndexOutOfBoundsException\00", align 1
@__java_type_names.567 = internal constant [19 x i8] c"java/lang/Readable\00", align 1
@__java_type_names.568 = internal constant [19 x i8] c"java/lang/Runnable\00", align 1
@__java_type_names.569 = internal constant [23 x i8] c"java/lang/LinkageError\00", align 1
@__java_type_names.570 = internal constant [31 x i8] c"java/lang/NoClassDefFoundError\00", align 1
@__java_type_names.571 = internal constant [31 x i8] c"java/lang/NullPointerException\00", align 1
@__java_type_names.572 = internal constant [17 x i8] c"java/lang/Number\00", align 1
@__java_type_names.573 = internal constant [39 x i8] c"java/lang/ReflectiveOperationException\00", align 1
@__java_type_names.574 = internal constant [28 x i8] c"java/lang/SecurityException\00", align 1
@__java_type_names.575 = internal constant [40 x i8] c"java/lang/UnsupportedOperationException\00", align 1
@__java_type_names.576 = internal constant [32 x i8] c"java/lang/annotation/Annotation\00", align 1
@__java_type_names.577 = internal constant [35 x i8] c"java/lang/reflect/AnnotatedElement\00", align 1
@__java_type_names.578 = internal constant [37 x i8] c"java/lang/reflect/GenericDeclaration\00", align 1
@__java_type_names.579 = internal constant [23 x i8] c"java/lang/reflect/Type\00", align 1
@__java_type_names.580 = internal constant [31 x i8] c"java/lang/reflect/TypeVariable\00", align 1
@__java_type_names.581 = internal constant [13 x i8] c"java/io/File\00", align 1
@__java_type_names.582 = internal constant [23 x i8] c"java/io/FileDescriptor\00", align 1
@__java_type_names.583 = internal constant [24 x i8] c"java/io/FileInputStream\00", align 1
@__java_type_names.584 = internal constant [18 x i8] c"java/io/Closeable\00", align 1
@__java_type_names.585 = internal constant [18 x i8] c"java/io/Flushable\00", align 1
@__java_type_names.586 = internal constant [20 x i8] c"java/io/InputStream\00", align 1
@__java_type_names.587 = internal constant [31 x i8] c"java/io/InterruptedIOException\00", align 1
@__java_type_names.588 = internal constant [20 x i8] c"java/io/IOException\00", align 1
@__java_type_names.589 = internal constant [21 x i8] c"java/io/Serializable\00", align 1
@__java_type_names.590 = internal constant [21 x i8] c"java/io/OutputStream\00", align 1
@__java_type_names.591 = internal constant [20 x i8] c"java/io/PrintWriter\00", align 1
@__java_type_names.592 = internal constant [15 x i8] c"java/io/Reader\00", align 1
@__java_type_names.593 = internal constant [21 x i8] c"java/io/StringWriter\00", align 1
@__java_type_names.594 = internal constant [15 x i8] c"java/io/Writer\00", align 1
@__java_type_names.595 = internal constant [25 x i8] c"mono/android/TypeManager\00", align 1
@__java_type_names.596 = internal constant [40 x i8] c"android/support/v4/app/FragmentActivity\00", align 1
@__java_type_names.597 = internal constant [32 x i8] c"android/support/v4/app/Fragment\00", align 1
@__java_type_names.598 = internal constant [43 x i8] c"android/support/v4/app/Fragment$SavedState\00", align 1
@__java_type_names.599 = internal constant [39 x i8] c"android/support/v4/app/FragmentManager\00", align 1
@__java_type_names.600 = internal constant [54 x i8] c"android/support/v4/app/FragmentManager$BackStackEntry\00", align 1
@__java_type_names.601 = internal constant [66 x i8] c"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks\00", align 1
@__java_type_names.602 = internal constant [66 x i8] c"android/support/v4/app/FragmentManager$OnBackStackChangedListener\00", align 1
@__java_type_names.603 = internal constant [82 x i8] c"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor\00", align 1
@__java_type_names.604 = internal constant [44 x i8] c"android/support/v4/app/FragmentPagerAdapter\00", align 1
@__java_type_names.605 = internal constant [43 x i8] c"android/support/v4/app/FragmentTransaction\00", align 1
@__java_type_names.606 = internal constant [37 x i8] c"android/support/v4/app/LoaderManager\00", align 1
@__java_type_names.607 = internal constant [53 x i8] c"android/support/v4/app/LoaderManager$LoaderCallbacks\00", align 1
@__java_type_names.608 = internal constant [40 x i8] c"android/support/design/widget/TabLayout\00", align 1
@__java_type_names.609 = internal constant [62 x i8] c"android/support/design/widget/TabLayout$OnTabSelectedListener\00", align 1
@__java_type_names.610 = internal constant [78 x i8] c"mono/android/support/design/widget/TabLayout_OnTabSelectedListenerImplementor\00", align 1
@__java_type_names.611 = internal constant [44 x i8] c"android/support/design/widget/TabLayout$Tab\00", align 1
@__java_type_names.612 = internal constant [51 x i8] c"android/support/design/widget/BottomNavigationView\00", align 1
@__java_type_names.613 = internal constant [86 x i8] c"android/support/design/widget/BottomNavigationView$OnNavigationItemReselectedListener\00", align 1
@__java_type_names.614 = internal constant [102 x i8] c"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemReselectedListenerImplementor\00", align 1
@__java_type_names.615 = internal constant [84 x i8] c"android/support/design/widget/BottomNavigationView$OnNavigationItemSelectedListener\00", align 1
@__java_type_names.616 = internal constant [100 x i8] c"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemSelectedListenerImplementor\00", align 1
@__java_type_names.617 = internal constant [34 x i8] c"android/support/v4/content/Loader\00", align 1
@__java_type_names.618 = internal constant [57 x i8] c"android/support/v4/content/Loader$OnLoadCanceledListener\00", align 1
@__java_type_names.619 = internal constant [57 x i8] c"android/support/v4/content/Loader$OnLoadCompleteListener\00", align 1
@__java_type_names.620 = internal constant [40 x i8] c"android/support/v4/app/TaskStackBuilder\00", align 1
@__java_type_names.621 = internal constant [58 x i8] c"android/support/v4/app/TaskStackBuilder$SupportParentable\00", align 1
@__java_type_names.622 = internal constant [50 x i8] c"com/xamarin/forms/platform/android/FormsViewGroup\00", align 1
@__java_type_names.623 = internal constant [39 x i8] c"com/xamarin/formsviewgroup/BuildConfig\00", align 1

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
], align 4

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
