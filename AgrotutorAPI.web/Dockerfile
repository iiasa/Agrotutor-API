FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AgrotutorAPI.web/AgrotutorAPI.web.csproj", "AgrotutorAPI.web/"]
COPY ["AgrotutorAPI.Data.Postgresql/AgrotutorAPI.Data.Postgresql.csproj", "AgrotutorAPI.Data.Postgresql/"]
COPY ["AgrotutorAPI.Domain/AgrotutorAPI.Domain.csproj", "AgrotutorAPI.Domain/"]
COPY ["AgrotutorAPI.Dto/AgrotutorAPI.Dto.csproj", "AgrotutorAPI.Dto/"]
COPY ["AgrotutorAPI.Data.Contract/AgrotutorAPI.Data.Contract.csproj", "AgrotutorAPI.Data.Contract/"]
RUN dotnet restore "AgrotutorAPI.web/AgrotutorAPI.web.csproj"
COPY . .
WORKDIR "/src/AgrotutorAPI.web"
RUN dotnet build "AgrotutorAPI.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AgrotutorAPI.web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AgrotutorAPI.web.dll"]