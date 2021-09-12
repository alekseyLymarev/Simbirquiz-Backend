FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimbirSquize/SimbirSquize.csproj", "SimbirSquize/"]
RUN dotnet restore "SimbirSquize/SimbirSquize.csproj"
COPY . .
WORKDIR "/src/SimbirSquize"
RUN dotnet build "SimbirSquize.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimbirSquize.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimbirSquize.dll"]
