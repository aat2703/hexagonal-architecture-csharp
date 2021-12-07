FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/QueueWorker/QueueWorker.csproj", "QueueWorker/"]
RUN dotnet restore "src/QueueWorker/QueueWorker.csproj"
COPY . .
WORKDIR "/src/QueueWorker"
RUN dotnet build "QueueWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QueueWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueueWorker.dll"]
