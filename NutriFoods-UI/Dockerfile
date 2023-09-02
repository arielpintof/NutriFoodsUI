FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NutriFoods-UI/NutriFoods-UI.csproj", "NutriFoods-UI/"]
RUN dotnet restore "NutriFoods-UI/NutriFoods-UI.csproj"
COPY . .
WORKDIR "/src/NutriFoods-UI"
RUN dotnet build "NutriFoods-UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NutriFoods-UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NutriFoods-UI.dll"]
