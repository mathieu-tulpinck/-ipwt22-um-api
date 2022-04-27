#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UuidMaster.API/UuidMaster.API.csproj", "UuidMaster.API/"]
RUN dotnet restore "UuidMaster.API/UuidMaster.API.csproj"
COPY . .
WORKDIR "/src/UuidMaster.API"
RUN dotnet build "UuidMaster.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UuidMaster.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UuidMaster.API.dll"]