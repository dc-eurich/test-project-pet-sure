FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 64604
EXPOSE 44345

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY PetManagementService/PetManagementService.csproj PetManagementService/
RUN dotnet restore PetManagementService/PetManagementService.csproj
COPY . .
WORKDIR /src/PetManagementService
RUN dotnet build PetManagementService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PetManagementService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PetManagementService.dll"]
