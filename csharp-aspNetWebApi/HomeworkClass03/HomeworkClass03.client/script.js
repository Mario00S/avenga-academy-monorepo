const baseUrl = "https://localhost:7113/api/books"; 

function renderTable(data, tableId) {
  const table = document.getElementById(tableId);
  table.innerHTML = "";

  if (!data || (Array.isArray(data) && data.length === 0)) {
    table.innerHTML = "<tr><td>No results found</td></tr>";
    return;
  }

  // Normalize to array
  const books = Array.isArray(data) ? data : [data];

  // Header
  table.innerHTML = `
    <tr>
      <th>Title</th>
      <th>Author</th>
      <th>Year</th>
    </tr>
  `;

  // Rows
  books.forEach(book => {
    table.innerHTML += `
      <tr>
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td>${book.year}</td>
      </tr>
    `;
  });
}

async function getBooks() {
  const index = document.getElementById("indexInput").value;
  const url = index ? `${baseUrl}?index=${index}` : baseUrl;
  const res = await fetch(url);
  const data = await res.json();
  renderTable(data, "getTable");
}

async function searchBooks() {
  const author = document.getElementById("authorInput").value;
  const title = document.getElementById("titleInput").value;
  const params = new URLSearchParams();
  if (author) params.append("author", author);
  if (title) params.append("title", title);
  const url = `${baseUrl}/search?${params.toString()}`;
  const res = await fetch(url);
  const data = await res.json();
  renderTable(data, "searchTable");
}

async function addBook() {
  const book = {
    title: document.getElementById("newTitle").value,
    author: document.getElementById("newAuthor").value,
    year: parseInt(document.getElementById("newYear").value)
  };
  const res = await fetch(baseUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(book)
  });
  const data = await res.json();
  renderTable(data, "postTable");
}
