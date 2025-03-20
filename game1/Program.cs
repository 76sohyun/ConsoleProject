using System.Reflection;

namespace game1
{
    internal class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }


        static void Main(string[] args)
        {
            bool gameOver = false;
            Position playerPos;
            char[,] map;
            char[,] map2;

            Start(out playerPos, out map, out map2);
            while(gameOver == false)
            {
                Render(playerPos, map);
                ConsoleKey key = Input();
                Update(key, ref playerPos, ref map, ref gameOver);
                
            }
            End();
        }
        static void Reset(out Position playerPos, out char[,] map)
        {
            //플레이어 설정
            playerPos.x = 1;
            playerPos.y = 1;
            //맵 설정
            map = new char[10, 15]
            {
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', '♠', ' ', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '▒', '▒', '◇', ' ', ' ', ' ', ' ', '◆', ' ', '▒'},
                {'▒', ' ', ' ', ' ', '▒', '□', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '★','▒'},
                {'▒', '▒', '▒', '▒', ' ', ' ', ' ', '□', '▒', ' ', ' ', '▒', ' ', ' ', '▒'},
                {'▒', ' ', ' ', ' ', ' ', '■', ' ', ' ', '▒', ' ', ' ', ' ', ' ', '▒', '▒'},
                {'▒', ' ', ' ', ' ', '■', '■', ' ', ' ', '♠', ' ', '▒', '♠', '■', ' ', '▒'},
                {'▒', ' ', '♠', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', '□', ' ', '▒', ' ', '♠', ' ', ' ', '▒', '♠', '♠', ' ', ' ', '□', '▒'},
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            };
        }
        static void Start(out Position playerPos, out char[,] map, out char[,] map2)
        {
            //커서 없애기
            Console.CursorVisible = false;
            //플레이어 설정
            playerPos.x = 1;
            playerPos.y = 1;
            //맵 설정
            map = new char[10, 15]
            {
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', '♠', ' ', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '▒', '▒', '◇', ' ', ' ', ' ', ' ', '◆', ' ', '▒'},
                {'▒', ' ', ' ', ' ', '▒', '□', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '★','▒'},
                {'▒', '▒', '▒', '▒', ' ', ' ', ' ', '□', '▒', ' ', ' ', '▒', ' ', ' ', '▒'},
                {'▒', ' ', ' ', ' ', ' ', '■', ' ', ' ', '▒', ' ', ' ', ' ', ' ', '▒', '▒'},
                {'▒', ' ', ' ', ' ', '■', '■', ' ', ' ', '♠', ' ', '▒', '♠', '■', ' ', '▒'},
                {'▒', ' ', '♠', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', '□', ' ', '▒', ' ', '♠', ' ', ' ', '▒', '♠', '♠', ' ', ' ', '□', '▒'},
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            };

            map2 = new char[10, 15]
            {
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
                {'▒', ' ', '▒', ' ', '□', ' ', ' ', ' ', ' ', '♠', ' ', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '□', '▒', '♠', ' ', ' ', ' ', ' ', '□', ' ', '▒'},
                {'▒', ' ', '▒', '♠', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '★','▒'},
                {'▒', '■', ' ', ' ', '■', ' ', ' ', '□', '▒', ' ', ' ', '▒', ' ', ' ', '▒'},
                {'▒', '♠', ' ', '♠', ' ', '■', ' ', ' ', '▒', ' ', '■', ' ', ' ', '▒', '▒'},
                {'▒', ' ', '▒', ' ', ' ', '■', ' ', ' ', '♠', ' ', '▒', '♠', '■', ' ', '▒'},
                {'▒', ' ', '♠', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', '□', ' ', '▒', '♠', '♠', ' ', ' ', '▒', '♠', '♠', ' ', ' ', '□', '▒'},
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            };
            Title();
        }
        static void Title()
        {
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★");
            Console.WriteLine("  레 전 드 감 옥 탈 출");
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★");
            Console.WriteLine();
            Console.WriteLine("⊂_ ^");
            Console.WriteLine("　 ＼＼ Λ＿Λ");
            Console.WriteLine("　　 ＼( ‘ㅅ') 두둠칫");
            Console.WriteLine("　　　 >　 ⌒ \\");
            Console.WriteLine("　　　/ 　 へ ＼");
            Console.WriteLine("　　 /　　/　＼＼\r\n");
            Console.WriteLine("　　 \\　ノ　　 ヽ_つ");
            Console.WriteLine("　　/　/두둠칫");
            Console.WriteLine("　 /　/|");
            Console.WriteLine("　(　( \\");
            Console.WriteLine("　| |、＼");
            Console.WriteLine("　| / ＼ ⌒)");
            Console.WriteLine("　| |　　) /");
            Console.WriteLine("`ノ )　　L/ ");
            Console.WriteLine();
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★");
            Console.WriteLine(" 아무키나 눌러서 시작!");
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void Render(Position playerPos, char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            
            PrintMap(map);
            Printplayer(playerPos);

            Console.SetCursorPosition(0, 14);
            Console.WriteLine("★ 방향키 ★");
            Console.WriteLine("위 : W, ↑");
            Console.WriteLine("아래 : S, ↓");
            Console.WriteLine("왼쪽 : a, ←");
            Console.WriteLine("오른쪽 : D, →\n");
            Console.WriteLine("초기화 : R");
            Console.WriteLine("--------------------------");
            Console.WriteLine("♠ : 적");
            Console.WriteLine("◆ : 열쇠");
            Console.WriteLine("★ : 문");
            Console.WriteLine("■ : 박스");
            Console.WriteLine("--------------------------");
            Console.WriteLine("팁 : 박스로 적을 밀면 죽일 수 있따");
        }

        static void Printplayer(Position playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('●');
            Console.ResetColor();
        }

        static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '▒')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write('▒');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '■' )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('■');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '▣')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('▣');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '♠')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('♠');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '◆')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('◆');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '◈')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('◈');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map[y, x]);
                    }

                       
                    
                }
                Console.WriteLine();
            }
            
        }

        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }

        //플레이어 움직임
        static void Move(ConsoleKey key, ref Position playerPos, char[,] map)
        {
            Position targetPos;
            Position overPos;
            switch(key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    targetPos.x = playerPos.x - 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x - 2;
                    overPos.y = playerPos.y;
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    targetPos.x = playerPos.x + 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x + 2;
                    overPos.y = playerPos.y;
                    break;

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y - 1;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y - 2;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y + 1;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y + 2;
                    break;
                default:
                    return;
            }
            //움직이는 방향에 박스가 있을 때
            if (map[targetPos.y, targetPos.x] == '■')
            {
                //그 다음에 빈칸이 있을 때
                if (map[overPos.y, overPos.x] == ' ')
                {
                    //빈칸 위치에 박스
                    map[overPos.y, overPos.x] = '■';
                    //박스 위치에 빈칸
                    map[targetPos.y, targetPos.x] = ' ';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                //그 다음에 박스 놓을 자리가 있을 때
                else if (map[overPos.y, overPos.x] == '□')
                {
                    //박스 놓을 자리에 박스자리
                    map[overPos.y, overPos.x] = '▣';
                    //박스 위치를 빈칸
                    map[targetPos.y, targetPos.x] = ' ';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                   
                }
                //그 다음에 적이 있을때
                else if (map[overPos.y, overPos.x] == '♠')
                {
                    //박스 놓을 자리에 박스자리
                    map[overPos.y, overPos.x] = '■';
                    //박스 위치를 빈칸
                    map[targetPos.y, targetPos.x] = ' ';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;

                }
            }
            //움직이는 방향에 박스놓을자리가 잇을때
            else if (map[targetPos.y, targetPos.x] == '□')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            //움직이는 방향에 박스자리가잇을때
            else if (map[targetPos.y, targetPos.x] == '▣')
            {
                //그다음에 박스놓을 자리가 있을떼
                if (map[overPos.y, overPos.x] == '□')
                {
                    //박스놓을자리에 박스자리
                    map[overPos.y, overPos.x] = '▣';
                    //박스자리를 박스 놓을자리로
                    map[targetPos.y, targetPos.x] = '□';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                //그 다음에 빈칸이 있을 때
                else if (map[targetPos.y, targetPos.x] == ' ')
                {
                    //빈칸에 박스
                    map[overPos.y, overPos.x] = '■';
                    //박스자리를 박스 놓을자리로
                    map[targetPos.y, targetPos.x] = '□';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
            }

            //움직이는 방향에 키가 있을 때
            else if (map[targetPos.y, targetPos.x] == '◆')
            {
                //그 다음에 빈칸이 있을 때
                if (map[overPos.y, overPos.x] == ' ')
                {
                    //빈칸 위치에 키
                    map[overPos.y, overPos.x] = '◆';
                    //박스 위치에 빈칸
                    map[targetPos.y, targetPos.x] = ' ';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                //그 다음에 키 놓을 자리가 있을 때
                else if (map[overPos.y, overPos.x] == '◇')
                {
                    //박스 놓을 자리에 키놓을자리
                    map[overPos.y, overPos.x] = '◈';
                    //박스 위치를 빈칸
                    map[targetPos.y, targetPos.x] = ' ';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                    //별이 빈칸으로 변한다.
                    map[3, 13] = ' ';
                }
            }
            //움직이는 방향에 키놓을자리가 잇을때
            else if (map[targetPos.y, targetPos.x] == '◇')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            //움직이는 방향에 키놓을자리가잇을때
            else if (map[targetPos.y, targetPos.x] == '◈')
            {
                //그다음에 키놓을 자리가 있을떼
                if (map[overPos.y, overPos.x] == '◇')
                {
                    //박스놓을자리에 키자리
                    map[overPos.y, overPos.x] = '◈';
                    //박스자리를 키 놓을자리로
                    map[targetPos.y, targetPos.x] = '◇';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                //그 다음에 빈칸이 있을 때
                else if (map[targetPos.y, targetPos.x] == ' ')
                {
                    //빈칸에 키
                    map[overPos.y, overPos.x] = '◆';
                    //박스자리를 키 놓을자리로
                    map[targetPos.y, targetPos.x] = '◇';
                    //플레이어를 움직이는 위치
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
            }
            //움직이는 방향에 적이 있을 때
            else if (map[targetPos.y, targetPos.x] == '♠')
            {
                playerPos.x = 1;
                playerPos.y = 1;
            }
            //움직이는 방향이 빈칸
            else if (map[targetPos.y, targetPos.x] == ' ')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }

            //움직이는 방향이 벽이거나 문이거나 박스넣은자리일때
            else if (map[targetPos.y, targetPos.x] == '▒' && map[targetPos.y, targetPos.x] == '★' && map[targetPos.y, targetPos.x] == '▣') ;
            {

            }
        }

        static void Update(ConsoleKey key, ref Position playerPos, ref char[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos, map);

            bool isClear = IsClear(map);
            if (isClear)
            {
                gameOver = true;
            }

            switch(key)
            {
                case ConsoleKey.R:
                    Reset(out playerPos, out map);
                    break;

            }
        }

        static bool IsClear(char[,] map)
        {
            int boxCount = 0;

            //박스칸이 없으면 클리어
            foreach(char tile in map)
            {
                if(tile == '□')
                {
                    boxCount++;
                    break;
                }
            }
            if (boxCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("1스테이지 클리어 다음스테이지로!");
        }
    }
}
