# Use the official Node.js image with the specified version
FROM node:14.17.6

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json first to leverage Docker cache
COPY ./Frontend/package*.json ./

# Install dependencies only if package.json has changed
RUN npm install --quiet

# Copy the rest of the application code
COPY ./Frontend ./

# Expose port 3000
EXPOSE 3000

# Command to start the application
CMD ["npm", "start"]