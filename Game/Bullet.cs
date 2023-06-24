//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game
//{
//    class Bullet
//    {
//        /* Character Properties */
//        private Transform _transform;
//        private Renderer _renderer;
//        private Animation idleAnimation;
//        private Animation currentAnimation;
//        private Transform _playerTransform;
//        private Character _player;

//        /* Speed Values */
//        private float _movementSpeed;
//        private float _rotationSpeed;

//        public Bullet(Vector2 position, Vector2 scale, float angle, float movementSpeed)
//        {
//            _player = LevelController.Player;
//            //_player.LifeController.onGetDamage += OnGetDamageHandler;

//            _transform = new Transform(position, scale, angle);


//            //CreateAnimations();
//            currentAnimation = idleAnimation;
//            _movementSpeed = movementSpeed;
//            _rotationSpeed = 100f;

//            _renderer = new Renderer(idleAnimation, scale);

//        }

//        private void OnGetDamageHandler()
//        {
//            Engine.Debug("acá podría hacer desaparecer la bala");
//        }

//        private void CreateAnimations()
//        {
//            List<Texture> idleTextures = new List<Texture>();
//            for (int i = 1; i <= 2; i++)
//            {
//                Texture frame = Engine.GetTexture($"Textures/Bullet/BulletLaser{i}.png");
//                idleTextures.Add(frame);
//            }
//            idleAnimation = new Animation(true, "Idle", 0.1f, idleTextures);
//        }

//        public void Update()
//        {

//            _transform.Translate(new Vector2(1, 0), _movementSpeed);
//            //    _transform.Rotate(1, _rotationSpeed);

//            if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
//                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

//            currentAnimation.Update();
//            CheckCollision();
//        }

//        public void CheckCollision()
//        {

//            float distanceX = Math.Abs(_player.Transform.Position.X - _transform.Position.X);
//            float distanceY = Math.Abs(_player.Transform.Position.Y - _transform.Position.Y);

//            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
//            float sumHalfHeights = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

//            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
//            {
//                _player.LifeController.GetDamage(50);
//            }
//        }

//        public void Render()
//        {
//            _renderer.Render(_transform);
//        }
//    }

//}
