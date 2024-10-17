// script.js

// =========================
// Hàm quản lý điều hướng giữa các section
// =========================
function showSection(sectionId) {
    const sections = document.querySelectorAll('.section');
    sections.forEach(section => {
        if (section.id === sectionId) {
            section.style.display = 'block';
        } else {
            section.style.display = 'none';
        }
    });
}

// =========================
// Hàm quản lý đăng ký và đăng nhập
// =========================

// Hàm để lấy danh sách người dùng từ LocalStorage
function getUsers() {
    const users = localStorage.getItem('users');
    return users ? JSON.parse(users) : [];
}

// Hàm để lưu danh sách người dùng vào LocalStorage
function saveUsers(users) {
    localStorage.setItem('users', JSON.stringify(users));
}

// Hàm để đăng ký người dùng mới
/*function handleRegister() {
    const form = document.getElementById('registerForm');
    if (form) {
        // Không cần lắng nghe sự kiện submit nữa
        const username = document.getElementById('username').value.trim();
        const password = document.getElementById('password').value.trim();

        if (username === '' || password === '') {
            alert('Vui lòng điền đầy đủ thông tin.');
            return;
        }

        const users = getUsers();
        const userExists = users.some(user => user.username === username);

        if (userExists) {
            alert('Tên người dùng đã tồn tại. Vui lòng chọn tên khác.');
            return;
        }

        const newUser = {
            username: username,
            password: password,
            koiProfiles: []
        };

        users.push(newUser);
        saveUsers(users);

        alert('Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.');
        showSection('login');
        updateNav();
    }
}*/




// Hàm để đăng nhập người dùng
/*
function handleLogin() {
    const form = document.getElementById('loginForm');
    if (form) {
        // Không cần lắng nghe sự kiện submit nữa
        const username = document.getElementById('loginUsername').value.trim();
        const password = document.getElementById('loginPassword').value.trim();

        const users = getUsers();
        const user = users.find(user => user.username === username && user.password === password);

        if (user) {
            // Lưu thông tin đăng nhập vào LocalStorage
            localStorage.setItem('loggedInUser', JSON.stringify(user));
            alert('Đăng nhập thành công!');
            showSection('profile');
            updateNav();
            displayUserProfile();
        } else {
            alert('Tên người dùng hoặc mật khẩu không chính xác.');
        }
    }
}*/



// Hàm để đăng xuất người dùng
function handleLogout() {
    localStorage.removeItem('loggedInUser');
    alert('Đăng xuất thành công!');
    showSection('home');
    updateNav();
}

// Hàm để cập nhật thanh navigation dựa trên trạng thái đăng nhập
function updateNav() {
    const user = getLoggedInUser();
    const navProfile = document.getElementById('nav-profile');
    const navLogout = document.getElementById('nav-logout');
    const navLogin = document.getElementById('nav-login');
    const navRegister = document.getElementById('nav-register');

    if (user) {
        navProfile.style.display = 'block';
        navLogout.style.display = 'block';
        navLogin.style.display = 'none';
        navRegister.style.display = 'none';
    } else {
        navProfile.style.display = 'none';
        navLogout.style.display = 'none';
        navLogin.style.display = 'block';
        navRegister.style.display = 'block';
    }
}

// =========================
// Hàm quản lý hồ sơ cá Koi
// =========================

// Hàm để lấy người dùng đang đăng nhập
function getLoggedInUser() {
    const user = localStorage.getItem('loggedInUser');
    return user ? JSON.parse(user) : null;
}

// Hàm để cập nhật người dùng trong LocalStorage
function updateLoggedInUser(user) {
    localStorage.setItem('loggedInUser', JSON.stringify(user));

    // Cập nhật danh sách người dùng
    const users = getUsers();
    const userIndex = users.findIndex(u => u.username === user.username);
    if (userIndex !== -1) {
        users[userIndex] = user;
        saveUsers(users);
    }
}

