#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AgrotutorAPI.web/AgrotutorAPI.web.csproj", "AgrotutorAPI.web/"]
COPY ["AgrotutorAPI.Data.Postgresql/AgrotutorAPI.Data.Postgresql.csproj", "AgrotutorAPI.Data.Postgresql/"]
COPY ["AgrotutorAPI.Domain/AgrotutorAPI.Domain.csproj", "AgrotutorAPI.Domain/"]
COPY ["AgrotutorAPI.Dto/AgrotutorAPI.Dto.csproj", "AgrotutorAPI.Dto/"]
COPY ["AgrotutorAPI.Data.Contract/AgrotutorAPI.Data.Contract.csproj", "AgrotutorAPI.Data.Contract/"]
RUN dotnet restore "AgrotutorAPI.web/AgrotutorAPI.web.csproj"
COPY . .
WORKDIR "/src/AgrotutorAPI.web"
RUN dotnet build "AgrotutorAPI.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgrotutorAPI.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgrotutorAPI.web.dll"]