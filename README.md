# NamelessWeb
Welcome to the NamelessWeb wiki!

chả có gì để coi đâu

web bán đàn guitar nhật second hand
hong có dư dả hàng như shopee hay lazada đâu
nghĩ nó như chợ tốt ấy, có gì bán nấy
cái gì bán rồi thì hiện vào mục đã bán rồi thôi
còn lại tồn kho thì hiện ra trong trang chủ và
kho hàng.

Team BE:

+Hoạt động liên quan tới khách hàng

khách hàng tự đăng ký tài khoản
đặt mua, sau đó, nhân viên sẽ vào mục check đặt hàng
gọi điện cho khách và giải thích cho khách các phương thức đặt mua

1/ Nếu khách chọn thanh toán trực tiếp thì hiện lên giữ hàng và đếm ngược 5 ngày, sau 5 ngày hoặc từ chối không lấy thì quay lại trạng thái còn tồn. 
    Note: cho phép admin có thể xóa đặt hàng ngay
2/ Nếu chọn thanh toán online thì nhân viên sẽ hướng dẫn giúp khách chuyển khoảng
và sau khi chuyển khoảng thành công nhân viên thông báo cho khách đã nhận và ship cho khách
    Note: hóa đơn phải có chỗ điền mã số bưu phẩm
3/ Khách hàng được phép xem lại các đơn hàng mình đã mua

#Nếu làm dạng đơn hàng thì cần thay đổi giao diện và giải thuật/cấu trúc db, nếu có ý kiên thì xin kiến nghị.

+Hoạt động liên quan tới nhân viên

nhân viên được admin thêm vào
nhân viên được quyền xử lý đơn hàng, thay đổi thông tin cá nhân, gửi note kiến nghị cho shop xem

^ Liên quan tới ca làm việc
1/Mỗi thứ 4 sẽ mở box đặt ca làm việc, mỗi nhân viên sẽ tick vào 1 bảng phân ra 7 ngày và 2 ca, 
lưu biến như thế nào thì tùy team quyết định
2/Admin sẽ vào check ai đã đăng ký ca nào và phân bố lịch cho đầy đủ, bản thân ca trống thì vẫn cho phép, vì ca trống đồng nghĩa admin đứng chính không nv
# Note: 1 ca có thể có max 3 nhân viên.
^ Liên quan tới giúp đỡ khách hàng
1/ Tra thông tin khách hàng đã mua gì



+ Hoạt động cửa hàng cho admin

^ Liên quan tới việc thu chi của cửa hàng
1/ Cần có 1 bộ chức năng thống kê thu chi cửa hàng, tính ca, phát lương, tổng thu hoạch hằng tháng, hàng năm
   note: đương nhiên sẽ có trường hợp nhân viên đăng ký nhưng vắng vì lí do khách quan hoặc chủ quan, nên admin được phép chỉnh sửa
2/ Phải xuất ra được file excel
3/ khi hoàn tất đơn hàng yêu cầu gửi email báo cho khách hàng

^ Liên quan tới quản lý nhân viên
1/ thêm xóa sửa nhân viên
2/ xem top 5 nhân viên bán nhiều nhất (theo tháng)
3/ xem nhân viên đi làm nhiều nhất (theo tháng)


Những gì đã làm xong:

thêm xóa sửa sản phẩm,
thêm xóa sửa nhân viên,
đăng ký riêng cho người dùng,
chỉnh sửa thông tin người dùng




team FE:

Giao diện:
- các nút button, chỉnh sửa lại tạo cảm giác lồi 3d khi nhấn có cảm giác bị lõm xuống, đổi màu nếu được
- slider nhận hình theo server hình online
- trong mục chi tiết sản phẩm làm kiểu grid, nhiều hình (hiện tại chỉ có 1 hình nên sẽ đơn điệu nên muốn có nhiều hình hơn để cho khách hàng có thể xem)
- chức năng zoom khi di chuột lên ảnh (như trong các web ecomerce)
- âm thanh khi click vào 1 mục (cho âm thanh là 1 hợp âm đàn guitar, nút khác nhau có âm thanh khác nhau)
- modal pop up, hiện chương trình khuyến mãi hiện tại hoặc hàng cực hot
- chỉnh sửa giao diện cho các công việc của team BE













