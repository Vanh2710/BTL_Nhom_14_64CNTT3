using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;

    //Tạo 1 vector 2d với tạo độ (x,y)
    public Vector2 velocity = new Vector2(0f, 0f);

    //Tạo tọa độ X cho Player với tên hàm "pressHorizontal" 
    public float pressHorizontal = 0f;

    //Tạo tọa độ Y cho Player với tên hàm "pressVertical"
    public float pressVertical = 0f;

    //Tốc độ tăng tốc
    public float speedUp = 0.5f;

    //Tốc độ giảm tốc
    public float speedDown = 0.5f;

    //Tốc độ tối đa có thể đạt được
    public float speedMax = 15f;

    //Tốc độ khi điều khiển phím A và D
    public float speedHorizontal = 3f;

    //Mặc định biến tự động chạy là false
    public bool autoRun = false;

    //Hàm tự động tạo một component tên Rigidbody2D trong Object Player khi chạy chương trình
    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {   
        //Điều khiển bằng phím A và D
        this.pressHorizontal  = Input.GetAxis("Horizontal");
        //Điều khiển bằng phím W và S
        this.pressVertical = Input.GetAxis("Vertical");

        //Khiến cho Player tự động chạy
        if (this.autoRun) this.pressVertical = 1;
    }
    private void FixedUpdate()
    {
        this.UpdateSpeed();
    }

    //Hàm ảo khởi tạo tốc độ của Player
    protected virtual void UpdateSpeed()
    {
        //Tốc độ khi bấm A và D
        this.velocity.x = this.pressHorizontal * speedHorizontal;
        this.UpdateSpeedUp();  
        this.UpdateSpeedDown();
    
        this.rb2d.MovePosition(this.rb2d.position + this.velocity * Time.fixedDeltaTime);
    }

    //Hàm Tăng Tốc
    protected virtual void UpdateSpeedUp()
    {
        //Nếu W hoặc S = 0 thì Player dừng
        if (this.pressVertical <= 0) return;
          
        //Tăng dần tốc độ tăng tốc 
        this.velocity.y += this.speedUp;

        //Khi Player đạt ngưỡng Speed Max thì không thể gia tăng thêm nữa
        if (this.velocity.y > this.speedMax) this.velocity.y = this.speedMax;

        if (transform.position.x < -7 || transform.position.x > 7)
        {
            this.velocity.y -= 1f;
            if (this.velocity.y < 3f) this.velocity.y = 3f;
        }


    }

    //Hàm Giảm Tốc
    protected virtual void UpdateSpeedDown()
    {
        //Nếu không chạm vào nút W hoặc nút S thì Player sẽ không chạy
        if (this.pressVertical != 0) return;
        
        //Khi bấm S tốc độ sẽ từ từ giảm xuống mức 0
        this.velocity.y -= this.speedDown;
        //Khi tốc độ = 0 thì không thể giảm xuống dưới mức đó
        if(this.velocity.y < 0) this.velocity.y = 0;
    

    }
}
