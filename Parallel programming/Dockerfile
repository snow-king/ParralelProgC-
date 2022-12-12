FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Parallel programming/Parallel programming.csproj", "Parallel programming/"]
RUN dotnet restore "Parallel programming/Parallel programming.csproj"
COPY . .
WORKDIR "/src/Parallel programming"
RUN dotnet build "Parallel programming.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Parallel programming.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parallel programming.dll"]