// Hàm để hiển thị hồ sơ cá Koi
/*
function displayUserProfile() {
    const user = getLoggedInUser();
    const profileDiv = document.getElementById('userProfile');

    if (!user) {
        profileDiv.innerHTML = '<p>Bạn chưa đăng nhập. Vui lòng <a href="#" data-section="login">đăng nhập</a> để xem hồ sơ.</p>';
        return;
    }

    let html = `<h3>Người Dùng: ${user.username}</h3>`;

    if (user.koiProfiles.length === 0) {
        html += '<p>Bạn chưa thêm hồ sơ cá Koi nào. <a href="#" data-section="add">Thêm cá Koi ngay</a>.</p>';
    } else {
        html += '<h4>Hồ Sơ Cá Koi:</h4>';
        user.koiProfiles.forEach((koi, index) => {
            html += `
                <div class="fish-item">
                    <img src="${koi.image}" alt="${koi.name}">
                    <div class="fish-details">
                        <h3>${koi.name}</h3>
                        <p>${koi.description}</p>
                        <button onclick="deleteKoi(${index})">Xóa</button>
                    </div>
                </div>
            `;
        });
    }

    profileDiv.innerHTML = html;
}
*/
// Hàm để xóa hồ sơ cá Koi
function deleteKoi(index) {
    const user = getLoggedInUser();
    if (!user) return;

    if (confirm('Bạn có chắc chắn muốn xóa hồ sơ cá Koi này?')) {
        user.koiProfiles.splice(index, 1);
        updateLoggedInUser(user);
        displayUserProfile();
    }
}

// =========================
// Hàm quản lý thêm cá Koi
// =========================

// Hàm để lấy danh sách cá Koi từ LocalStorage
function getFishes() {
    const fishes = localStorage.getItem('fishes');
    return fishes ? JSON.parse(fishes) : [];
}

// Hàm để lưu danh sách cá Koi vào LocalStorage
function saveFishes(fishes) {
    localStorage.setItem('fishes', JSON.stringify(fishes));
}

// Hàm để hiển thị danh sách cá Koi
function displayFishes(targetElementId) {
    const fishes = getFishes();
    const fishList = document.getElementById(targetElementId);
    fishList.innerHTML = '';

    if (fishes.length === 0) {
        fishList.innerHTML = '<p>Chưa có cá nào được thêm.</p>';
        return;
    }

    fishes.forEach((fish, index) => {
        const fishItem = document.createElement('div');
        fishItem.className = 'fish-item';

        const img = document.createElement('img');
        img.src = fish.image;
        img.alt = fish.name;

        const details = document.createElement('div');
        details.className = 'fish-details';

        const name = document.createElement('h3');
        name.textContent = fish.name;

        const description = document.createElement('p');
        description.textContent = fish.description;

        details.appendChild(name);
        details.appendChild(description);

        fishItem.appendChild(img);
        fishItem.appendChild(details);

        fishList.appendChild(fishItem);
    });
}

// Hàm để xử lý khi form được submit (Chỉ áp dụng cho trang Thêm Cá Koi)
function handleFormSubmit() {
    const form = document.getElementById('fishForm');
    if (form) {
        form.addEventListener('submit', function(e) {
            e.preventDefault();

            const name = document.getElementById('name').value.trim();
            const description = document.getElementById('description').value.trim();
            const imageInput = document.getElementById('image');

            if (imageInput.files && imageInput.files[0]) {
                const reader = new FileReader();

                reader.onload = function(event) {
                    const imageData = event.target.result;

                    const newFish = {
                        name: name,
                        description: description,
                        image: imageData
                    };

                    // Thêm cá vào LocalStorage
                    const fishes = getFishes();
                    fishes.push(newFish);
                    saveFishes(fishes);
                    displayFishes('fishes');

                    // Thêm cá vào hồ sơ người dùng nếu đăng nhập
                    const user = getLoggedInUser();
                    if (user) {
                        user.koiProfiles.push(newFish);
                        updateLoggedInUser(user);
                        displayUserProfile();
                    }

                    // Hiển thị cá nổi bật trên trang chủ
                    displayFeaturedFishes();

                    // Reset form
                    form.reset();
                };

                reader.readAsDataURL(imageInput.files[0]);
            } else {
                alert('Vui lòng chọn ảnh cho cá.');
            }
        });
    }
}

