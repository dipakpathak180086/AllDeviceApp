; ModuleID = 'obj\Debug\81\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\81\android\marshal_methods.armeabi-v7a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [32 x i32] [
	i32 44865860, ; 0: RJExciseApp.dll => 0x2ac9944 => 0
	i32 166922606, ; 1: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 7
	i32 321597661, ; 2: System.Numerics => 0x132b30dd => 15
	i32 389971796, ; 3: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 8
	i32 465846621, ; 4: mscorlib => 0x1bc4415d => 3
	i32 469710990, ; 5: System.dll => 0x1bff388e => 5
	i32 514659665, ; 6: Xamarin.Android.Support.Compat => 0x1ead1551 => 7
	i32 571524804, ; 7: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 12
	i32 1098259244, ; 8: System => 0x41761b2c => 5
	i32 1445445088, ; 9: Xamarin.Android.Support.Fragment => 0x5627bde0 => 10
	i32 1574652163, ; 10: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 9
	i32 1639515021, ; 11: System.Net.Http.dll => 0x61b9038d => 13
	i32 1776026572, ; 12: System.Core.dll => 0x69dc03cc => 4
	i32 1877418711, ; 13: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 12
	i32 2166116741, ; 14: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 9
	i32 2201231467, ; 15: System.Net.Http => 0x8334206b => 13
	i32 2330457430, ; 16: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 8
	i32 2373288475, ; 17: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 10
	i32 2475788418, ; 18: Java.Interop.dll => 0x93918882 => 1
	i32 2905242038, ; 19: mscorlib.dll => 0xad2a79b6 => 3
	i32 3068715062, ; 20: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 6
	i32 3210768037, ; 21: RJExciseApp => 0xbf606ea5 => 0
	i32 3247949154, ; 22: Mono.Security => 0xc197c562 => 14
	i32 3366347497, ; 23: Java.Interop => 0xc8a662e9 => 1
	i32 3476120550, ; 24: Mono.Android => 0xcf3163e6 => 2
	i32 3672681054, ; 25: Mono.Android.dll => 0xdae8aa5e => 2
	i32 3678221644, ; 26: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 11
	i32 3681174138, ; 27: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 6
	i32 3829621856, ; 28: System.Numerics.dll => 0xe4436460 => 15
	i32 3883175360, ; 29: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 11
	i32 4105002889, ; 30: Mono.Security.dll => 0xf4ad5f89 => 14
	i32 4151237749 ; 31: System.Core => 0xf76edc75 => 4
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [32 x i32] [
	i32 0, i32 7, i32 15, i32 8, i32 3, i32 5, i32 7, i32 12, ; 0..7
	i32 5, i32 10, i32 9, i32 13, i32 4, i32 12, i32 9, i32 13, ; 8..15
	i32 8, i32 10, i32 1, i32 3, i32 6, i32 0, i32 14, i32 1, ; 16..23
	i32 2, i32 2, i32 11, i32 6, i32 15, i32 11, i32 14, i32 4 ; 32..31
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
