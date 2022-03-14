FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
WORKDIR /app/InvitationPageAPI
RUN dotnet restore
RUN dotnet build "InvitationPage-backend.csproj" -c Release -o /app/build
WORKDIR /app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/out
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "InvitationPage-backend.dll"]