// =========================
// Hàm quản lý cuộc thi
// =========================

// Dữ liệu mẫu cho các cuộc thi
const sampleCompetitions = [
    {
        title: "Cuộc Thi Cá Koi Hè 2024",
        description: "Cuộc thi cá Koi diễn ra vào tháng 7 năm 2024.",
        date: "2024-07-15",
        status: "sắp diễn ra" // có thể là "đang diễn ra", "sắp diễn ra", "đã diễn ra"
    },
    {
        title: "Cuộc Thi Cá Koi Xuân 2024",
        description: "Cuộc thi cá Koi diễn ra vào tháng 4 năm 2024.",
        date: "2024-04-10",
        status: "đã diễn ra"
    },
    {
        title: "Cuộc Thi Cá Koi Thu 2024",
        description: "Cuộc thi cá Koi diễn ra vào tháng 10 năm 2024.",
        date: "2024-10-20",
        status: "đang diễn ra"
    }
];

// Hàm để lấy danh sách cuộc thi từ LocalStorage hoặc sử dụng dữ liệu mẫu
function getCompetitions() {
    const competitions = localStorage.getItem('competitions');
    if (competitions) {
        return JSON.parse(competitions);
    } else {
        // Nếu chưa có, sử dụng dữ liệu mẫu và lưu vào LocalStorage
        localStorage.setItem('competitions', JSON.stringify(sampleCompetitions));
        return sampleCompetitions;
    }
}

// Hàm để lưu danh sách cuộc thi vào LocalStorage
function saveCompetitions(competitions) {
    localStorage.setItem('competitions', JSON.stringify(competitions));
}

// Hàm để hiển thị danh sách cuộc thi
function displayCompetitions() {
    const competitions = getCompetitions();
    const competitionList = document.getElementById('competition-list');
    competitionList.innerHTML = '';

    if (competitions.length === 0) {
        competitionList.innerHTML = '<p>Chưa có cuộc thi nào được thêm.</p>';
        return;
    }

    competitions.forEach((competition, index) => {
        const competitionItem = document.createElement('div');
        competitionItem.className = 'competition-item';

        // Nếu có hình ảnh cho cuộc thi, bạn có thể thêm nó ở đây
        // Ví dụ:
        // const img = document.createElement('img');
        // img.src = competition.image;
        // img.alt = competition.title;
        // competitionItem.appendChild(img);

        const details = document.createElement('div');
        details.className = 'competition-details';

        const title = document.createElement('h3');
        title.textContent = competition.title;

        const description = document.createElement('p');
        description.textContent = competition.description;

        const date = document.createElement('p');
        date.textContent = `Ngày diễn ra: ${competition.date}`;

        const status = document.createElement('p');
        status.textContent = `Trạng thái: ${competition.status}`;

        details.appendChild(title);
        details.appendChild(description);
        details.appendChild(date);
        details.appendChild(status);

        competitionItem.appendChild(details);

        competitionList.appendChild(competitionItem);
    });
}

