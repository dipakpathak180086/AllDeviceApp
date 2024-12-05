; ModuleID = 'obj\Release\81\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\81\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [12800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [166400 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [1734656 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [121856 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [336384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [743936 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [218112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [35840 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [419328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [55808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [1086976 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [852480 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [108544 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [86528 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [163328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [107008 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [32256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [54272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [154624 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [328192 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [15872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [706560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [386672 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [17504 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [86528 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [2076160 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [28 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12800 x i8], [12800 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 166400, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([166400 x i8], [166400 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 1734656, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1734656 x i8], [1734656 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 336384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([336384 x i8], [336384 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 743936, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([743936 x i8], [743936 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 218112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([218112 x i8], [218112 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 35840, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([35840 x i8], [35840 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 419328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([419328 x i8], [419328 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([55808 x i8], [55808 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 1086976, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1086976 x i8], [1086976 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 852480, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([852480 x i8], [852480 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 108544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([108544 x i8], [108544 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 86528, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([86528 x i8], [86528 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 163328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([163328 x i8], [163328 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 107008, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([107008 x i8], [107008 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([32256 x i8], [32256 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 54272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([54272 x i8], [54272 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 154624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([154624 x i8], [154624 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 328192, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([328192 x i8], [328192 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 706560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([706560 x i8], [706560 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 386672, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([386672 x i8], [386672 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 17504, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17504 x i8], [17504 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 86528, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([86528 x i8], [86528 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 2076160, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2076160 x i8], [2076160 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 28, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([28 x %struct.CompressedAssemblyDescriptor], [28 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
