# Base image
FROM mcr.microsoft.com/azure-sql-edge:latest

# Set environment variables
ENV ACCEPT_EULA=1
ENV MSSQL_SA_PASSWORD=s3cret-Ninja

# Create a directory for the SQL setup script
RUN mkdir -p /usr/src/app

# Copy the SQL script to the container
COPY setup.sql /usr/src/app/setup.sql

# Expose the SQL Server port
EXPOSE 1433

# Run SQL Server with the setup script execution command
CMD /bin/sh -c "/opt/mssql/bin/sqlservr & sleep 30s & /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i /usr/src/app/setup.sql && tail -f /dev/null"
