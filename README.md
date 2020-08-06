
<h1>Task</h1>

1. Chỉnh UI Scene Main cho phù hợp với màn hình dài hơn (9:16), ví dụ như iphone X (90:195).

2. Tạo Cheat Menu bí mật để cộng tiền và cộng vật phẩm trên bản build apk.

3. Thêm particle nhiều sao bay lên sau khi mua item trong store.

4. Thêm hiệu ứng tween popup chuyển động khi xuất hiện trong Scene Main.

5. Trong Scene Main, thay con mèo bằng nhân vật Arisa trong package bên dưới, thực hiện animation “Macarena Dance” từ Mixamo. Cải thiện màu sắc nhân vật cho phù hợp với theme game.
https://assetstore.unity.com/packages/3d/characters/anime-character-arisa-free-164251

6. Tạo project Firebase và gắn Realtime Database, lưu thông tin số coins của Player với ID là Device ID.

7. Nêu một số hướng cải thiện hiệu năng của game. Đánh giá ưu nhược điểm của thiết kế, tổ chức project. Đề xuất cách tổ chức project của bạn.

<h1>Note</h1>

Task 2. Click vào tiêu đề Store của Store để hiện Cheat Menu

Task 7.

* Một số hướng để cải thiện hiệu năng của game.

  * Em thấy game có sử dụng Object Pooling để quản lý item Fishbone, theo em nên giảm kích thước của pool xuống vì em thấy nhiều item được instance nhưng không được sử dụng.
  
  * Phần Store có thể để luôn trong phần Main Scene lúc cần thì active tránh phải load scene.
  
 
  
* Ưu nhược điểm của thiết kế, tổ chức project.

  * Ưu điểm: các mục để chia tách rõ ràng..
  
  * Nhược điểm: nhiều thư mục trùng nhau do được import từ nhiều package khác nhau nên khó khăn lúc tìm kiếm.

 `Cách tổ chức project của em`

- Assets
  - Scenes
  - Scripts
  - Prefabs
  - Libs
  - Editor
  - Data
    - Sprites
    - Models
    - Animations
    - Materials
    - Shaders
    - Audios
