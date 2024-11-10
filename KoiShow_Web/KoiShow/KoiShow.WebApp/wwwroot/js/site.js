async function getUsers() {
    try {
        const username = document.getElementById('username').value.trim(); // Lấy tên người dùng từ form
        const response = await fetch(`/Register/CheckUsername?username=${username}`);  // Đảm bảo URL này chính xác với Razor Page
        if (response.ok) {
            const result = await response.json();
            return result.exists;  // Trả về true/false nếu tên người dùng tồn tại hay không
        } else {
            console.error('Lỗi khi lấy dữ liệu người dùng:', response.statusText);
            return false;
        }
    } catch (error) {
        console.error('Lỗi:', error);
        return false;
    }
}

// Hàm xử lý sự kiện khi người dùng nhấn Đăng ký
async function handleRegister() {
    const form = document.getElementById('registerForm');
    if (form) {
        const username = document.getElementById('username').value.trim();
        const password = document.getElementById('password').value.trim();
        const passwordAgain = document.getElementById('passwordAgain').value.trim();

        if (username === '' || password === '' || passwordAgain === '') {
            alert('Vui lòng điền đầy đủ thông tin.');
            return;
        }

        const userExists = await getUsers(); // Kiểm tra tên người dùng có tồn tại hay không

        if (userExists) {
            alert('Tên người dùng đã tồn tại. Vui lòng chọn tên khác.');
            return;
        }
        if (password !== passwordAgain) {
            alert('Mật khẩu không trùng khớp');
            return;
        }

        const newUser = {
            username: username,
            password: password
        };

        await saveUser(newUser); // Gọi API để lưu người dùng mới
    }
}
