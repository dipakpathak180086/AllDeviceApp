; ModuleID = 'obj\Debug\80\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\80\android\marshal_methods.armeabi-v7a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [54 x i32] [
	i32 160529393, ; 0: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 9
	i32 166922606, ; 1: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 14
	i32 293914992, ; 2: Xamarin.Android.Support.Transition => 0x1184c970 => 20
	i32 321597661, ; 3: System.Numerics => 0x132b30dd => 25
	i32 388313361, ; 4: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 12
	i32 389971796, ; 5: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 15
	i32 465846621, ; 6: mscorlib => 0x1bc4415d => 3
	i32 469710990, ; 7: System.dll => 0x1bff388e => 7
	i32 514659665, ; 8: Xamarin.Android.Support.Compat => 0x1ead1551 => 14
	i32 539750087, ; 9: Xamarin.Android.Support.Design => 0x202beec7 => 17
	i32 571524804, ; 10: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 22
	i32 692692150, ; 11: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 13
	i32 958213972, ; 12: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 19
	i32 1098259244, ; 13: System => 0x41761b2c => 7
	i32 1265466678, ; 14: SMPDisptach.dll => 0x4b6d7d36 => 0
	i32 1359785034, ; 15: Xamarin.Android.Support.Design.dll => 0x510cac4a => 17
	i32 1445445088, ; 16: Xamarin.Android.Support.Fragment => 0x5627bde0 => 18
	i32 1574652163, ; 17: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 16
	i32 1587447679, ; 18: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 9
	i32 1639515021, ; 19: System.Net.Http.dll => 0x61b9038d => 24
	i32 1662014763, ; 20: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 23
	i32 1776026572, ; 21: System.Core.dll => 0x69dc03cc => 4
	i32 1780562273, ; 22: SMPDisptach => 0x6a213961 => 0
	i32 1877418711, ; 23: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 22
	i32 2166116741, ; 24: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 16
	i32 2201231467, ; 25: System.Net.Http => 0x8334206b => 24
	i32 2330457430, ; 26: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 15
	i32 2373288475, ; 27: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 18
	i32 2475788418, ; 28: Java.Interop.dll => 0x93918882 => 1
	i32 2501346920, ; 29: System.Data.DataSetExtensions => 0x95178668 => 5
	i32 2819470561, ; 30: System.Xml.dll => 0xa80db4e1 => 8
	i32 2905242038, ; 31: mscorlib.dll => 0xad2a79b6 => 3
	i32 2922925221, ; 32: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 23
	i32 3068715062, ; 33: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 10
	i32 3092211740, ; 34: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 19
	i32 3204380047, ; 35: System.Data.dll => 0xbefef58f => 6
	i32 3247949154, ; 36: Mono.Security => 0xc197c562 => 26
	i32 3317144872, ; 37: System.Data => 0xc5b79d28 => 6
	i32 3366347497, ; 38: Java.Interop => 0xc8a662e9 => 1
	i32 3429136800, ; 39: System.Xml => 0xcc6479a0 => 8
	i32 3439690031, ; 40: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 13
	i32 3476120550, ; 41: Mono.Android => 0xcf3163e6 => 2
	i32 3672681054, ; 42: Mono.Android.dll => 0xdae8aa5e => 2
	i32 3678221644, ; 43: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 21
	i32 3681174138, ; 44: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 10
	i32 3718463572, ; 45: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 12
	i32 3829621856, ; 46: System.Numerics.dll => 0xe4436460 => 25
	i32 3862817207, ; 47: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 11
	i32 3874897629, ; 48: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 11
	i32 3883175360, ; 49: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 21
	i32 3945713374, ; 50: System.Data.DataSetExtensions.dll => 0xeb2ecede => 5
	i32 4105002889, ; 51: Mono.Security.dll => 0xf4ad5f89 => 26
	i32 4151237749, ; 52: System.Core => 0xf76edc75 => 4
	i32 4216993138 ; 53: Xamarin.Android.Support.Transition.dll => 0xfb5a3572 => 20
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [54 x i32] [
	i32 9, i32 14, i32 20, i32 25, i32 12, i32 15, i32 3, i32 7, ; 0..7
	i32 14, i32 17, i32 22, i32 13, i32 19, i32 7, i32 0, i32 17, ; 8..15
	i32 18, i32 16, i32 9, i32 24, i32 23, i32 4, i32 0, i32 22, ; 16..23
	i32 16, i32 24, i32 15, i32 18, i32 1, i32 5, i32 8, i32 3, ; 24..31
	i32 23, i32 10, i32 19, i32 6, i32 26, i32 6, i32 1, i32 8, ; 32..39
	i32 13, i32 2, i32 2, i32 21, i32 10, i32 12, i32 25, i32 11, ; 40..47
	i32 11, i32 21, i32 5, i32 26, i32 4, i32 20 ; 48..53
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
