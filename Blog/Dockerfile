# Step 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Blog/Blog.csproj", "./Blog/"]
RUN dotnet restore "./Blog/Blog.csproj"

# Copy all project files and build the application
COPY Blog/. ./Blog/
WORKDIR /src/Blog
RUN dotnet publish -c Release -o /app/publish

# Step 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy build artifacts from the build stage
COPY --from=build /app/publish .

# Expose HTTP port
EXPOSE 80

# Launch the app
ENTRYPOINT ["dotnet", "Blog.dll"]
