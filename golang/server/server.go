/*
 *
 * Copyright 2015 gRPC authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

// Package main implements a simple gRPC server that demonstrates how to use gRPC-Go libraries
// to perform unary, client streaming, server streaming and full duplex RPCs.
//
// It implements the route guide service whose definition can be found in routeguide/route_guide.proto.
package main

import (
	"context"
	"flag"
	"fmt"
	"log"
	"net"

	pb "github.com/bench_services/golang/grpc"
	"google.golang.org/grpc"
)

var (
	tls        = flag.Bool("tls", false, "Connection uses TLS if true, else plain TCP")
	certFile   = flag.String("cert_file", "", "The TLS cert file")
	keyFile    = flag.String("key_file", "", "The TLS key file")
	jsonDBFile = flag.String("json_db_file", "", "A json file containing a list of features")
	port       = flag.Int("port", 50051, "The server port")
)

type routeGuideServer struct {
	pb.UnimplementedTestServer
}

func (s *routeGuideServer) Long(_ context.Context, request *pb.LongRequest) (*pb.LongReply, error) {
	response := &pb.LongReply{}

	response.Id = make([]int32, request.Count)
	for i := int32(1); i < request.Count; i++ {
		response.Id[i] = i
	}

	return response, nil
}

func (s *routeGuideServer) LongStream(request *pb.LongRequest, stream pb.Test_LongStreamServer) error {
	for i := int32(1); i < request.Count; i++ {
		if err := stream.Send(&pb.StreamReply{Id: i}); err != nil {
			return err
		}
	}
	return nil
}

func newServer() *routeGuideServer {
	return &routeGuideServer{}
}

func main() {
	flag.Parse()
	lis, err := net.Listen("tcp", fmt.Sprintf("localhost:%d", *port))
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	var opts []grpc.ServerOption
	grpcServer := grpc.NewServer(opts...)
	pb.RegisterTestServer(grpcServer, newServer())
	grpcServer.Serve(lis)
}
