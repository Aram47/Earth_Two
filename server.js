const express = require('express');
const path = require('path'); // Import the path module
const app = express();

// Serve static files from the 'public' directory
app.use(express.static(path.join(__dirname, '.')));

// Start the server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server is listening on port ${PORT}`);
});
