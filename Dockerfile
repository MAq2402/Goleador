#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV environment=docker
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Goleador.Web/Goleador.Web.csproj", "Goleador.Web/"]
COPY ["Goleador.Application.Shared/Goleador.Application.Shared.csproj", "Goleador.Application.Shared/"]
COPY ["Goleador.Application.Write/Goleador.Application.Write.csproj", "Goleador.Application.Write/"]
COPY ["Goleador.Application.Messages/Goleador.Application.Messages.csproj", "Goleador.Application.Messages/"]
COPY ["Goleador.Application.Read/Goleador.Application.Read.csproj", "Goleador.Application.Read/"]
COPY ["Goleador.Infrastructure/Goleador.Infrastructure.csproj", "Goleador.Infrastructure/"]
COPY ["Goleador.Domain/Goleador.Domain.csproj", "Goleador.Domain/"]
RUN dotnet restore "Goleador.Web/Goleador.Web.csproj"
COPY . .
WORKDIR "/src/Goleador.Web"
RUN dotnet build "Goleador.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Goleador.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Goleador.Web.dll"]