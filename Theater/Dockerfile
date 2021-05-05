#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Theater/Theater.csproj", "Theater/"]
COPY ["Theater.Models/Theater.Models.csproj", "Theater.Models/"]
COPY ["Theater.BL/Theater.BL.csproj", "Theater.BL/"]
COPY ["Theater.DAL/Theater.DAL.csproj", "Theater.DAL/"]
RUN dotnet restore "Theater/Theater.csproj"
COPY . .
WORKDIR "/src/Theater"
RUN dotnet build "Theater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Theater.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "s.dll"]