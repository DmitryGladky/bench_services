// Code generated by protoc-gen-go-grpc. DO NOT EDIT.
// versions:
// - protoc-gen-go-grpc v1.2.0
// - protoc             v3.21.5
// source: grpc/test.proto

package grpc

import (
	context "context"
	grpc "google.golang.org/grpc"
	codes "google.golang.org/grpc/codes"
	status "google.golang.org/grpc/status"
)

// This is a compile-time assertion to ensure that this generated file
// is compatible with the grpc package it is being compiled against.
// Requires gRPC-Go v1.32.0 or later.
const _ = grpc.SupportPackageIsVersion7

// TestClient is the client API for Test service.
//
// For semantics around ctx use and closing/ending streaming RPCs, please refer to https://pkg.go.dev/google.golang.org/grpc/?tab=doc#ClientConn.NewStream.
type TestClient interface {
	Long(ctx context.Context, in *LongRequest, opts ...grpc.CallOption) (*LongReply, error)
	LongStream(ctx context.Context, in *LongRequest, opts ...grpc.CallOption) (Test_LongStreamClient, error)
}

type testClient struct {
	cc grpc.ClientConnInterface
}

func NewTestClient(cc grpc.ClientConnInterface) TestClient {
	return &testClient{cc}
}

func (c *testClient) Long(ctx context.Context, in *LongRequest, opts ...grpc.CallOption) (*LongReply, error) {
	out := new(LongReply)
	err := c.cc.Invoke(ctx, "/Test/Long", in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *testClient) LongStream(ctx context.Context, in *LongRequest, opts ...grpc.CallOption) (Test_LongStreamClient, error) {
	stream, err := c.cc.NewStream(ctx, &Test_ServiceDesc.Streams[0], "/Test/LongStream", opts...)
	if err != nil {
		return nil, err
	}
	x := &testLongStreamClient{stream}
	if err := x.ClientStream.SendMsg(in); err != nil {
		return nil, err
	}
	if err := x.ClientStream.CloseSend(); err != nil {
		return nil, err
	}
	return x, nil
}

type Test_LongStreamClient interface {
	Recv() (*StreamReply, error)
	grpc.ClientStream
}

type testLongStreamClient struct {
	grpc.ClientStream
}

func (x *testLongStreamClient) Recv() (*StreamReply, error) {
	m := new(StreamReply)
	if err := x.ClientStream.RecvMsg(m); err != nil {
		return nil, err
	}
	return m, nil
}

// TestServer is the server API for Test service.
// All implementations must embed UnimplementedTestServer
// for forward compatibility
type TestServer interface {
	Long(context.Context, *LongRequest) (*LongReply, error)
	LongStream(*LongRequest, Test_LongStreamServer) error
	mustEmbedUnimplementedTestServer()
}

// UnimplementedTestServer must be embedded to have forward compatible implementations.
type UnimplementedTestServer struct {
}

func (UnimplementedTestServer) Long(context.Context, *LongRequest) (*LongReply, error) {
	return nil, status.Errorf(codes.Unimplemented, "method Long not implemented")
}
func (UnimplementedTestServer) LongStream(*LongRequest, Test_LongStreamServer) error {
	return status.Errorf(codes.Unimplemented, "method LongStream not implemented")
}
func (UnimplementedTestServer) mustEmbedUnimplementedTestServer() {}

// UnsafeTestServer may be embedded to opt out of forward compatibility for this service.
// Use of this interface is not recommended, as added methods to TestServer will
// result in compilation errors.
type UnsafeTestServer interface {
	mustEmbedUnimplementedTestServer()
}

func RegisterTestServer(s grpc.ServiceRegistrar, srv TestServer) {
	s.RegisterService(&Test_ServiceDesc, srv)
}

func _Test_Long_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(LongRequest)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(TestServer).Long(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/Test/Long",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(TestServer).Long(ctx, req.(*LongRequest))
	}
	return interceptor(ctx, in, info, handler)
}

func _Test_LongStream_Handler(srv interface{}, stream grpc.ServerStream) error {
	m := new(LongRequest)
	if err := stream.RecvMsg(m); err != nil {
		return err
	}
	return srv.(TestServer).LongStream(m, &testLongStreamServer{stream})
}

type Test_LongStreamServer interface {
	Send(*StreamReply) error
	grpc.ServerStream
}

type testLongStreamServer struct {
	grpc.ServerStream
}

func (x *testLongStreamServer) Send(m *StreamReply) error {
	return x.ServerStream.SendMsg(m)
}

// Test_ServiceDesc is the grpc.ServiceDesc for Test service.
// It's only intended for direct use with grpc.RegisterService,
// and not to be introspected or modified (even as a copy)
var Test_ServiceDesc = grpc.ServiceDesc{
	ServiceName: "Test",
	HandlerType: (*TestServer)(nil),
	Methods: []grpc.MethodDesc{
		{
			MethodName: "Long",
			Handler:    _Test_Long_Handler,
		},
	},
	Streams: []grpc.StreamDesc{
		{
			StreamName:    "LongStream",
			Handler:       _Test_LongStream_Handler,
			ServerStreams: true,
		},
	},
	Metadata: "grpc/test.proto",
}
