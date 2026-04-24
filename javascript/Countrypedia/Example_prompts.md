# 🤖 AI Assistance – Example Copilot Prompts for CountrySearch App

You are **allowed and encouraged** to use AI tools such as **GitHub Copilot** or **ChatGPT** while working on this exercise.

⚠️ **Important rules when using AI:**
- Always think about the solution **before** asking AI
- Review the generated code carefully
- Test edge cases (empty input, no results, API errors)
- Do NOT blindly copy-paste — understand what the code does

// NOTE: This file is only an example of how to prompt Copilot and use AI tools; students should understand and write their own code.

---


## 🧠 Step-by-step Suggested Copilot Chat Prompts

### 1️⃣ Project Setup

**Prompt:**
> 🤖 "Create a simple HTML structure for a country search app with an input, a search button, and a container for country cards."

**Follow-up Prompt:**
> 🤖 "Add a script.js file and connect it to the HTML."

---

### 2️⃣ Fetch Countries by Name / Partial Name

**Prompt:**
> 🤖 "Write a JavaScript function that fetches countries from the Rest Countries API based on a name or partial name."

**Follow-up Prompt:**
> 🤖 "Handle errors when no country is found or the API request fails."

---

### 3️⃣ Display Countries as Cards

**Prompt:**
> 🤖 "Generate JavaScript code that dynamically creates country cards showing flag, name, population, capital, and a Wikipedia link."

**Follow-up Prompt:**
> 🤖 "Create a reusable function that accepts an array of countries and renders cards into the DOM."

---

### 4️⃣ Search Button Logic

**Prompt:**
> 🤖 "Add an event listener to the search button that reads the input value and calls the fetch function."

**Follow-up Prompt:**
> 🤖 "Prevent page reload when clicking the search button."

---

## 🌍 Extra Requirements – Example Copilot Prompts

### Button 1: Get All European Countries

**Prompt:**
> 🤖 "Write a function that fetches all countries from Europe using the Rest Countries API."

---

### Button 2: Get Neighbors of Macedonia

**Prompt:**
> 🤖 "Fetch Macedonia by country code and then fetch all bordering countries using the borders property."

**Follow-up Prompt:**
> 🤖 "Chain API calls so that after getting Macedonia, its neighbors are fetched and displayed."

---

### Button 3: Get Macedonia Only

**Prompt:**
> 🤖 "Write a function that fetches and displays Macedonia only using its country code."

---

## 🧩 Code-Level Example Copilot Instructions (Paste in JS File as Comments)

```js
// Create a function that fetches countries based on search input
// Create a function that renders country cards into the DOM
// Add event listener for search button
// Add event listener for 'Europe' button
// Add event listener for 'Macedonia' button
// Add event listener for 'Neighbors of Macedonia' button
// Handle API errors and empty results gracefully
