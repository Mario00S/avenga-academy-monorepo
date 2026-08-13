// Function: Fetch all users
function getAllUsers() {
    fetch('https://localhost:7125/api/User/users', {
        method: 'GET'
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        const list = document.getElementById('userList');
        list.innerHTML = ''; // clear old entries
        data.forEach((user, index) => {
            const li = document.createElement('li');
            li.textContent = `ID ${index}: ${user}`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        console.error('Error:', error);
        document.getElementById('userList').innerText = `Error: ${error.message}`;
    });
}

// Function: Fetch a single user by ID
function getUserById(userId) {
    fetch(`https://localhost:7125/api/User/${userId}`, {
        method: 'GET'
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        console.log('Response object:', data);
        document.getElementById('result').innerText = `User: ${data.user}`;
    })
    .catch(error => {
        console.error('Error:', error);
        document.getElementById('result').innerText = `Error: ${error.message}`;
    });
}

// Wire functions to DOM events
document.getElementById('loadUsers').addEventListener('click', getAllUsers);

document.getElementById('userForm').addEventListener('submit', function(event) {
    event.preventDefault();
    const userId = document.getElementById('userId').value;
    getUserById(userId);
});
