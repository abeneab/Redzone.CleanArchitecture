#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Redzone.API/Redzone.API.csproj", "Redzone.API/"]
COPY ["Redzone.Domain/Redzone.Domain.csproj", "Redzone.Domain/"]
COPY ["Redzone.Infrastructure/Redzone.Infrastructure.csproj", "Redzone.Infrastructure/"]
COPY ["Redzone.Application/Redzone.Application.csproj", "Redzone.Application/"]
RUN dotnet restore "Redzone.API/Redzone.API.csproj"
COPY . .
WORKDIR "/src/Redzone.API"
RUN dotnet build "Redzone.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Redzone.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Redzone.API.dll"]