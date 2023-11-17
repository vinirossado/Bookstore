FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Book.Client/Book.Client.csproj", "Book.Client/"]
RUN dotnet restore "Book.Client/Book.Client.csproj"
COPY . .
WORKDIR "/src/Book.Client"
RUN dotnet build "Book.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Book.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.Client.dll"]
