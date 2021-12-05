# Get the base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy the csproj and restore all of the nugets
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

EXPOSE 80

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HexagonalArchitecture.dll"]