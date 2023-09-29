using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Lab
{
    public class LabPlayerController : MonoBehaviour
    {
        public float Timer = 0f;
        public bool TimerIsOn = false;
        [SerializeField] private DrawLine _drawLine;
        [SerializeField] private LabController _labController;
        [SerializeField] private List<LabChekpoint> _chekPoints;
        [SerializeField] private LabFinis labFinis;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                TimerIsOn = true;
                _drawLine.Draw();
            }
            if (Input.GetMouseButtonDown(1))
            {
                _drawLine.Clean();
            }

            TimerUpdate();
        }
        public void Finish()
        {
            TimerIsOn = false;
            foreach (var point in _chekPoints)
            {
                if (point.IsPassed)
                    continue;
                else
                {
                    Restart();
                    return;
                }
            }               
            PlayerWin();             
        }

        public async void Restart()
        {
            _drawLine.CanDraw = false;
            _drawLine.Clean();

            await Task.Delay(1000);
            _drawLine.CanDraw = true;
            Debug.Log("restart");
           
            foreach (var point in _chekPoints)
                point.IsPassed = false;
            TimerIsOn = false;
            Timer = 0;

        }
        private void PlayerWin()
        {
            TimerIsOn = false;
            Debug.Log("Win");
            _labController.FinishGame();

        }

        private void TimerUpdate()
        {
            if(TimerIsOn)
            Timer += Time.deltaTime;
        }
        
    }

}

