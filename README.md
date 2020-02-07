# How to run Postgres via docker to save stupid brain cells

``` bash
docker run --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -d postgres
```