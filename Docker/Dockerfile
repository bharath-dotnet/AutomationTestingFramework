# Use official .NET 8 SDK image to build and run tests
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install Chrome browser
RUN apt-get update && apt-get install -y \
    wget \
    gnupg \
    unzip \
    curl \
    && wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list \
    && apt-get update \
    && apt-get install -y google-chrome-stable \
    && rm -rf /var/lib/apt/lists/*

# Set working directory inside container
WORKDIR /app

# Copy project files into container
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Build the project
RUN dotnet build --configuration Release

# Set CI environment variable so BrowserFactory runs headless
ENV CI=true

# Run all tests
CMD ["dotnet", "test", "--configuration", "Release", "--logger", "trx;LogFileName=TestResults.trx"]
