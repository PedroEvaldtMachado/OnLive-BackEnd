'use server'

import './style.css'

function Content({children, } : Readonly<{ children: React.ReactNode | null; }>) {
  return (
    <div className="content">
      <div className="left-div"></div>
      <div className="mid-div">{children}</div>
    </div>
  );
}

export default Content;