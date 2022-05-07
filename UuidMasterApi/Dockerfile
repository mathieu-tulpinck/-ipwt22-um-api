#  This stage defines the base image that will be used to run your application. It contains the minimal dependencies to run your application.
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000
# EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# This stage defines the docker image that will be used to build your application. It includes the full .NET SDK, as well as various other dependencies. This stage actually builds your application.
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["UuidMasterApi.csproj", "./"]
RUN dotnet restore "UuidMasterApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "UuidMasterApi.csproj" -c Release -o /app/build

# This stage is used to publish your application.
FROM build AS publish
RUN dotnet publish "UuidMasterApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# The final stage is what you would actually deploy to production. It is based on the base image, but with the publish assets copied in.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UuidMasterApi.dll"]
