FROM golang:1.18 as builder

ENV APP_HOME /go/src/testapp

WORKDIR "$APP_HOME"
COPY ./ .

RUN go mod download
RUN go mod verify
RUN go build -o testapp ./server

FROM golang:1.18

ENV APP_HOME /go/src/testapp
RUN mkdir -p "$APP_HOME"
WORKDIR "$APP_HOME"

COPY --from=builder "$APP_HOME"/testapp $APP_HOME

EXPOSE 8010
CMD ["./testapp"]