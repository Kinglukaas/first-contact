using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Player : Sprite
    {
        private const float JUMPFORCE = 30f;
        private float velocityX = 0f;
        private float velocityY = 0f;
        private  float gravity = 0.4f;
        private const float friction = 0.98f;

        private bool isAbleToJump = true;
        private int doubleJump = 0;

        private bool isGrounded = false;

        private Sprite arrow;

        public Player() : base("square.png") 
            {
            this.SetOrigin(this.width / 2, this.height / 2);

            arrow = new Sprite("arrow.png", addCollider: false);
            arrow.SetOrigin(-arrow.width / 2, arrow.height / 2);
            AddChild(arrow);
            }

        void Update()
        {
            playerMovement();
        }

        private void playerMovement()
        {
            if(Input.GetMouseButtonDown(0) & isAbleToJump == true)
            {
                float blaX = Input.mouseX - this.x;
                float blaY = Input.mouseY - this.y;
                float length = Mathf.Sqrt(Mathf.Pow(blaX, 2) + Mathf.Pow(blaY, 2));

                velocityX = blaX / length * JUMPFORCE;
                velocityY = blaY / length * JUMPFORCE;

                gravity = 0.4f;
                doubleJump += 1;

                if(doubleJump >= 2)
                {
                    isAbleToJump = false;
                }

                isGrounded = false;
            }

            if(isGrounded == false)
            {
                arrow.alpha = 0;
            }

            else
            {
                arrow.alpha = 1;
            }

            velocityY += gravity;
            velocityX *= friction;
            velocityY *= friction;

            this.x += velocityX;
            this.y += velocityY;
        }

        void OnCollision(GameObject other)
        {
            doubleJump = 0;
            isAbleToJump = true;
            isGrounded = true;

            velocityX = 0;
            velocityY = 0;
            gravity = 0;
        }
        
    }
}
