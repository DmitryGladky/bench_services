// Code generated by protoc-gen-go. DO NOT EDIT.
// versions:
// 	protoc-gen-go v1.28.1
// 	protoc        v3.21.5
// source: grpc/test.proto

package grpc

import (
	protoreflect "google.golang.org/protobuf/reflect/protoreflect"
	protoimpl "google.golang.org/protobuf/runtime/protoimpl"
	reflect "reflect"
	sync "sync"
)

const (
	// Verify that this generated code is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(20 - protoimpl.MinVersion)
	// Verify that runtime/protoimpl is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(protoimpl.MaxVersion - 20)
)

type LongRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Count int32 `protobuf:"varint,1,opt,name=count,proto3" json:"count,omitempty"`
}

func (x *LongRequest) Reset() {
	*x = LongRequest{}
	if protoimpl.UnsafeEnabled {
		mi := &file_grpc_test_proto_msgTypes[0]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *LongRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*LongRequest) ProtoMessage() {}

func (x *LongRequest) ProtoReflect() protoreflect.Message {
	mi := &file_grpc_test_proto_msgTypes[0]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use LongRequest.ProtoReflect.Descriptor instead.
func (*LongRequest) Descriptor() ([]byte, []int) {
	return file_grpc_test_proto_rawDescGZIP(), []int{0}
}

func (x *LongRequest) GetCount() int32 {
	if x != nil {
		return x.Count
	}
	return 0
}

type LongReply struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id []int32 `protobuf:"varint,1,rep,packed,name=id,proto3" json:"id,omitempty"`
}

func (x *LongReply) Reset() {
	*x = LongReply{}
	if protoimpl.UnsafeEnabled {
		mi := &file_grpc_test_proto_msgTypes[1]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *LongReply) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*LongReply) ProtoMessage() {}

func (x *LongReply) ProtoReflect() protoreflect.Message {
	mi := &file_grpc_test_proto_msgTypes[1]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use LongReply.ProtoReflect.Descriptor instead.
func (*LongReply) Descriptor() ([]byte, []int) {
	return file_grpc_test_proto_rawDescGZIP(), []int{1}
}

func (x *LongReply) GetId() []int32 {
	if x != nil {
		return x.Id
	}
	return nil
}

type StreamReply struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id int32 `protobuf:"varint,1,opt,name=id,proto3" json:"id,omitempty"`
}

func (x *StreamReply) Reset() {
	*x = StreamReply{}
	if protoimpl.UnsafeEnabled {
		mi := &file_grpc_test_proto_msgTypes[2]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *StreamReply) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*StreamReply) ProtoMessage() {}

func (x *StreamReply) ProtoReflect() protoreflect.Message {
	mi := &file_grpc_test_proto_msgTypes[2]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use StreamReply.ProtoReflect.Descriptor instead.
func (*StreamReply) Descriptor() ([]byte, []int) {
	return file_grpc_test_proto_rawDescGZIP(), []int{2}
}

func (x *StreamReply) GetId() int32 {
	if x != nil {
		return x.Id
	}
	return 0
}

var File_grpc_test_proto protoreflect.FileDescriptor

var file_grpc_test_proto_rawDesc = []byte{
	0x0a, 0x0f, 0x67, 0x72, 0x70, 0x63, 0x2f, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x70, 0x72, 0x6f, 0x74,
	0x6f, 0x22, 0x23, 0x0a, 0x0b, 0x4c, 0x6f, 0x6e, 0x67, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74,
	0x12, 0x14, 0x0a, 0x05, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x18, 0x01, 0x20, 0x01, 0x28, 0x05, 0x52,
	0x05, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x22, 0x1b, 0x0a, 0x09, 0x4c, 0x6f, 0x6e, 0x67, 0x52, 0x65,
	0x70, 0x6c, 0x79, 0x12, 0x0e, 0x0a, 0x02, 0x69, 0x64, 0x18, 0x01, 0x20, 0x03, 0x28, 0x05, 0x52,
	0x02, 0x69, 0x64, 0x22, 0x1d, 0x0a, 0x0b, 0x53, 0x74, 0x72, 0x65, 0x61, 0x6d, 0x52, 0x65, 0x70,
	0x6c, 0x79, 0x12, 0x0e, 0x0a, 0x02, 0x69, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x05, 0x52, 0x02,
	0x69, 0x64, 0x32, 0x54, 0x0a, 0x04, 0x54, 0x65, 0x73, 0x74, 0x12, 0x20, 0x0a, 0x04, 0x4c, 0x6f,
	0x6e, 0x67, 0x12, 0x0c, 0x2e, 0x4c, 0x6f, 0x6e, 0x67, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74,
	0x1a, 0x0a, 0x2e, 0x4c, 0x6f, 0x6e, 0x67, 0x52, 0x65, 0x70, 0x6c, 0x79, 0x12, 0x2a, 0x0a, 0x0a,
	0x4c, 0x6f, 0x6e, 0x67, 0x53, 0x74, 0x72, 0x65, 0x61, 0x6d, 0x12, 0x0c, 0x2e, 0x4c, 0x6f, 0x6e,
	0x67, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x0c, 0x2e, 0x53, 0x74, 0x72, 0x65, 0x61,
	0x6d, 0x52, 0x65, 0x70, 0x6c, 0x79, 0x30, 0x01, 0x42, 0x27, 0x5a, 0x25, 0x67, 0x69, 0x74, 0x68,
	0x75, 0x62, 0x2e, 0x63, 0x6f, 0x6d, 0x2f, 0x62, 0x65, 0x6e, 0x63, 0x68, 0x5f, 0x73, 0x65, 0x72,
	0x76, 0x69, 0x63, 0x65, 0x73, 0x2f, 0x67, 0x6f, 0x6c, 0x61, 0x6e, 0x67, 0x2f, 0x67, 0x72, 0x70,
	0x63, 0x62, 0x06, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x33,
}

var (
	file_grpc_test_proto_rawDescOnce sync.Once
	file_grpc_test_proto_rawDescData = file_grpc_test_proto_rawDesc
)

func file_grpc_test_proto_rawDescGZIP() []byte {
	file_grpc_test_proto_rawDescOnce.Do(func() {
		file_grpc_test_proto_rawDescData = protoimpl.X.CompressGZIP(file_grpc_test_proto_rawDescData)
	})
	return file_grpc_test_proto_rawDescData
}

var file_grpc_test_proto_msgTypes = make([]protoimpl.MessageInfo, 3)
var file_grpc_test_proto_goTypes = []interface{}{
	(*LongRequest)(nil), // 0: LongRequest
	(*LongReply)(nil),   // 1: LongReply
	(*StreamReply)(nil), // 2: StreamReply
}
var file_grpc_test_proto_depIdxs = []int32{
	0, // 0: Test.Long:input_type -> LongRequest
	0, // 1: Test.LongStream:input_type -> LongRequest
	1, // 2: Test.Long:output_type -> LongReply
	2, // 3: Test.LongStream:output_type -> StreamReply
	2, // [2:4] is the sub-list for method output_type
	0, // [0:2] is the sub-list for method input_type
	0, // [0:0] is the sub-list for extension type_name
	0, // [0:0] is the sub-list for extension extendee
	0, // [0:0] is the sub-list for field type_name
}

func init() { file_grpc_test_proto_init() }
func file_grpc_test_proto_init() {
	if File_grpc_test_proto != nil {
		return
	}
	if !protoimpl.UnsafeEnabled {
		file_grpc_test_proto_msgTypes[0].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*LongRequest); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_grpc_test_proto_msgTypes[1].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*LongReply); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_grpc_test_proto_msgTypes[2].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*StreamReply); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
	}
	type x struct{}
	out := protoimpl.TypeBuilder{
		File: protoimpl.DescBuilder{
			GoPackagePath: reflect.TypeOf(x{}).PkgPath(),
			RawDescriptor: file_grpc_test_proto_rawDesc,
			NumEnums:      0,
			NumMessages:   3,
			NumExtensions: 0,
			NumServices:   1,
		},
		GoTypes:           file_grpc_test_proto_goTypes,
		DependencyIndexes: file_grpc_test_proto_depIdxs,
		MessageInfos:      file_grpc_test_proto_msgTypes,
	}.Build()
	File_grpc_test_proto = out.File
	file_grpc_test_proto_rawDesc = nil
	file_grpc_test_proto_goTypes = nil
	file_grpc_test_proto_depIdxs = nil
}
