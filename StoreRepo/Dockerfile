#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ARG ConnectionStrings__DefaultConnection
ENV ConnectionStrings__DefaultConnection=$ConnectionStrings__DefaultConnection

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StoreRepo/StoreRepo.csproj", "StoreRepo/"]
COPY ["ComponentRegister/ComponentRegister.csproj", "ComponentRegister/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infastructure/Infastructure.csproj", "Infastructure/"]
COPY ["Contraccts/Contracts.csproj", "Contraccts/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "./StoreRepo/./StoreRepo.csproj"
COPY . .
WORKDIR "/src/StoreRepo"
RUN dotnet build "./StoreRepo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StoreRepo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreRepo.dll"]