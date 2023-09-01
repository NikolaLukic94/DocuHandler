#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DocumentTemplate.API/DocumentTemplate.API.csproj", "DocumentTemplate.API/"]
COPY ["DocumentTemplate.Contracts/DocumentTemplate.Contracts.csproj", "DocumentTemplate.Contracts/"]
COPY ["DocumentTemplate.Application/DocumentTemplate.Application.csproj", "DocumentTemplate.Application/"]
COPY ["DocumentTemplate.Domain/DocumentTemplate.Domain.csproj", "DocumentTemplate.Domain/"]
COPY ["DocumentTemplate.Infrastructure/DocumentTemplate.Infrastructure.csproj", "DocumentTemplate.Infrastructure/"]
RUN dotnet restore "DocumentTemplate.API/DocumentTemplate.API.csproj"
COPY . .
WORKDIR "/src/DocumentTemplate.API"
RUN dotnet build "DocumentTemplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocumentTemplate.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocumentTemplate.API.dll"]