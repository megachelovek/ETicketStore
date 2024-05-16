#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ETicketStore.Api.Admin/ETicketStore.Api.Admin.csproj", "ETicketStore.Api.Admin/"]
RUN dotnet restore "./ETicketStore.Api.Admin/ETicketStore.Api.Admin.csproj"
COPY . .
WORKDIR "/src/ETicketStore.Api.Admin"
RUN dotnet build "./ETicketStore.Api.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ETicketStore.Api.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETicketStore.Api.Admin.dll"]