; ModuleID = 'obj\Debug\81\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\81\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [96 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 5
	i64 702024105029695270, ; 1: System.Drawing.Common => 0x9be17343c0e7726 => 37
	i64 940822596282819491, ; 2: System.Transactions => 0xd0e792aa81923a3 => 43
	i64 996343623809489702, ; 3: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 34
	i64 1000557547492888992, ; 4: Mono.Security.dll => 0xde2b1c9cba651a0 => 38
	i64 1342439039765371018, ; 5: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 22
	i64 1425944114962822056, ; 6: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 2
	i64 1744702963312407042, ; 7: Xamarin.Android.Support.v7.AppCompat => 0x18366e19eeceb202 => 26
	i64 1860886102525309849, ; 8: Xamarin.Android.Support.v7.RecyclerView.dll => 0x19d3320d047b7399 => 30
	i64 1938067011858688285, ; 9: Xamarin.Android.Support.v4.dll => 0x1ae565add0bd691d => 25
	i64 2284400282711631002, ; 10: System.Web.Services => 0x1fb3d1f42fd4249a => 47
	i64 2497223385847772520, ; 11: System.Runtime => 0x22a7eb7046413568 => 9
	i64 2592350477072141967, ; 12: System.Xml.dll => 0x23f9e10627330e8f => 10
	i64 2624866290265602282, ; 13: mscorlib.dll => 0x246d65fbde2db8ea => 6
	i64 2960931600190307745, ; 14: Xamarin.Forms.Core => 0x2917579a49927da1 => 32
	i64 3022227708164871115, ; 15: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 23
	i64 3531994851595924923, ; 16: System.Numerics => 0x31042a9aade235bb => 39
	i64 3571415421602489686, ; 17: System.Runtime.dll => 0x319037675df7e556 => 9
	i64 3716579019761409177, ; 18: netstandard.dll => 0x3393f0ed5c8c5c99 => 41
	i64 4264996749430196783, ; 19: Xamarin.Android.Support.Transition.dll => 0x3b304ff259fb8a2f => 24
	i64 4525561845656915374, ; 20: System.ServiceModel.Internals => 0x3ece06856b710dae => 36
	i64 5142919913060024034, ; 21: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 33
	i64 5218036808443290681, ; 22: ThreePointCheck_App.Android.dll => 0x486a30d4b82ce439 => 0
	i64 5439315836349573567, ; 23: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0x4b7c54ef36c5e9bf => 16
	i64 5507995362134886206, ; 24: System.Core.dll => 0x4c705499688c873e => 7
	i64 5767696078500135884, ; 25: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 17
	i64 6078179702513558880, ; 26: ThreePointCheck_App.Android => 0x545a083c614f6560 => 0
	i64 6085203216496545422, ; 27: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 34
	i64 6086316965293125504, ; 28: FormsViewGroup.dll => 0x5476f10882baef80 => 3
	i64 6405879832841858445, ; 29: Xamarin.Android.Support.Vector.Drawable.dll => 0x58e641c4a660ad8d => 31
	i64 6437453774371681866, ; 30: Xamarin.Android.Support.v7.Palette => 0x59566e19c76bf64a => 29
	i64 6588599331800941662, ; 31: Xamarin.Android.Support.v4 => 0x5b6f682f335f045e => 25
	i64 6591024623626361694, ; 32: System.Web.Services.dll => 0x5b7805f9751a1b5e => 47
	i64 6876862101832370452, ; 33: System.Xml.Linq => 0x5f6f85a57d108914 => 11
	i64 7164916624638427275, ; 34: Xamarin.Android.Support.v7.MediaRouter.dll => 0x636ee5b570dd408b => 28
	i64 7488575175965059935, ; 35: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 11
	i64 7635363394907363464, ; 36: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 32
	i64 7654504624184590948, ; 37: System.Net.Http => 0x6a3a4366801b8264 => 1
	i64 7820441508502274321, ; 38: System.Data => 0x6c87ca1e14ff8111 => 42
	i64 7879037620440914030, ; 39: Xamarin.Android.Support.v7.AppCompat.dll => 0x6d57f6f88a51d86e => 26
	i64 8003488281596490781, ; 40: Xamarin.Android.Support.v7.MediaRouter => 0x6f121a30148f741d => 28
	i64 8044118961405839122, ; 41: System.ComponentModel.Composition => 0x6fa2739369944712 => 40
	i64 8101777744205214367, ; 42: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 17
	i64 8103644804370223335, ; 43: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 44
	i64 8167236081217502503, ; 44: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 4
	i64 8385935383968044654, ; 45: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 15
	i64 8626175481042262068, ; 46: Java.Interop => 0x77b654e585b55834 => 4
	i64 8684531736582871431, ; 47: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 46
	i64 9475595603812259686, ; 48: Xamarin.Android.Support.Design => 0x838013ff707b9766 => 21
	i64 9662334977499516867, ; 49: System.Numerics.dll => 0x8617827802b0cfc3 => 39
	i64 9808709177481450983, ; 50: Mono.Android.dll => 0x881f890734e555e7 => 5
	i64 9834056768316610435, ; 51: System.Transactions.dll => 0x8879968718899783 => 43
	i64 9866412715007501892, ; 52: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 14
	i64 9998632235833408227, ; 53: Mono.Security => 0x8ac2470b209ebae3 => 38
	i64 10038780035334861115, ; 54: System.Net.Http.dll => 0x8b50e941206af13b => 1
	i64 10843115876628275641, ; 55: ThreePointCheck_App.dll => 0x967a7c70c4d3a1b9 => 12
	i64 10850923258212604222, ; 56: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 15
	i64 11023048688141570732, ; 57: System.Core => 0x98f9bc61168392ac => 7
	i64 11037814507248023548, ; 58: System.Xml => 0x992e31d0412bf7fc => 10
	i64 11376461258732682436, ; 59: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 18
	i64 11395105072750394936, ; 60: Xamarin.Android.Support.v7.CardView => 0x9e238bb09789fe38 => 27
	i64 11597940890313164233, ; 61: netstandard => 0xa0f429ca8d1805c9 => 41
	i64 11866610289935986454, ; 62: Xamarin.Android.Support.v7.Palette.dll => 0xa4aeab2fcba12f16 => 29
	i64 12414299427252656003, ; 63: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 18
	i64 12550732019250633519, ; 64: System.IO.Compression => 0xae2d28465e8e1b2f => 45
	i64 12550875237033552905, ; 65: ThreePointCheck_App => 0xae2daa87dba1ac09 => 12
	i64 12559163541709922900, ; 66: Xamarin.Android.Support.v7.CardView.dll => 0xae4b1cb32ba82254 => 27
	i64 12952608645614506925, ; 67: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 20
	i64 12963446364377008305, ; 68: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 37
	i64 13358059602087096138, ; 69: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 22
	i64 13370592475155966277, ; 70: System.Runtime.Serialization => 0xb98de304062ea945 => 2
	i64 13647894001087880694, ; 71: System.Data.dll => 0xbd670f48cb071df6 => 42
	i64 13967638549803255703, ; 72: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 33
	i64 14369828458497533121, ; 73: Xamarin.Android.Support.Vector.Drawable => 0xc76be2d9300b64c1 => 31
	i64 14400856865250966808, ; 74: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 19
	i64 14987728460634540364, ; 75: System.IO.Compression.dll => 0xcfff1ba06622494c => 45
	i64 15188640517174936311, ; 76: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 13
	i64 15246441518555807158, ; 77: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 13
	i64 15418891414777631748, ; 78: Xamarin.Android.Support.Transition => 0xd5fae80c88241404 => 24
	i64 15457813392950723921, ; 79: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 23
	i64 15609085926864131306, ; 80: System.dll => 0xd89e9cf3334914ea => 8
	i64 15810740023422282496, ; 81: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 35
	i64 16154507427712707110, ; 82: System => 0xe03056ea4e39aa26 => 8
	i64 16565028646146589191, ; 83: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 40
	i64 16822611501064131242, ; 84: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 44
	i64 16833383113903931215, ; 85: mscorlib => 0xe99c30c1484d7f4f => 6
	i64 16932527889823454152, ; 86: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 20
	i64 17009591894298689098, ; 87: Xamarin.Android.Support.Animated.Vector.Drawable => 0xec0e35b50a097e4a => 16
	i64 17428701562824544279, ; 88: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 19
	i64 17760961058993581169, ; 89: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 14
	i64 17882897186074144999, ; 90: FormsViewGroup => 0xf82cd03e3ac830e7 => 3
	i64 17892495832318972303, ; 91: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 35
	i64 17928294245072900555, ; 92: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 46
	i64 17936749993673010118, ; 93: Xamarin.Android.Support.Design.dll => 0xf8ec231615deabc6 => 21
	i64 18090425465832348288, ; 94: Xamarin.Android.Support.v7.RecyclerView => 0xfb0e1a1d2e9e1a80 => 30
	i64 18129453464017766560 ; 95: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 36
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [96 x i32] [
	i32 5, i32 37, i32 43, i32 34, i32 38, i32 22, i32 2, i32 26, ; 0..7
	i32 30, i32 25, i32 47, i32 9, i32 10, i32 6, i32 32, i32 23, ; 8..15
	i32 39, i32 9, i32 41, i32 24, i32 36, i32 33, i32 0, i32 16, ; 16..23
	i32 7, i32 17, i32 0, i32 34, i32 3, i32 31, i32 29, i32 25, ; 24..31
	i32 47, i32 11, i32 28, i32 11, i32 32, i32 1, i32 42, i32 26, ; 32..39
	i32 28, i32 40, i32 17, i32 44, i32 4, i32 15, i32 4, i32 46, ; 40..47
	i32 21, i32 39, i32 5, i32 43, i32 14, i32 38, i32 1, i32 12, ; 48..55
	i32 15, i32 7, i32 10, i32 18, i32 27, i32 41, i32 29, i32 18, ; 56..63
	i32 45, i32 12, i32 27, i32 20, i32 37, i32 22, i32 2, i32 42, ; 64..71
	i32 33, i32 31, i32 19, i32 45, i32 13, i32 13, i32 24, i32 23, ; 72..79
	i32 8, i32 35, i32 8, i32 40, i32 44, i32 6, i32 20, i32 16, ; 80..87
	i32 19, i32 14, i32 3, i32 35, i32 46, i32 21, i32 30, i32 36 ; 96..95
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}
