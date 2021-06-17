#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Backend/Backend.csproj", "Backend/"]
COPY ["Services1/Services.csproj", "Services1/"]
COPY ["ServiceContracts1/ServiceContracts.csproj", "ServiceContracts1/"]
COPY ["RepositoryServiceContract1/RepositoryServiceContract.csproj", "RepositoryServiceContract1/"]
COPY ["Repositories1/Repositories.csproj", "Repositories1/"]
RUN dotnet restore "Backend/Backend.csproj"
COPY . .
WORKDIR "/src/Backend"
RUN dotnet build "Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]