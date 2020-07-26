FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Registone.LogCenter.Api/Registone.LogCenter.Api.csproj", "Registone.LogCenter.Api/"]
COPY ["Registone.LogCenter.Domain/Registone.LogCenter.Domain.csproj", "Registone.LogCenter.Domain/"]
COPY ["Registone.LogCenter.Services/Registone.LogCenter.Services.csproj", "Registone.LogCenter.Services/"]
COPY ["Registone.LogCenter.Data/Registone.LogCenter.Data/Registone.LogCenter.Data.csproj", "Registone.LogCenter.Data/Registone.LogCenter.Data/"]
RUN dotnet restore "Registone.LogCenter.Api/Registone.LogCenter.Api.csproj"
COPY . .
WORKDIR "/src/Registone.LogCenter.Api"
RUN dotnet build "Registone.LogCenter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Registone.LogCenter.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Registone.LogCenter.Api.dll