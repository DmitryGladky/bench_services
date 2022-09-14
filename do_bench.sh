#/bin/sh

DURATION=10s
THREADS=6
CONNTECTIONS=6
BENCH_DIR=results

if ! command -v ghz &>/dev/null; then
  echo "ghz could not be found"
  exit
fi

if ! command -v ghz &>/dev/null; then
  echo "wrk could not be found"
  exit
fi

docker-compose up -d --build

mkdir -p $BENCH_DIR

function ghz_call {
  ghz --insecure \
    --proto ./shared/grpc/test.proto \
    --call $3 \
    -d "{\"count\":$2}" \
    -z $DURATION --skipFirst 10 --connections=$CONNTECTIONS \
    localhost:$1 >"$BENCH_DIR/$4.$2.log"
}

function grpc_bench {
  for c in 1 10 100 1000 10000; do
    ghz_call $1 $c $2 $3
  done
}

function wrk_call {
  wrk -t$THREADS -c$CONNTECTIONS -d$DURATION \
    http://localhost:$1/test/long_response/$2 >"$BENCH_DIR/$3.$2.log"
}

function rest_bench {
  for c in 1 10 100 1000 10000; do
    wrk_call "$1" $c "$2"
  done
}

grpc_bench 6001 Test.Long golang.grpc
grpc_bench 6001 Test.LongStream golang.grpc.stream
grpc_bench 5001 Test.Long dotnet.grpc
grpc_bench 5001 Test.LongStream dotnet.grpc.stream

rest_bench 5002 dotnet.json
docker-compose down