// Hàm để tìm kiếm cuộc thi
function searchCompetitions() {
    const query = document.getElementById('searchCompetition').value.toLowerCase();
    const competitions = getCompetitions();
    const filtered = competitions.filter(comp => comp.title.toLowerCase().includes(query) || comp.description.toLowerCase().includes(query));

    const competitionList = document.getElementById('competition-list');
    competitionList.innerHTML = '';

    if (filtered.length === 0) {
        competitionList.innerHTML = '<p>Không tìm thấy cuộc thi nào phù hợp.</p>';
        return;
    }

    filtered.forEach((competition, index) => {
        const competitionItem = document.createElement('div');
        competitionItem.className = 'competition-item';

        const details = document.createElement('div');
        details.className = 'competition-details';

        const title = document.createElement('h3');
        title.textContent = competition.title;

        const description = document.createElement('p');
        description.textContent = competition.description;

        const date = document.createElement('p');
        date.textContent = `Ngày diễn ra: ${competition.date}`;

        const status = document.createElement('p');
        status.textContent = `Trạng thái: ${competition.status}`;

        details.appendChild(title);
        details.appendChild(description);
        details.appendChild(date);
        details.appendChild(status);

        competitionItem.appendChild(details);

        competitionList.appendChild(competitionItem);
    });
}

// =========================
// Hàm quản lý trang chủ
// =========================

// Hàm để hiển thị các cá Koi nổi bật trên trang chủ (ví dụ: 3 cá đầu tiên)
function displayFeaturedFishes() {
    const fishes = getFishes();
    const fishList = document.getElementById('fishes-home');
    fishList.innerHTML = '';

    if (fishes.length === 0) {
        fishList.innerHTML = '<p>Chưa có cá nào được thêm.</p>';
        return;
    }

    // Hiển thị tối đa 3 cá
    const featured = fishes.slice(0, 3);

    featured.forEach((fish, index) => {
        const fishItem = document.createElement('div');
        fishItem.className = 'fish-item';

        const img = document.createElement('img');
        img.src = fish.image;
        img.alt = fish.name;

        const details = document.createElement('div');
        details.className = 'fish-details';

        const name = document.createElement('h3');
        name.textContent = fish.name;

        const description = document.createElement('p');
        description.textContent = fish.description;

        details.appendChild(name);
        details.appendChild(description);

        fishItem.appendChild(img);
        fishItem.appendChild(details);

        fishList.appendChild(fishItem);
    });
}

// =========================
// Hàm khởi động các chức năng khi tải trang
// =========================
document.addEventListener('DOMContentLoaded', function() {
    // Xử lý navigation
    const navLinks = document.querySelectorAll('nav ul li a');
    navLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const section = this.getAttribute('data-section');
            if (section === 'logout') {
                handleLogout();
            } else {
                showSection(section);
            }
        });
    });

    // Kiểm tra đăng nhập để cập nhật navigation và hiển thị trang phù hợp
    updateNav();
    const user = getLoggedInUser();
    if (user) {
        showSection('profile');
        displayUserProfile();
    } else {
        showSection('home');
        displayFeaturedFishes();
    }

    // Xử lý các chức năng
    handleRegister();
    handleLogin();
    handleFormSubmit();
    displayCompetitions();
});

// =========================
// Hàm tìm kiếm và hiển thị cuộc thi theo thời gian thực
// =========================

// Hàm để cập nhật trạng thái cuộc thi dựa trên ngày hiện tại
function updateCompetitionStatuses() {
    const competitions = getCompetitions();
    const today = new Date().toISOString().split('T')[0];

    competitions.forEach(comp => {
        if (comp.date > today) {
            comp.status = "sắp diễn ra";
        } else if (comp.date === today) {
            comp.status = "đang diễn ra";
        } else {
            comp.status = "đã diễn ra";
        }
    });

    saveCompetitions(competitions);
}

// Gọi hàm cập nhật trạng thái cuộc thi khi tải trang
updateCompetitionStatuses();
displayCompetitions();

// =========================
// Hàm quản lý thêm và hiển thị cá Koi cho người dùng
// =========================

/* 
Đã tích hợp trong các hàm trên:
- Thêm cá Koi vào LocalStorage và hồ sơ cá Koi của người dùng nếu đã đăng nhập.
- Hiển thị danh sách cá Koi trên trang Thêm Cá và Trang Chủ.
- Hiển thị và quản lý hồ sơ cá Koi trên trang Hồ Sơ Cá Koi.
*/
