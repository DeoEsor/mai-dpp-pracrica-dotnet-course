FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MAI.DPP.Practicum/MAI.DPP.Practicum.csproj", "MAI.DPP.Practicum/"]
RUN dotnet restore "MAI.DPP.Practicum/MAI.DPP.Practicum.csproj"
COPY . .
WORKDIR "/src/MAI.DPP.Practicum"
RUN dotnet build "MAI.DPP.Practicum.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MAI.DPP.Practicum.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAI.DPP.Practicum.dll"]
