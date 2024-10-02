FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine
WORKDIR /src
COPY ["tests/e2e/e2e.csproj", "tests/e2e/"]
RUN dotnet restore "tests/e2e/e2e.csproj"
COPY . .
WORKDIR "/src/tests/e2e"
ENTRYPOINT ["dotnet", "test", "--no-restore"]