﻿FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

RUN apt-get update \
&& apt-get install -y --allow-unauthenticated \
    libc6-dev \
    libgdiplus \
    libx11-dev \
 && rm -rf /var/lib/apt/lists/*

COPY --from=build-env /app/out .
