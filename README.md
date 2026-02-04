# Password-API
A C# console application that authenticates against a REST API, programmatically generates password variations to simulate a dictionary attack for testing, retrieves a temporary upload URL, zips files, and submits a CV package automatically via HTTP requests. It is built as a practical exercise in API integration, authentication flows, and automation.

## Requirements

You need to build an application that uploads your CV along with the code you write to a REST API as a ZIP file. However, before submitting anything, you must first authenticate with a separate REST API to obtain a temporary upload URL.

The challenge is that you’ve forgotten your password — or at least the exact spelling. You remember it being something like “password,” but it could also be “Password” or even “P@55w0rd.” You often substitute characters such as “a” with “@,” “s” with “5,” and “o” with “0,” though not consistently.

To solve this, you decide to write a small script that generates possible password variations and performs a dictionary-style attack against the authentication API until the correct password is found. Once authenticated, you’ll receive the temporary submission URL and can proceed with uploading your CV.
