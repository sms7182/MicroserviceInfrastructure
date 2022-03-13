#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 44332
ENV ASPNETCORE_URLS=http://*:44332


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FatalError.Communication/FatalError.Communication.csproj", "FatalError.Communication/"]
COPY ["FatalError.Communication.Contracts/FatalError.Communication.Contracts.csproj", "FatalError.Communication.Contracts/"]
COPY ["FatalError.Communication.SocialNetwork/FatalError.Communication.SocialNetwork.csproj", "FatalError.Communication.SocialNetwork/"]
RUN dotnet restore "FatalError.Communication/FatalError.Communication.csproj"
COPY . .
WORKDIR "/src/FatalError.Communication"
RUN dotnet build "FatalError.Communication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FatalError.Communication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FatalError.Communication.dll"]