; ModuleID = 'obj\Debug\100\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\100\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [96 x i32] [
	i32 57263871, ; 0: Xamarin.Forms.Core.dll => 0x369c6ff => 32
	i32 160529393, ; 1: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 13
	i32 166922606, ; 2: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 18
	i32 219130465, ; 3: Xamarin.Android.Support.v4 => 0xd0faa61 => 25
	i32 232815796, ; 4: System.Web.Services => 0xde07cb4 => 47
	i32 293914992, ; 5: Xamarin.Android.Support.Transition => 0x1184c970 => 24
	i32 321597661, ; 6: System.Numerics => 0x132b30dd => 39
	i32 331266987, ; 7: Xamarin.Android.Support.v7.MediaRouter.dll => 0x13bebbab => 28
	i32 388313361, ; 8: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 16
	i32 389971796, ; 9: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 19
	i32 465846621, ; 10: mscorlib => 0x1bc4415d => 6
	i32 469710990, ; 11: System.dll => 0x1bff388e => 8
	i32 514659665, ; 12: Xamarin.Android.Support.Compat => 0x1ead1551 => 18
	i32 526420162, ; 13: System.Transactions.dll => 0x1f6088c2 => 43
	i32 539750087, ; 14: Xamarin.Android.Support.Design => 0x202beec7 => 21
	i32 571524804, ; 15: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 30
	i32 605376203, ; 16: System.IO.Compression.FileSystem => 0x24154ecb => 46
	i32 690569205, ; 17: System.Xml.Linq.dll => 0x29293ff5 => 11
	i32 692692150, ; 18: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 17
	i32 775507847, ; 19: System.IO.Compression => 0x2e394f87 => 45
	i32 809851609, ; 20: System.Drawing.Common.dll => 0x30455ad9 => 37
	i32 882883187, ; 21: Xamarin.Android.Support.v4.dll => 0x349fba73 => 25
	i32 958213972, ; 22: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 23
	i32 974778368, ; 23: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 1042160112, ; 24: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 34
	i32 1098259244, ; 25: System => 0x41761b2c => 8
	i32 1359785034, ; 26: Xamarin.Android.Support.Design.dll => 0x510cac4a => 21
	i32 1365406463, ; 27: System.ServiceModel.Internals.dll => 0x516272ff => 36
	i32 1445445088, ; 28: Xamarin.Android.Support.Fragment => 0x5627bde0 => 22
	i32 1460219004, ; 29: Xamarin.Forms.Xaml => 0x57092c7c => 35
	i32 1462112819, ; 30: System.IO.Compression.dll => 0x57261233 => 45
	i32 1574652163, ; 31: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 20
	i32 1587447679, ; 32: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 13
	i32 1592978981, ; 33: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1639515021, ; 34: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 35: System.Runtime => 0x62c6282e => 9
	i32 1662014763, ; 36: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 31
	i32 1776026572, ; 37: System.Core.dll => 0x69dc03cc => 7
	i32 1877418711, ; 38: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 30
	i32 1878053835, ; 39: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 35
	i32 2079903147, ; 40: System.Runtime.dll => 0x7bf8cdab => 9
	i32 2088003786, ; 41: ThreePointCheck_App.dll => 0x7c7468ca => 12
	i32 2126786730, ; 42: Xamarin.Forms.Platform.Android => 0x7ec430aa => 33
	i32 2166116741, ; 43: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 20
	i32 2201231467, ; 44: System.Net.Http => 0x8334206b => 1
	i32 2330457430, ; 45: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 19
	i32 2373288475, ; 46: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 22
	i32 2471841756, ; 47: netstandard.dll => 0x93554fdc => 41
	i32 2475788418, ; 48: Java.Interop.dll => 0x93918882 => 4
	i32 2501346920, ; 49: System.Data.DataSetExtensions => 0x95178668 => 44
	i32 2754271178, ; 50: Xamarin.Android.Support.v7.Palette => 0xa42ad7ca => 29
	i32 2766581644, ; 51: Xamarin.Forms.Core => 0xa4e6af8c => 32
	i32 2819470561, ; 52: System.Xml.dll => 0xa80db4e1 => 10
	i32 2843732642, ; 53: ThreePointCheck_App.Android.dll => 0xa97feaa2 => 0
	i32 2903344695, ; 54: System.ComponentModel.Composition => 0xad0d8637 => 40
	i32 2905242038, ; 55: mscorlib.dll => 0xad2a79b6 => 6
	i32 2922925221, ; 56: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 31
	i32 3044182254, ; 57: FormsViewGroup => 0xb57288ee => 3
	i32 3068715062, ; 58: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 14
	i32 3092211740, ; 59: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 23
	i32 3111772706, ; 60: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3194035187, ; 61: Xamarin.Android.Support.v7.MediaRouter => 0xbe611bf3 => 28
	i32 3204380047, ; 62: System.Data.dll => 0xbefef58f => 42
	i32 3247949154, ; 63: Mono.Security => 0xc197c562 => 38
	i32 3289306677, ; 64: ThreePointCheck_App.Android => 0xc40ed635 => 0
	i32 3317144872, ; 65: System.Data => 0xc5b79d28 => 42
	i32 3366347497, ; 66: Java.Interop => 0xc8a662e9 => 4
	i32 3367636282, ; 67: ThreePointCheck_App => 0xc8ba0d3a => 12
	i32 3404865022, ; 68: System.ServiceModel.Internals => 0xcaf21dfe => 36
	i32 3429136800, ; 69: System.Xml => 0xcc6479a0 => 10
	i32 3430777524, ; 70: netstandard => 0xcc7d82b4 => 41
	i32 3439690031, ; 71: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 17
	i32 3476120550, ; 72: Mono.Android => 0xcf3163e6 => 5
	i32 3486566296, ; 73: System.Transactions => 0xcfd0c798 => 43
	i32 3498942916, ; 74: Xamarin.Android.Support.v7.CardView.dll => 0xd08da1c4 => 27
	i32 3509114376, ; 75: System.Xml.Linq => 0xd128d608 => 11
	i32 3536029504, ; 76: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 33
	i32 3567349600, ; 77: System.ComponentModel.Composition.dll => 0xd4a16f60 => 40
	i32 3632359727, ; 78: Xamarin.Forms.Platform => 0xd881692f => 34
	i32 3672681054, ; 79: Mono.Android.dll => 0xdae8aa5e => 5
	i32 3676310014, ; 80: System.Web.Services.dll => 0xdb2009fe => 47
	i32 3678221644, ; 81: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 26
	i32 3681174138, ; 82: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 14
	i32 3689375977, ; 83: System.Drawing.Common => 0xdbe768e9 => 37
	i32 3718463572, ; 84: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 16
	i32 3789524022, ; 85: Xamarin.Android.Support.v7.Palette.dll => 0xe1df8c36 => 29
	i32 3829621856, ; 86: System.Numerics.dll => 0xe4436460 => 39
	i32 3862817207, ; 87: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 15
	i32 3874897629, ; 88: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 15
	i32 3883175360, ; 89: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 26
	i32 3920810846, ; 90: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 46
	i32 3945713374, ; 91: System.Data.DataSetExtensions.dll => 0xeb2ecede => 44
	i32 4105002889, ; 92: Mono.Security.dll => 0xf4ad5f89 => 38
	i32 4151237749, ; 93: System.Core => 0xf76edc75 => 7
	i32 4216993138, ; 94: Xamarin.Android.Support.Transition.dll => 0xfb5a3572 => 24
	i32 4219003402 ; 95: Xamarin.Android.Support.v7.CardView => 0xfb78e20a => 27
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [96 x i32] [
	i32 32, i32 13, i32 18, i32 25, i32 47, i32 24, i32 39, i32 28, ; 0..7
	i32 16, i32 19, i32 6, i32 8, i32 18, i32 43, i32 21, i32 30, ; 8..15
	i32 46, i32 11, i32 17, i32 45, i32 37, i32 25, i32 23, i32 3, ; 16..23
	i32 34, i32 8, i32 21, i32 36, i32 22, i32 35, i32 45, i32 20, ; 24..31
	i32 13, i32 2, i32 1, i32 9, i32 31, i32 7, i32 30, i32 35, ; 32..39
	i32 9, i32 12, i32 33, i32 20, i32 1, i32 19, i32 22, i32 41, ; 40..47
	i32 4, i32 44, i32 29, i32 32, i32 10, i32 0, i32 40, i32 6, ; 48..55
	i32 31, i32 3, i32 14, i32 23, i32 2, i32 28, i32 42, i32 38, ; 56..63
	i32 0, i32 42, i32 4, i32 12, i32 36, i32 10, i32 41, i32 17, ; 64..71
	i32 5, i32 43, i32 27, i32 11, i32 33, i32 40, i32 34, i32 5, ; 72..79
	i32 47, i32 26, i32 14, i32 37, i32 16, i32 29, i32 39, i32 15, ; 80..87
	i32 15, i32 26, i32 46, i32 44, i32 38, i32 7, i32 24, i32 27 ; 96..95
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
