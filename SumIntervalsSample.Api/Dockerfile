#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SumIntervalsSample.Api/SumIntervalsSample.Api.csproj", "SumIntervalsSample.Api/"]
RUN dotnet restore "SumIntervalsSample.Api/SumIntervalsSample.Api.csproj"
COPY . .
WORKDIR "/src/SumIntervalsSample.Api"
RUN dotnet build "SumIntervalsSample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SumIntervalsSample.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SumIntervalsSample.Api.dll"]